using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace FA.Bookstore.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        
        public int AuthorId { get; set; }
        [MaxLength(500)]
        public string Summary { get; set; }

        public string ImgUrl { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int CateId { get; set; }
        public virtual Category Category { get; set; }
        public int PubId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}