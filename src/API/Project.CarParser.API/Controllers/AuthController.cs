using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Project.CarParser.Application.Contracts.Auth;
using Project.CarParser.Domain;
using Project.CarParser.Domain.Common;

namespace Project.CarParser.API.Controllers;

public class AuthController(UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager,
                            ITokenService tokenService)
{
  private readonly UserManager<IdentityUser> _userManager = userManager;
  private readonly SignInManager<IdentityUser> _signInManager = signInManager;
  private readonly ITokenService _tokenService = tokenService;

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterModel model)
  {
    var user = new IdentityUser { UserName = model.Email, Email = model.Email };
    var result = await _userManager.CreateAsync(user, model.Password);

    if (!result.Succeeded)
      return BadRequest(result.Errors);

    return Ok(new { message = "User registered successfully" });
  }

  [HttpPost("login")]
  public async Task<ActionResult<TokenResponse>> Login([FromBody] LoginModel model)
  {
    var user = await _userManager.FindByEmailAsync(model.Email);
    if (user == null)
      return Unauthorized();

    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
    if (!result.Succeeded)
      return Unauthorized();

    var tokens = await _tokenService.GenerateTokensAsync(user);
    return tokens;
  }

  [HttpPost("refresh")]
  public async Task<ActionResult<TokenResponse>> Refresh([FromBody] RefreshTokenRequest request)
  {
    try
    {
      var tokens = await _tokenService.RefreshTokenAsync(request.AccessToken, request.RefreshToken);
      return tokens;
    }
    catch (SecurityTokenException ex)
    {
      return Unauthorized(ex.Message);
    }
  }

  [HttpPost("logout")]
  [Authorize]
  public async Task<IActionResult> Logout()
  {
    var user = await _userManager.GetUserAsync(User);
    if (user != null)
    {
      // Удаляем refresh token
      await _userManager.RemoveAuthenticationTokenAsync(user, "MyApp", "RefreshToken");
    }

    return Ok(new { message = "Logged out successfully" });
  }
}
