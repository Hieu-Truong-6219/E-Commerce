using User_service.Domain;

namespace User_service.Application;

public interface IUserRepository
{
    public Task<UserInfo> CreateUserAsync(UserInfo info);
    public Task<List<UserInfo>> GetAllUsersAsync();

    public Task<UserInfo?> GetUserInfoAsync(string userUuid);
    public Task<UserInfo> UpdateUserAsync(string userUuid, UserInfo info);
    public Task<UserInfo> DeleteUserAsync(string userUuid);
}
