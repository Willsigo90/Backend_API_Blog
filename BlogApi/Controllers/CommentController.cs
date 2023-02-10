using LibreriaBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ServicioBlog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {


        private readonly ICommentServicio commentServicio;

        public CommentController(ICommentServicio commentServicioIn)
        {
            commentServicio = commentServicioIn;
        }

        [HttpPost("CreateComent")]
        [Authorize(Roles = "Public, Writer, Editor")]
        public IActionResult PostComent([FromBody] Comment comment)
        {
            //var comment = new Comment();
            #region OLD
            //var currentUser = GetCurrentUser();
            //comment.IdUser = currentUser.IdUser;
            //comment.CommentType = 1;

            //var post = new Post();

            //post = _context.Post
            //    .Where(item => item.IdPost == (comment.IdPost)).FirstOrDefault();

            //if(post.StatePost != 3)
            //{
            //    return Ok("No se puede añadir comentario a un post que no se ha publicado");
            //}

            //if (ModelState.IsValid)
            //{
            //    _context.Add(comment);
            //    _context.SaveChanges();
            //}
            //return Ok(comment); 
            #endregion

            var result = commentServicio.CommentCreate(comment);
            return Ok(result);
        }

        [HttpGet("CommentsByPost")]
        [Authorize(Roles = "Public, Writer, Editor")]
        // GET: Posts by User
        public IActionResult GetCommentsByPost(int? postId)
        {
            var currentUser = GetCurrentUser();

            #region OLD
            //var result = new List<Comment>();

            //if (currentUser.IdRolNavigation.NameRol == "Writer")
            //{
            //    result = _context.Comment
            //        .AsNoTracking()
            //        .AsQueryable()
            //        .Include(u => u.IdPostNavigation)
            //        .Where(item => item.IdPost == (postId)).ToList();
            //}
            //else
            //{
            //    result = _context.Comment
            //        .AsNoTracking()
            //        .AsQueryable()
            //        .Include(u => u.IdPostNavigation)
            //        .Where(item => item.IdPost == (postId) && item.CommentType == 1).ToList();
            //} 
            #endregion

            var result = commentServicio.CommentGetByPost(postId, currentUser);
            return Ok(result);

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
