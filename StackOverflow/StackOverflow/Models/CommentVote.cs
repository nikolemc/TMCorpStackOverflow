using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflow.Models
{
    public class CommentVote
    {
        public int Id { get; set; }
        public int VoteValue { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public int CommentId { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }

        public bool IsAllowedToVote { get; set; } = true;

    }
}