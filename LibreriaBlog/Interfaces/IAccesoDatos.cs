using LibreriaBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaBlog.Interfaces
{
    public interface IAccesoDatos
    {
        public IList<Post> GetPublishedPost();

        public IList<Post> GetPostByUser(int? userId);
        public Post PostCreate(Post post);

        public Post PostEdit(Post post);
        public Post PostSubmit(Post post);

        public IList<Post> PendingPosts();

        public Post PostAprove(Post post);

        public Post PostReject(Post post);

        public Comment CommentCreate(Comment comment);

        public IList<Comment> CommentGetByPost(int? userId, User user);

        public User Login(User user);
    }
}
