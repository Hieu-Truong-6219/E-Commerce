using UserMicroService.Domain;

namespace UserMicroService.Application;

public static class ModelExtensions
{
    public static UserInfoDto ToDto(this UserInfo info)
    {
        return new UserInfoDto
        {
            Email = info.Email,
            Username = info.Username,
            Password = info.Password,
        };
    }

    public static UserInfo ToInfo(this UserInfoDto dto, int id = default)
    {
        return new UserInfo
        {
            Id = id,
            Email = dto.Email,
            Username = dto.Username,
            Password = dto.Password,
        };
    }
}
