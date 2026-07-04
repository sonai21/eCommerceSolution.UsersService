using eCommerce.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;
    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;

    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest == null) {
            return BadRequest("Invalid registration data");
        }

        AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);
        if (authenticationResponse == null || authenticationResponse.Success == false) {
            return BadRequest(authenticationResponse);

        }

        return Ok(authenticationResponse);


    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginRequest(LoginRequest loginRequest)
    {
        if (loginRequest == null) {
            return BadRequest("Invalid login data");

        }

        AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);
        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return Unauthorized(authenticationResponse);

        }

        return Ok(authenticationResponse);

    }

    [HttpGet("user-verification/{userId}")]
    public async Task<IActionResult> IsUserVerified(Guid userId)
    {
        var isUser = await _usersService.GetUserByUserid(userId);
        if (isUser == null) {
            return BadRequest("Invalid user!");
        }
        return Ok(new {Success = true, Message = "User is verified." });
    }

}