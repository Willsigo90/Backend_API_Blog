using LibreriaBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioBlog.Interfaces
{
    public interface ICommentServicio
    {
        Comment CommentCreate(Comment comment);
        IEnumerable<Comment> CommentGetByPost(int? userId, User user);
        
    }
}
