using System;
using System.Collections.Generic;

#nullable disable

namespace LibreriaBlog.Models
{
    public partial class Comment
    {
        public int IdComment { get; set; }
        public string TextComment { get; set; }
        public int IdPost { get; set; }
        public int IdUser { get; set; }
        public int CommentType { get; set; }

        public virtual CommentType CommentTypeNavigation { get; set; }
        public virtual Post IdPostNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
