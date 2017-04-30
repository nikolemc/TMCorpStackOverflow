using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverflow.Models;

namespace StackOverflow.ViewModels
{
    public class IndividualPostViewModel
    {
        public int Id { get; set; }
        public Post Post { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}