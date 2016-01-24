using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkdownManager.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public string Tag { get; set; }
        public string UserID { get; set; }

        // foreign key
        public virtual string ApplicationUserID { get; set; }

        public virtual MyUser User { get; set; }
    }
}