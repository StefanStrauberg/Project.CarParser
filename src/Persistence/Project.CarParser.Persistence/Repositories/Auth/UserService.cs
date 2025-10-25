namespace Project.CarParser.Persistence.Repositories.Auth;

internal class UserService(UserManager<User> userManager) : IUserService
{
  async Task<IdentityResult> IUserService.CreateAsync(User user, string password)
    => await userManager.CreateAsync(user, password);

  async Task<User?> IUserService.FindByEmailAsync(string email)
    => await userManager.FindByEmailAsync(email);
}
