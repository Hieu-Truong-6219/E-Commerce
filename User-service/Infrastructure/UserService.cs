using User_service.Application;

namespace User_service.Infrastructure;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _repo = userRepository;

    public async Task<UserInfoDto> CreateUserAsync(UserInfoDto info)
    {
        var user = await _repo.CreateUserAsync(info.ToInfo(uuid: Guid.NewGuid().ToString()));
        return user.ToDto();
    }

    public async Task<List<UserInfoDto>> GetAllUsersAsync()
    {
        var users = await _repo.GetAllUsersAsync();

        return users.Select(user => user.ToDto()).ToList();
    }

    public async Task<UserInfoDto?> GetUserInfoDtoAsync(string uuid)
    {
        var user = await _repo.GetUserInfoAsync(uuid);

        return (user == null) ? null : user.ToDto();
    }

    public async Task<UserInfoDto?> UpdateUserAsync(string uuid, UserInfoDto info)
    {
        var user = await _repo.UpdateUserAsync(uuid, info.ToInfo(uuid: uuid));

        return (user == null) ? null : user.ToDto();
    }

    public async Task<UserInfoDto?> DeleteUserAsync(string uuid)
    {
        var user = await _repo.DeleteUserAsync(uuid);

        return (user == null) ? null : user.ToDto();
    }
}
