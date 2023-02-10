using System;
using System.Collections.Generic;

#nullable disable

namespace LibreriaBlog.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int IdPost { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int IdUser { get; set; }
        public int StatePost { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual PostState StatePostNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
