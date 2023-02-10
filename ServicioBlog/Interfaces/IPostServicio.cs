using LibreriaBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioBlog.Interfaces
{
    public interface IPostServicio
    {
        IEnumerable<Post> GetPublishedPost();

        IEnumerable<Post> GetPostByUser(int? userId);
        Post PostCreate(Post post);
        Post PostEdit(Post post);
        Post PostSubmit(Post post);
        IEnumerable<Post> PendingPosts();

        Post PostAprove(Post post);
        Post PostReject(Post post);

    }
}
