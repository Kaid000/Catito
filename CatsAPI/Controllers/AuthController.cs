using Application.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly UserRepository _userRepository;

    public AuthController(ILogger<AuthController> logger, UserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAndPasswordAsync(email, password);

        if (user == null)
        {
            _logger.LogWarning("User not found: {Email}", email);
            return Unauthorized("Invalid credentials");
        }

        return Ok("123");
    }
}
