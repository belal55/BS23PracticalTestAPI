using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Post:BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Title { get; set; }
        [StringLength(500)]
        [Required]
        public string Content { get; set; }
        [StringLength(10)]
        [Required]
        public string Author { get; set; }
        public ICollection<Comment> comments { get; set; }
    }
}
