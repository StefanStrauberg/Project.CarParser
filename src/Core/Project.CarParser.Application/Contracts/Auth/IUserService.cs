using Microsoft.AspNetCore.Identity;

namespace Project.CarParser.Application.Contracts.Auth;

public interface IUserService
{
  Task<User?> FindByEmailAsync(string email);
  Task<IdentityResult> CreateAsync(User user, string password);
}
