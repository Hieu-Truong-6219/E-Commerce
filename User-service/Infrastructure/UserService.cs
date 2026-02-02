using UserMicroService.Application;

namespace UserMicroService.Infrastructure;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _repo = userRepository;

    public async Task<UserInfoDto> CreateUserAsync(UserInfoDto info)
    {
        var user = await _repo.CreateUserAsync(info.ToInfo());
        return user.ToDto();
    }

    public List<UserInfoDto> GetAllUsers()
    {
        var users = _repo.GetAllUsers();

        return users.Select(user => user.ToDto()).ToList();
    }

    public UserInfoDto? GetUserInfoDto(int id)
    {
        var user = _repo.GetUserInfo(id);

        return (user == null) ? null : user.ToDto();
    }

    public async Task<UserInfoDto?> UpdateUserAsync(int id, UserInfoDto info)
    {
        var user = await _repo.UpdateUserAsync(info.ToInfo(id));

        return (user == null) ? null : user.ToDto();
    }

    public async Task<UserInfoDto?> DeleteUserAsync(int id)
    {
        var user = await _repo.DeleteUserAsync(id);

        return (user == null) ? null : user.ToDto();
    }
}
