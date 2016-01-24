using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkdownManager.Models
{
    public class MyUser : IdentityUser
    {
        public bool DarkTheme { get; set; }
        public string CodeCSS { get; set; }
        public string FolderJSON { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<ToDo> ToDos { get; set; }
       // public static MyUser User { get; internal set; }
    }
}