using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ExampleIdentityService.Interfaces;
using ExampleIdentityService.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ExampleIdentityService.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly JwtSetting _jwtSetting;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public IdentityService(IOptions<JwtSetting> jwtSetting, UserManager<IdentityUser<int>> userManager, SignInManager<IdentityUser<int>> signInManager)
        {
            _jwtSetting = jwtSetting.Value;
            _userManager = userManager;
            _signInManager = signInManager; 
        }

      
        public async Task<AuthResponse> LoginAsync(LoginDTO login)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(login.Username, login.Password, false, false);

            if (!signInResult.Succeeded)
            {
                return null;
            }

            var user = await _userManager.FindByNameAsync(login.Username);
            var userRole = await _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("name", login.Username),
                new Claim("username", user.UserName),
                new Claim("email", user.Email),
                new Claim("role", userRole[0] )
            };


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecurityKey));
            var signInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);


            var jwtSecurityToken = new JwtSecurityToken(_jwtSetting.Issuer, _jwtSetting.Audience, claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(10), signInCredentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var response = new AuthResponse {AccesToken = accessToken};
            return response;
        }

        public async Task<bool> RegisterAsync(RegisterDTO register)
        {
            var user = new IdentityUser<int>
            {
                UserName = register.UserName,
                Email = register.Email
            };

            var registerResult = await _userManager.CreateAsync(user, register.Password);

            if (register.IsAdmin)
            {
                await  _userManager.AddToRoleAsync(user, "Administrator");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return true;
        }


    }
}