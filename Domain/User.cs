using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class User:BaseEntity
    {
        [StringLength(10)]
        [Required]
        public string UserName { get; set; }
        [StringLength(70)]
        [Required]
        public string Email { get; set; }
        [StringLength(12)]
        [Required]
        public string Password { get; set; }
        [StringLength(50)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }

        public ICollection<Comment> comments { get; set; }
    }
}
