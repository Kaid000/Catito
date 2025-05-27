using Application.Repositories.Interfaces;
using Application.Services.Interfaces;
using Domain.DTO;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatsController : ControllerBase
    {
        private readonly ILogger<CatsController> _logger;
        private readonly ICatsRepository _catsRepository;

        public CatsController(ILogger<CatsController> logger, ICatsRepository catsRepository)
        {
            _logger = logger;
            _catsRepository = catsRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginDTO loginDTO)
        {
            var token = await _catsRepository.AuthenticateAsync(loginDTO.Email, loginDTO.Password);

            if (token == null)
            {
                _logger.LogWarning("User not found: {Email}", loginDTO.Email);
                return Unauthorized("Invalid credentials");
            }

            return Ok(token);
        }
    }
}
