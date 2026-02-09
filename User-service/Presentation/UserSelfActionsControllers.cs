using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserMicroService.Application;

namespace UserMicroService.Presentation;

[ApiController]
[Route("u")]
public class UserSelfActionsController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPut("{userUuid}")]
    [Authorize(Policy = "SpecificUser")]
    public async Task<ActionResult<UserInfoDto>?> UpdateUserAsync(string userUuid, UserInfoDto info)
    {
        return Ok(await _userService.UpdateUserAsync(userUuid, info));
    }

    [HttpDelete("{userUuid}")]
    [Authorize(Policy = "SpecificUser")]
    public async Task<ActionResult<UserInfoDto>?> DeleteUserAsync(string userUuid)
    {
        return Ok(await _userService.DeleteUserAsync(userUuid));
    }
}
