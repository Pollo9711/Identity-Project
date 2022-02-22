using System.Threading.Tasks;
using ExampleIdentityService.Shared;
using Microsoft.AspNetCore.Identity;

namespace ExampleIdentityService.Interfaces
{
    public interface IIdentityService 
    {
        Task<bool> RegisterAsync(RegisterDTO register);
        Task<AuthResponse> LoginAsync(LoginDTO login);
    }
}