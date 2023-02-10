using ServicioBlog.Interfaces;
using System;
using System.Collections.Generic;
using LibreriaBlog.Models;
using System.Text;
using LibreriaBlog.Interfaces;

namespace ServicioBlog.Implementaciones
{
    public class PostServicio : IPostServicio
    {
        readonly IAccesoDatos postRepositorio;

        public PostServicio(IAccesoDatos postRepositorioIn)
        {
            postRepositorio = postRepositorioIn;
        }

        #region OLD

        //private readonly IPostNegocio postNegocio;
        //public PostServicio(IPostNegocio postNegocioIn)
        //{
        //    postNegocio = postNegocioIn;
        //}

        //public IEnumerable<Post> GetPostByUser(int? userId)
        //{
        //    return postNegocio.GetPostByUser(userId);
        //}

        //public IEnumerable<Post> GetPublishedPost()
        //{
        //    return postNegocio.GetPublishedPost();
        //}

        //public Post PostCreate(Post post)
        //{
        //    return postNegocio.PostCreate(post);
        //}

        //public Post Edit(Post post)
        //{
        //    return postNegocio.PostCreate(post);
        //} 
        #endregion

        public IEnumerable<Post> GetPostByUser(int? userId)
        {
            return postRepositorio.GetPostByUser(userId);
        }

        public IEnumerable<Post> GetPublishedPost()
        {
            return postRepositorio.GetPublishedPost();
        }

        public Post PostCreate(Post post)
        {
            return postRepositorio.PostCreate(post);
        }

        public Post PostEdit(Post post)
        {
            return postRepositorio.PostEdit(post);
        }
        public Post PostSubmit(Post post)
        {
            return postRepositorio.PostSubmit(post);
        }

        public IEnumerable<Post> PendingPosts()
        {
            return postRepositorio.PendingPosts();
        }
        public Post PostAprove(Post post)
        {
            return postRepositorio.PostAprove(post);
        }

        public Post PostReject(Post post)
        {
            return postRepositorio.PostReject(post);
        }

    }
}
