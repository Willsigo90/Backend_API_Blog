using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        //[HttpGet("Admins")]
        //[Authorize(Roles = "Administrator")]
        //public IActionResult AdminsEndpoint()
        //{
        //    var currentUser = GetCurrentUser();

        //    return Ok($"Hi {currentUser.Username}, you are an {currentUser.Role}");
        //}

        //[HttpGet("Publics")]
        //[Authorize(Roles = "Public")]
        //public IActionResult PublicEndpoint()
        //{
        //    var currentUser = GetCurrentUser();

        //    return Ok($"Hi {currentUser.Username}, you are an {currentUser.Role}, user");
        //}

        //[HttpGet("Writers")]
        //[Authorize(Roles = "Writer")]
        //public IActionResult WriterEndpoint()
        //{
        //    var currentUser = GetCurrentUser();

        //    return Ok($"Hi {currentUser.Username}, you are an {currentUser.Role}, user");
        //}

        //[HttpGet("Editors")]
        //[Authorize(Roles = "Editor")]
        //public IActionResult EditorEndpoint()
        //{
        //    var currentUser = GetCurrentUser();

        //    return Ok($"Hi {currentUser.Username}, you are an {currentUser.Role}, user");
        //}
                
        //private UserModel GetCurrentUser()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;

        //    if (identity != null)
        //    {
        //        var userClaims = identity.Claims;

        //        return new UserModel
        //        {
        //            Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
        //            EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
        //            GivenName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
        //            Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
        //            Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
        //        };
        //    }
        //    return null;
        //}
    }
}
