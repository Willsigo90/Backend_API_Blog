using System;
using System.Collections.Generic;

#nullable disable

namespace LibreriaBlog.Models
{
    public partial class CommentType
    {
        public CommentType()
        {
            Comments = new HashSet<Comment>();
        }

        public int IdCommentType { get; set; }
        public string TypeDescription { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
