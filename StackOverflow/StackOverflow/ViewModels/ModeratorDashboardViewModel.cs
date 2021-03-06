﻿using StackOverflow.Models;
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

        public List<ApplicationUser> MyUsers { get; set; }
        
        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}