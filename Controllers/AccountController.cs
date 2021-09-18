using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _Configuration;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _Configuration = configuration;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            var result = await _signInManager.PasswordSignInAsync("eimdadul", "123456", false, false);
            if (result.Succeeded)
            {

                var authClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "eimdadul"),
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

                var user = await _userManager.FindByNameAsync("eimdadul");
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    userName = user.UserName,
                    userId = user.Id,
                    expires = DateTime.Now.AddDays(1)
                });
            }
            return Unauthorized();
        }

        [HttpGet("signup")]
        public async Task<IActionResult> Signup()
        {
            var user = new IdentityUser
            {
                UserName = "eimdadul",
                Email = "eimadadul@mail.com"
            };
            var result = await _userManager.CreateAsync(user, "123456");
            return Ok(result);
        }
    }
}
