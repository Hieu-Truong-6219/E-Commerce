namespace User_service.Application;

public interface ILoginRegisterService
{
    // TODO: Returning string temporarily. Need to return ID JWT
    public Task<AccessTokensDto?> LoginUserAsync(UserLoginCredentialDto credentials);
    public Task<AccessTokensDto?> RegisterUserAsync(UserRegisterCredentialDto credentials);
}
