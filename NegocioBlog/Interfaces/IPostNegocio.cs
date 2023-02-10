using LibreriaBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioBlog.Interfaces
{
    public interface IPostNegocio
    {
        public IList<Post> GetPublishedPost();

        public IList<Post> GetPostByUser(int? userId);

        public Post PostCreate(Post post);

        public Post Edit(Post post);
    }
}
