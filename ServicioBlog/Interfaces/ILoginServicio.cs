using LibreriaBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioBlog.Interfaces
{
    public interface ILoginServicio
    {
        User ValidateLogin(User user);
    }
}
