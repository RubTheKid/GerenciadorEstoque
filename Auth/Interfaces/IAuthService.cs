using GerenciadorEstoque.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorEstoque.Auth.Interfaces;

public interface IAuthService
{
    Task<string> LoginAsync(string username, string password);
    Task<string> GenerateRefreshToken(string username);
    Task<ApplicationUser> GetUserByRefreshToken(string refreshToken);
    string GenerateJwtToken(ApplicationUser user);
}
