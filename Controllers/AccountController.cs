using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineShop_API.Models;
using OnlineShop_API.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _Configuration;

        public AccountController(RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _Configuration = configuration;
            _roleManager = roleManager;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModels login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.username, login.password, false, false);
            if (result.Succeeded)
            {

                var authClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,login.username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JWT:SecretKey"]));

                var token = new JwtSecurityToken
                    (
               issuer: _Configuration["JWT:ValidIssuer"],
               audience: _Configuration["JWT:ValidAudience"],
               claims: authClaim,
               expires: DateTime.Now.AddDays(1),
               signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256)
               );

                var user = await _userManager.FindByNameAsync(login.username);
                var useRole = await _roleManager.FindByNameAsync(login.username);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    userName = user.UserName,
                    userId = user.Id,
                    userRole = useRole,
                    expires = DateTime.Now.AddDays(1),
                    fname = user.firstName,
                    lname = user.lastName

                });
            }
            return Unauthorized();
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody]SignupViewModel signUp)
        {
            var user = new AppUser
            {
                UserName = signUp.userName,
                Email = signUp.email,
                firstName = signUp.firstName,
                lastName = signUp.lastName,

            };
            var result = await _userManager.CreateAsync(user, signUp.password);
            return Ok(result);
        }
    }
}
