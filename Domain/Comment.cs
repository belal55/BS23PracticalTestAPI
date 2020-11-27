using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Comment:BaseEntity
    {
        [StringLength(250)]
        [Required]
        public string Content { get; set; }

        [StringLength(10)]
        public int UserId { get; set; }
        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public Post post { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
        public ICollection<Vote> votes { get; set; }
    }
}
