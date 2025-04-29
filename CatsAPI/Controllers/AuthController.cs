using Application.Services.Interfaces;
using Domain.DTO;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginDTO loginDTO)
    {
        var token = await _authService.AuthenticateAsync(loginDTO.Email, loginDTO.Password);

        if (token == null)
        {
            _logger.LogWarning("User not found: {Email}", loginDTO.Email);
            return Unauthorized("Invalid credentials");
        }

        return Ok(token);
    }
}
