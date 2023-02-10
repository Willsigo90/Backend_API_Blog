using System;
using System.Collections.Generic;

#nullable disable

namespace LibreriaBlog.Models
{
    public partial class PostState
    {
        public PostState()
        {
            Posts = new HashSet<Post>();
        }

        public int IdState { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
