using UserMicroService.Domain;

namespace UserMicroService.Application;

public interface IAccessTokenService
{
    public string GenerateAccessToken(AccessTokenInfo info);
}
