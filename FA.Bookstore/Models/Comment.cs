using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.Bookstore.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDat { get; set; }
        public bool IsActive { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        
    }
}