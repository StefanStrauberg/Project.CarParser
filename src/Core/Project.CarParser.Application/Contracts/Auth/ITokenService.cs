namespace Project.CarParser.Application.Contracts.Auth;

public interface ITokenService
{
  Task<TokenResponse> GenerateTokensAsync(User user);
  Task<TokenResponse> RefreshTokenAsync(string accessToken, string refreshToken);
  ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}
