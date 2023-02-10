
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
using LibreriaBlog.Models;


namespace JwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostServicio postServicio;
        //private readonly ZEMOGA_TESTContext _context;

        public PostController(ZEMOGA_TESTContext context, IPostServicio postServicioIn)
        {
            //_context = context;
            postServicio = postServicioIn;
        }

        [HttpGet("PublishedPost")]
        [Authorize(Roles = "Public, Writer, Editor")]
        public IActionResult GetPublishedPost()
        {
            #region OLD
            //var result = _context.Post
            //    .AsNoTracking()
            //    .AsQueryable()
            //    .Include(u => u.StatePostNavigation)
            //    .Include(u => u.IdUserNavigation)
            //    .Where(u => u.StatePost == 3)
            //    .ToList(); 
            #endregion
            var result = postServicio.GetPublishedPost();
            return Ok(result);
        }

        [HttpGet("PostsByUser")]
        // GET: Posts by User
        [Authorize(Roles = "Writer")]
        public IActionResult GetPostByUser(int? userId)
        {

            #region OLD
            //var result = _context.Post
            //    .AsNoTracking()
            //    .AsQueryable()
            //    .Include(u => u.StatePostNavigation)
            //    .Where(item => item.IdUser == (userId)).ToList();

            //var comments = _context.Comment
            //    .AsNoTracking()
            //    .AsQueryable().ToList();

            #endregion
            var result = postServicio.GetPostByUser(userId);
            return Ok(result);
        }

        // POST: Posts/Create
        [HttpPost("CreatePost")]
        [Authorize(Roles = "Writer")]
        public IActionResult PostCreate([FromBody] Post post)
        {
            //if (ModelState.IsValid)
            //{
                #region OLD
                //var IdUserClaim = User.Claims.FirstOrDefault(x => x.Type.Equals("id", StringComparison.InvariantCultureIgnoreCase));

                //post.StatePost = 1;
                //_context.Add(post);
                //_context.SaveChanges(); 
                #endregion
                var result = postServicio.PostCreate(post);
                return Ok(result);
            //}
            
        }

        [HttpPost("EditPost")]
        [Authorize(Roles = "Writer")]
        public IActionResult Edit([FromBody] Post post)
        {
            #region OLD
            //var postR = new Models.Post();
            //postR = _context.Post
            //    .AsNoTracking()
            //    .AsQueryable()
            //    .Include(u => u.StatePostNavigation)
            //    .Where(item => item.IdPost == (post.IdPost)).FirstOrDefault();

            //if (postR.StatePost == 2 || postR.StatePost == 3)
            //{
            //    return Ok("No se puede editar un post en estado Pending Approval o Published");
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Attach(post);
            //        _context.Entry(post).Property(x => x.Title).IsModified = true;
            //        _context.Entry(post).Property(x => x.ContentText).IsModified = true;
            //        _context.SaveChanges();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!PostExists(post.IdPost))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //} 
            #endregion
            var result =  postServicio.PostEdit(post);
            return Ok(result);
        }

        [HttpPost("SubmitPost")]
        [Authorize(Roles = "Writer")]
        public IActionResult Submit([FromBody] Post postI)
        {
            #region OLD
            //var post = _context.Post
            //    .FirstOrDefault(m => m.IdPost == postI.IdPost);

            //if (post == null || (post.StatePost != 1))
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    try
            //    {
            //        post.StatePost = 2;

            //        _context.Attach(post);
            //        _context.Entry(post).Property(x => x.StatePost).IsModified = true;
            //        _context.SaveChanges();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!PostExists(post.IdPost))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //}
            //return Ok("Se ha realizado el submit del post"); 
            #endregion
            var result = postServicio.PostSubmit(postI);

            return Ok(result);
        }

        // GET: Posts by User
        [HttpGet("PendingPosts")]
        [Authorize(Roles = "Editor")]
        public IActionResult GetPendingPost()
        {
            #region OLD
            //var result = _context.Post
            //    .AsNoTracking()
            //    .AsQueryable()
            //    .Include(u => u.StatePostNavigation)
            //    .Include(u => u.IdUserNavigation)
            //    .Where(item => item.StatePost == (2)).ToList();

            //return Ok(result); 
            #endregion
            var result = postServicio.PendingPosts();
            return Ok(result);
        }

        
        [HttpPost("Aprove")]
        [Authorize(Roles = "Editor")]
        public IActionResult AprovePost([FromBody] Post post)
        {
            #region OLD
            //var postC =_context.Post
            //   .FirstOrDefault(m => m.IdPost == post.IdPost);

            //if(postC.StatePost != 2)
            //{
            //    return Ok("No se puede aprovar un post que no está en Pending Approval");
            //}

            //post.PublicationDate = DateTime.Now;

            //if (postC == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    try
            //    {
            //        postC.StatePost = 3;

            //        _context.Attach(postC);
            //        _context.Entry(postC).Property(x => x.StatePost).IsModified = true;
            //        _context.Entry(postC).Property(x => x.PublicationDate).IsModified = true;
            //        _context.SaveChanges();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!PostExists(postC.IdPost))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //}
            //var postR = _context.Post
            //.FirstOrDefault(m => m.IdPost == post.IdPost);

            //return Ok(postR); 
            #endregion
            var result = postServicio.PostAprove(post);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("Reject")]
        [Authorize(Roles = "Editor")]
        public IActionResult RejectPost([FromBody] Post post)
        {
            #region OLD
            //var postC = _context.Post
            //   .FirstOrDefault(m => m.IdPost == post.IdPost);

            //var comment = new Models.Comment();

            //var commentValue = post.Comments.FirstOrDefault();

            //if (postC == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    try
            //    {
            //        postC.StatePost = 4;
            //        _context.Attach(postC);
            //        _context.Entry(postC).Property(x => x.StatePost).IsModified = true;
            //        _context.SaveChanges();

            //        comment.TextComment = commentValue.TextComment;
            //        comment.IdUser = commentValue.IdUser;
            //        comment.IdPost = post.IdPost;
            //        comment.CommentType = 2;
            //        _context.Add(comment);
            //        _context.SaveChangesAsync();


            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!PostExists(postC.IdPost))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //}


            //return Ok("Se ha realizado la accion de forma exitosa"); 
            #endregion
            var result = postServicio.PostReject(post);
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

        //private bool PostExists(int id)
        //{
        //    return _context.Post.Any(e => e.IdPost == id);
        //}


    }
}
