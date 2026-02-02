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
    public ActionResult<List<UserInfoDto>> GetAllUsers()
    {
        return Ok(_userService.GetAllUsers());
    }

    [HttpGet("{id}")]
    public ActionResult<UserInfoDto>? GetUserInfoDto(int id)
    {
        return Ok(_userService.GetUserInfoDto(id));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserInfoDto>?> UpdateUserAsync(int id, UserInfoDto info)
    {
        return Ok(await _userService.UpdateUserAsync(id, info));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserInfoDto>?> DeleteUserAsync(int id)
    {
        return Ok(await _userService.DeleteUserAsync(id));
    }
}
