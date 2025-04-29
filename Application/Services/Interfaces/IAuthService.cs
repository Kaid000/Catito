using Domain.Responses;

namespace Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> AuthenticateAsync(string email, string password);
    }
}
