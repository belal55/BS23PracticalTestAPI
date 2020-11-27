using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Vote:BaseEntity
    {
        [Required]
        public bool IsLiked { get; set; }
        public int CommentId { get; set; }
        [ForeignKey("CommentId")]
        public Comment comment { get; set; }

    }
}
