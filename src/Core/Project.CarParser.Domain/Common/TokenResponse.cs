namespace Project.CarParser.Domain.Common;

public class TokenResponse
{
  public string AccessToken { get; set; } = string.Empty;
  public string RefreshToken { get; set; } = string.Empty;
  public DateTime Expires { get; set; }
}
