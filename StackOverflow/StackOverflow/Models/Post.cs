using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflow.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PostedTimeStamp { get; set; } = DateTime.Now;
        public ICollection<PostVote> Votes { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        

    }
}