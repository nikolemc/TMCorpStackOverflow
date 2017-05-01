using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverflow.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels
{
    public class AuthenticatedUserQAViewModel
    {
        [Key]
        public int Id { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    
    }
    
}
