using Microsoft.AspNetCore.Mvc;
using User_service.Application;

namespace User_service.Presentation;

[ApiController]
[Route("")]
public class LoginRegisterController(ILoginRegisterService loginService) : ControllerBase
{
    private readonly ILoginRegisterService _loginService = loginService;

    [HttpGet("login")]
    public async Task<ActionResult<AccessTokensDto>> Login(UserLoginCredentialDto credentials)
    {
        var jwt = await _loginService.LoginUserAsync(credentials);
        if (jwt == null)
            return Unauthorized("Incorrect email or password");
        return Ok(jwt);
    }

    [HttpPost("register")]
    public async Task<ActionResult<AccessTokensDto>> Register(UserRegisterCredentialDto credentials)
    {
        var jwt = await _loginService.RegisterUserAsync(credentials);
        if (jwt == null)
            return Conflict("Email exists");
        return Ok(jwt);
    }
}
