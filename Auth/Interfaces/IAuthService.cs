using GerenciadorEstoque.Auth.Models;

namespace GerenciadorEstoque.Auth.Interfaces;

public interface IAuthService
{
    Task<string> LoginAsync(string username, string password);
    Task<string> GenerateRefreshToken(string username);
    Task<ApplicationUser> GetUserByRefreshToken(string refreshToken);
    string GenerateJwtToken(ApplicationUser user);
}
