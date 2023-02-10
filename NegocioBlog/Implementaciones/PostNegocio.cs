using LibreriaBlog.Interfaces;
using LibreriaBlog.Models;
using NegocioBlog.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioBlog.Implementaciones
{
    public class PostNegocio : IPostNegocio
    {
        readonly IAccesoDatos postRepositorio;

        public PostNegocio(IAccesoDatos postRepositorioIn)
        {
            postRepositorio = postRepositorioIn;
        }



        public IList<Post> GetPostByUser(int? userId)
        {
            return postRepositorio.GetPostByUser(userId);
        }

        public IList<Post> GetPublishedPost()
        {
            return postRepositorio.GetPublishedPost();
        }

        public void PostCreate(Post post)
        {
            
        }

        Post IPostNegocio.PostCreate(Post post)
        {
            return postRepositorio.PostCreate(post);
        }

        public Post Edit(Post post)
        {
            return postRepositorio.PostCreate(post);
        }
    }
}
