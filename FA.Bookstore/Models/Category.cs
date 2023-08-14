using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FA.Bookstore.Models
{
    public class Category
    {
        [Key]
        public int CateId { get; set; }
        [Required]
        [StringLength(100)]
        public string CateName { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}