using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflow.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentedTimeStamp { get; set; }
        public ICollection<CommentVote> Votes { get; set; }
        public bool IsAnswered { get; set; } = false;

        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        public string UserId { get; set;  }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set;}
        
        
        
    }
}