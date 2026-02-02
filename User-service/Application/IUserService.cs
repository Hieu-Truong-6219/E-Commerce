namespace UserMicroService.Application;

public interface IUserService
{
    public Task<UserInfoDto> CreateUserAsync(UserInfoDto info);
    public List<UserInfoDto> GetAllUsers();
    public UserInfoDto? GetUserInfoDto(int id);
    public Task<UserInfoDto?> UpdateUserAsync(int id, UserInfoDto info);
    public Task<UserInfoDto?> DeleteUserAsync(int id);
}
