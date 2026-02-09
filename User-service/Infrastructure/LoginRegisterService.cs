using UserMicroService.Application;
using UserMicroService.Domain;

namespace UserMicroService.Infrastructure;

public class LoginRegisterService(
    IUserService userService,
    IPasswordHashService hashService,
    IAccessTokenService accessTokenService
) : ILoginRegisterService
{
    private readonly IUserService _userService = userService;
    private readonly IPasswordHashService _hashService = hashService;
    private readonly IAccessTokenService _accessTokenService = accessTokenService;

    public async Task<string?> LoginUserAsync(UserLoginCredentialDto credentials)
    {
        List<UserInfoDto> users = await _userService.GetAllUsersAsync();
        var foundUser = users.FirstOrDefault(user => user.Email == credentials.Email);

        if (foundUser == null)
            return null;

        if (_hashService.VerifyHash(foundUser.Password, credentials.Password) == false)
            return null;

        var userAccessToken = _accessTokenService.GenerateAccessToken(
            new AccessTokenInfo(
                Environment.GetEnvironmentVariable("USER_MICROSERVICE")
                    ?? throw new Exception("User microservice endpoint not found"),
                foundUser.Uuid
            )
        );
        var cartAccessToken = _accessTokenService.GenerateAccessToken(
            new AccessTokenInfo(
                Environment.GetEnvironmentVariable("CART_MICROSERVICE")
                    ?? throw new Exception("Cart microservice endpoint not found"),
                foundUser.Uuid
            )
        );

        return userAccessToken;
    }

    public async Task<string?> RegisterUserAsync(UserRegisterCredentialDto credentials)
    {
        List<UserInfoDto> users = await _userService.GetAllUsersAsync();

        if (users.FirstOrDefault(user => user.Email == credentials.Email) != null)
            return null;

        // TODO: More checks here

        UserInfoDto userInfo = new()
        {
            Email = credentials.Email,
            Username = credentials.Username,
            Password = _hashService.Hash(credentials.Password),
        };

        var createdUser = await _userService.CreateUserAsync(userInfo);

        var cartAccessToken = _accessTokenService.GenerateAccessToken(
            new AccessTokenInfo(
                Environment.GetEnvironmentVariable("CART_MICROSERVICE")
                    ?? throw new Exception("Cart microservice endpoint not found"),
                createdUser.Uuid
            )
        );

        return cartAccessToken;
    }
}
