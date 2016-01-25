using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarkdownManager.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Text { get; set; }
        public string ParentFolder { get; set; }

        // foreign key
        public virtual string ApplicationUserID { get; set; }

        public virtual MyUser User { get; set; }
    }
}