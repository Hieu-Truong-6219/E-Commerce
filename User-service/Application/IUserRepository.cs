using UserMicroService.Domain;

namespace UserMicroService.Application;

public interface IUserRepository
{
    public Task<UserInfo> CreateUserAsync(UserInfo info);
    public List<UserInfo> GetAllUsers();
    public UserInfo? GetUserInfo(int id);
    public Task<UserInfo?> UpdateUserAsync(UserInfo info);
    public Task<UserInfo?> DeleteUserAsync(int id);
}
