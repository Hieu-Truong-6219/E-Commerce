// Essentially just for testing. Very unsecure, should disable on production.

using Microsoft.AspNetCore.Mvc;
using UserMicroService.Application;

namespace UserMicroService.Presentation;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost]
    public async Task<ActionResult<UserInfoDto>> CreateUserAsync(UserInfoDto info)
    {
        return Ok(await _userService.CreateUserAsync(info));
    }

    [HttpGet]
    public async Task<ActionResult<List<UserInfoDto>>> GetAllUsers()
    {
        return Ok(await _userService.GetAllUsersAsync());
    }

    [HttpGet("{userUuid}")]
    public async Task<ActionResult<UserInfoDto>?> GetUserInfoDto(string userUuid)
    {
        return Ok(await _userService.GetUserInfoDtoAsync(userUuid));
    }

    [HttpPut("{userUuid}")]
    public async Task<ActionResult<UserInfoDto>?> UpdateUserAsync(string userUuid, UserInfoDto info)
    {
        return Ok(await _userService.UpdateUserAsync(userUuid, info));
    }

    [HttpDelete("{userUuid}")]
    public async Task<ActionResult<UserInfoDto>?> DeleteUserAsync(string userUuid)
    {
        return Ok(await _userService.DeleteUserAsync(userUuid));
    }
}
