using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverflow.Models;

namespace StackOverflow.ViewModels
{
    public class HomePageViewModel
    {
        public ICollection<Post> Post { get; set; }

        //public ICollection<SideBanner> SideBanner { get; set; }

        //public int VoteValue { get; set; } = 0; // 1/0/-1
        //public bool IsAllowedToVote { get; set; } = false;

    }
}