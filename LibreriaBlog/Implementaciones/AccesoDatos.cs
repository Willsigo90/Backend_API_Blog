using LibreriaBlog.Interfaces;
using LibreriaBlog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LibreriaBlog.Implementaciones
{
    public class AccesoDatos : IAccesoDatos
    {

        private readonly ZEMOGA_TESTContext _context;

        public AccesoDatos(ZEMOGA_TESTContext context)
        {
            _context = context;
        }

        public IList<Post> GetPublishedPost()
        {
            var result = _context.Posts
                .AsNoTracking()
                .AsQueryable()
                .Include(u => u.StatePostNavigation)
                .Include(u => u.IdUserNavigation)
                .Where(u => u.StatePost == 3)
                .ToList();
            return result;
        }

        public IList<Post> GetPostByUser(int? userId)
        {

            var result = _context.Posts
                .AsNoTracking()
                .AsQueryable()
                .Include(u => u.StatePostNavigation)
                .Where(item => item.IdUser == (userId)).ToList();

            var comments = _context.Comments
                .AsNoTracking()
                .AsQueryable().ToList();

            return result;
        }

        public Post PostCreate(Post post)
        {
            if (post != null)
            {
                post.StatePost = 1;
                _context.Add(post);
                _context.SaveChanges();
            }
            return post;
        }

        public Post PostEdit(Post post)
        {
            var postR = new Models.Post();
            postR = _context.Posts
                .AsNoTracking()
                .AsQueryable()
                .Include(u => u.StatePostNavigation)
                .Where(item => item.IdPost == (post.IdPost)).FirstOrDefault();

            if (postR.StatePost == 2 || postR.StatePost == 3)
            {
                throw new InvalidOperationException("No se puede editar un post en estado Pending Approval o Published");
                
            }

            if (postR != null)
            {
                try
                {
                    _context.Attach(post);
                    if (post.Title != null) { 
                        _context.Entry(post).Property(x => x.Title).IsModified = true; 
                    }
                    if (post.ContentText != null) { 
                        _context.Entry(post).Property(x => x.ContentText).IsModified = true; 
                    }
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.IdPost))
                    {
                        return post;
                    }
                    else
                    {
                        throw;
                    }
                }


            }
            var result = _context.Posts
                .AsNoTracking()
                .AsQueryable()
                .Include(u => u.StatePostNavigation)
                .Where(u => u.IdPost == post.IdPost)
                .FirstOrDefault();

            return result;
        }
        
        public Post PostSubmit(Post postI)
        {
            var post = _context.Posts
               .FirstOrDefault(m => m.IdPost == postI.IdPost);

            if (post == null || (post.StatePost != 1))
            {
                throw new InvalidOperationException("Solo se pueden enviar post que estan en estado de creacion");
            }
            else
            {
                try
                {
                    post.StatePost = 2;

                    _context.Attach(post);
                    _context.Entry(post).Property(x => x.StatePost).IsModified = true;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.IdPost))
                    {
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            var result = _context.Posts
                  .AsNoTracking()
                  .AsQueryable()
                  .Include(u => u.StatePostNavigation)
                  .Where(u => u.IdPost == postI.IdPost)
                  .FirstOrDefault();

            return result;
        }
        
        public IList<Post> PendingPosts()
        {
            var result = _context.Posts
                .AsNoTracking()
                .AsQueryable()
                .Include(u => u.StatePostNavigation)
                .Include(u => u.IdUserNavigation)
                .Where(item => item.StatePost == (2)).ToList();

            return result;
        }

        public Post PostAprove(Post post)
        {
            var postC = _context.Posts
                .FirstOrDefault(m => m.IdPost == post.IdPost);

            if (postC.StatePost != 2)
            {
                throw new InvalidOperationException("No se puede aprovar un post que no está en Pending Approval");
            }

            post.PublicationDate = DateTime.Now;

            if (postC == null)
            {
                //return NotFound();
                return null;
            }
            else
            {
                try
                {
                    postC.StatePost = 3;

                    _context.Attach(postC);
                    _context.Entry(postC).Property(x => x.StatePost).IsModified = true;
                    _context.Entry(postC).Property(x => x.PublicationDate).IsModified = true;
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(postC.IdPost))
                    {
                        //return NotFound();
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            var postR = _context.Posts
            .FirstOrDefault(m => m.IdPost == post.IdPost);

            return postR;
        }
        public Post PostReject(Post post)
        {
            var postC = _context.Posts
            .FirstOrDefault(m => m.IdPost == post.IdPost);

            var comment = new Models.Comment();

            var commentValue = post.Comments.FirstOrDefault();

            if (postC == null)
            {
                return null;
                //return NotFound();
            }
            else
            {
                try
                {
                    postC.StatePost = 4;
                    _context.Attach(postC);
                    _context.Entry(postC).Property(x => x.StatePost).IsModified = true;
                    _context.SaveChanges();

                    if (commentValue != null)
                    {
                        comment.TextComment = commentValue.TextComment;
                        comment.IdUser = commentValue.IdUser;
                        comment.IdPost = post.IdPost;
                        comment.CommentType = 2;
                        _context.Add(comment);
                        _context.SaveChangesAsync();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(postC.IdPost))
                    {
                        return null;
                        //return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return postC;
        }

        public Comment CommentCreate(Comment comment)
        {

            //var comment = new Comment();

            //var currentUser = GetCurrentUser();
            //comment.IdUser = currentUser.IdUser;
            comment.CommentType = 1;
            comment.IdUser = comment.IdUser;

            var post = new Post();

            post = _context.Posts
                .Where(item => item.IdPost == (comment.IdPost)).FirstOrDefault();

            if (post.StatePost != 3)
            {
                throw new InvalidOperationException("No se puede añadir comentario a un post que no se ha publicado");
            }

                _context.Add(comment);
                _context.SaveChanges();

            return comment;
        }

        public IList<Comment> CommentGetByPost(int? postId, User user)
        {

            var result = new List<Comment>();

            if (user.IdRolNavigation.NameRol == "Writer")
            {
                result = _context.Comments
                    .AsNoTracking()
                    .AsQueryable()
                    .Include(u => u.IdPostNavigation)
                    .Include(u => u.CommentTypeNavigation)
                    .Include(u => u.IdUserNavigation)
                    .Where(item => item.IdPost == (postId)).ToList();
            }
            else
            {
                result = _context.Comments
                    .AsNoTracking()
                    .AsQueryable()
                    .Include(u => u.IdPostNavigation)
                    .Include(u => u.CommentTypeNavigation)
                    .Include(u => u.IdUserNavigation)
                    .Where(item => item.IdPost == (postId) && item.CommentType == 1).ToList();
            }

            return result;
        }

        public User Login(User userLogin)
        {
            var user = _context.Users
                .Include(u => u.IdRolNavigation)
                .FirstOrDefault(m => m.UserName == userLogin.UserName && m.Password == userLogin.Password);

            return user;
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.IdPost == id);
        }

    }
}
