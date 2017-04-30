using StackOverflow.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StackOverflow.ViewModels
{
    public class ModeratorDashboardViewModel
    {
        public int Id { get; set; }

        public ICollection<ApplicationUser> MyUsers { get; set; }
        
        public ICollection<Post> Posts { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}