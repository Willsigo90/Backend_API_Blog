using LibreriaBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServicioBlog.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        private readonly ILoginServicio loginServicio;


        public LoginController(IConfiguration config, ILoginServicio loginServicioIn)
        {
            _config = config;
            //_db = db;
            loginServicio = loginServicioIn;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User userLogin)
        {
            var user = loginServicio.ValidateLogin(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        [AllowAnonymous]
        [HttpGet("GetUser")]
        public IActionResult GetUserRol()
        {
            var user = GetCurrentUser();
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound("User not found");
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, user.IdUser.ToString()),
                new Claim(ClaimTypes.Role, user.IdRolNavigation.NameRol),
                 new Claim(ClaimTypes.Name, user.UserName)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                User user = new User()
                {
                    UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value,
                    IdUser = Convert.ToInt32(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Sid)?.Value),
                    IdRolNavigation = new Rol { NameRol = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value }
                };

                return user;
            }
            return null;
        }
    }
}
