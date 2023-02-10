using LibreriaBlog.Interfaces;
using LibreriaBlog.Models;
using ServicioBlog.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioBlog.Implementaciones
{
    public class CommentServicio: ICommentServicio
    {
        readonly IAccesoDatos commentRepositorio;

        public CommentServicio(IAccesoDatos postRepositorioIn)
        {
            commentRepositorio = postRepositorioIn;
        }
        public Comment CommentCreate(Comment comment)
        {
            return commentRepositorio.CommentCreate(comment);
        }

        public IEnumerable<Comment> CommentGetByPost(int? userId, User user)
        {
            return commentRepositorio.CommentGetByPost(userId, user);
        }
    }
}
