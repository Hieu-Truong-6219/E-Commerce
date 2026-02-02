namespace UserMicroService.Application;

public interface ILoginRegisterService
{
    // Returning string temporarily. Need to return ID JWT
    public string? LoginUser(UserLoginCredentialDto credentials);
    public Task<string?> RegisterUserAsync(UserRegisterCredentialDto credentials);
}
