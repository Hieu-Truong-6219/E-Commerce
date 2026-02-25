namespace User_service.Application;

public interface IUserService
{
    public Task<UserInfoDto> CreateUserAsync(UserInfoDto info);
    public Task<List<UserInfoDto>> GetAllUsersAsync();
    public Task<UserInfoDto?> GetUserInfoDtoAsync(string userUuid);
    public Task<UserInfoDto?> UpdateUserAsync(string userUuid, UserInfoDto info);
    public Task<UserInfoDto?> DeleteUserAsync(string userUuid);
}
