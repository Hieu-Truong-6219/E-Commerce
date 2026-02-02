using UserMicroService.Application;
using UserMicroService.Domain;

namespace UserMicroService.Infrastructure;

public class LoginRegisterService(IUserService userService, IPasswordHashService hashService)
    : ILoginRegisterService
{
    private readonly IUserService _userService = userService;
    private readonly IPasswordHashService _hashService = hashService;

    public string? LoginUser(UserLoginCredentialDto credentials)
    {
        List<UserInfoDto> users = _userService.GetAllUsers();
        var foundUser = users.FirstOrDefault(user => user.Email == credentials.Email);

        if (foundUser == null)
            return null;

        if (_hashService.VerifyHash(foundUser.Password, credentials.Password) == false)
            return null;

        return "JWT ID Token";
    }

    public async Task<string?> RegisterUserAsync(UserRegisterCredentialDto credentials)
    {
        List<UserInfoDto> users = _userService.GetAllUsers();

        if (users.FirstOrDefault(user => user.Email == credentials.Email) != null)
            return null;

        // More checks here

        UserInfoDto userInfo = new()
        {
            Email = credentials.Email,
            Username = credentials.Username,
            Password = _hashService.Hash(credentials.Password),
        };

        await _userService.CreateUserAsync(userInfo);

        return "JWT ID Token";
    }
}
