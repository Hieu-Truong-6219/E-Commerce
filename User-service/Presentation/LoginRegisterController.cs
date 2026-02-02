using Microsoft.AspNetCore.Mvc;
using UserMicroService.Application;

namespace UserMicroService.Presentation;

[ApiController]
[Route("")]
public class LoginRegisterController(ILoginRegisterService loginService) : ControllerBase
{
    private readonly ILoginRegisterService _loginService = loginService;

    [HttpGet("login")]
    public ActionResult<string> Login(UserLoginCredentialDto credentials)
    {
        var jwt = _loginService.LoginUser(credentials);
        if (jwt == null)
            return Unauthorized("Incorrect email or password");
        return Ok(jwt);
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register(UserRegisterCredentialDto credentials)
    {
        var jwt = await _loginService.RegisterUserAsync(credentials);
        if (jwt == null)
            return Conflict("Email exists");
        return Ok(jwt);
    }
}
