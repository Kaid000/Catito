using Application.Services.Interfaces;
using Domain.DTO;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests.Controllers
{
    public class AuthControllerTests
    {
        private readonly Mock<ILogger<AuthController>> _loggerMock;
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            _loggerMock = new Mock<ILogger<AuthController>>();
            _authServiceMock = new Mock<IAuthService>(MockBehavior.Strict);
            _controller = new AuthController(_loggerMock.Object, _authServiceMock.Object);
        }

        [Fact]
        public async Task Login_ReturnsOkResult_WhenCredentialsAreValid()
        {
            var loginDto = new LoginDTO { Email = "test@example.com", Password = "password123" };
            var expectedResponse = new LoginResponse { JwtSecretKey = "some.jwt.token" };

            _authServiceMock
                .Setup(service => service.AuthenticateAsync(loginDto.Email, loginDto.Password))
                .ReturnsAsync(expectedResponse);

            var result = await _controller.Login(loginDto);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedToken = Assert.IsType<LoginResponse>(okResult.Value);
            Assert.Equal(expectedResponse.JwtSecretKey, returnedToken.JwtSecretKey);
        }

        [Fact]
        public async Task Login_ReturnsUnauthorized_WhenCredentialsAreInvalid()
        {
            var loginDto = new LoginDTO { Email = "wrong@example.com", Password = "wrongpassword" };

            _authServiceMock
                .Setup(service => service.AuthenticateAsync(loginDto.Email, loginDto.Password))
                .ReturnsAsync((LoginResponse?)null);

            var result = await _controller.Login(loginDto);

            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result.Result);
            Assert.Equal("Invalid credentials", unauthorizedResult.Value);
        }
    }
}
