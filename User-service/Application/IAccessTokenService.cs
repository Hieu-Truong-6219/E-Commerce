using User_service.Domain;

namespace User_service.Application;

public interface IAccessTokenService
{
    public Task<string> GenerateAccessTokenAsync(AccessTokenInfo info);
}
