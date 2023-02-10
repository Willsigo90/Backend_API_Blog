using LibreriaBlog.Interfaces;
using LibreriaBlog.Models;
using ServicioBlog.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioBlog.Implementaciones
{
    public class LoginServicio : ILoginServicio
    {
        readonly IAccesoDatos loginRepositorio;

        public LoginServicio(IAccesoDatos loginRepositorioIn)
        {
            loginRepositorio = loginRepositorioIn;
        }
        public User ValidateLogin(User user)
        {
            return loginRepositorio.Login(user);
        }
    }
}
