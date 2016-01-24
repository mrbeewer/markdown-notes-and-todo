using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkdownManager.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string ParentFolder { get; set; }

        public virtual MyUser User { get; set; }
    }
}