using System;
using System.Collections.Generic;

#nullable disable

namespace LibreriaBlog.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Users = new HashSet<User>();
        }

        public int IdRol { get; set; }
        public string NameRol { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
