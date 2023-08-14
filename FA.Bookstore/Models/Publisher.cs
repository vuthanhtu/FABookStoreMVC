using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FA.Bookstore.Models
{
    public class Publisher
    {
        [Key]
        public int PubId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}