namespace Project.CarParser.TokenService;

public class TokenService(UserManager<IdentityUser> userManager,
                          IConfiguration configuration)
  : ITokenService
{
  public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
  {
    var jwtSettings = configuration.GetSection("JwtSettings");
    var tokenValidationParameters = new TokenValidationParameters
    {
      ValidateAudience = false,
      ValidateIssuer = false,
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!)),
      ValidateLifetime = false // Здесь мы игнорируем срок жизни
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

    if (securityToken is not JwtSecurityToken jwtSecurityToken ||
        !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
      throw new SecurityTokenException("Invalid token");

    return principal;
  }

  async Task<TokenResponse> ITokenService.GenerateTokensAsync(User user)
  {
    var claims = new List<Claim>
    {
      new(ClaimTypes.NameIdentifier, user.Id),
      new(ClaimTypes.Email, user.Email!),
      new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    // Добавляем роли пользователя
    var roles = await userManager.GetRolesAsync(user);
    claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

    var jwtSettings = configuration.GetSection("JwtSettings");
    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!));

    var accessToken = new JwtSecurityToken(
        issuer: jwtSettings["Issuer"],
        audience: jwtSettings["Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(5), // Access token на 5 минут
        signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
    );

    var refreshToken = GenerateRefreshToken();

    // Сохраняем refresh token в базе данных
    await userManager.SetAuthenticationTokenAsync(user,
                                                  "CarParser",
                                                  "RefreshToken",
                                                  refreshToken);

    return new TokenResponse
    {
      AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
      RefreshToken = refreshToken,
      Expires = accessToken.ValidTo
    };
  }

  async Task<TokenResponse> ITokenService.RefreshTokenAsync(string accessToken,
                                                            string refreshToken)
  {
    var principal = GetPrincipalFromExpiredToken(accessToken);
    var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    var user = await userManager.FindByIdAsync(userId!);
    if (user == null)
      throw new SecurityTokenException("Invalid token");

    var storedRefreshToken = await userManager.GetAuthenticationTokenAsync(user,
                                                                           "CarParser",
                                                                           "RefreshToken");
    if (storedRefreshToken != refreshToken)
      throw new SecurityTokenException("Invalid refresh token");

    return await GenerateTokensAsync(user);
  }

  static string GenerateRefreshToken()
  {
    var randomNumber = new byte[32];
    using var rng = RandomNumberGenerator.Create();
    rng.GetBytes(randomNumber);
    return Convert.ToBase64String(randomNumber);
  }
}
