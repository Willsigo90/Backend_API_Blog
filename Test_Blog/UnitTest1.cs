using LibreriaBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Test_Blog;
using JwtApp.Controllers;
using ServicioBlog.Interfaces;
using ServicioBlog.Implementaciones;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Test_Blog
{
    public class UnitTest1
    {
        [Fact]
        public void Generate_ReturnsValidJwtToken()
        {
            // Arrange
            User user = new User
            {
                IdUser = 1,
                UserName = "Test",
                IdRolNavigation = new Rol { NameRol = "Admin" }
            };

            var config = new ConfigurationBuilder().AddInMemoryCollection(
                new Dictionary<string, string>
                {
                {"Jwt:Key", "DhftOS5uphK3vmCJQrexST1RsyjZBjXWRgJMFPU4"},
                {"Jwt:Issuer", "https://localhost:44381/"},
                {"Jwt:Audience", "https://localhost:44381/"}
                }).Build();

            LoginController loginController = new LoginController(config, null);

            // Act
            string token = loginController.Generate(user);

            // Assert
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadToken(token) as JwtSecurityToken;
            var userId = jwt.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Sid)?.Value;
            var userName = jwt.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value;
            var userRole = jwt.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value;

            Assert.Equal("1", userId);
            Assert.Equal("Test", userName);
            Assert.Equal("Admin", userRole);

        }
    }
}
