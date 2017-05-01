using StackOverflow.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace StackOverflow.ViewModels
{
    public class SearchViewModel
    {
        public int Id { get; set; }
        public ICollection<Post> PostResults { get; set; }
        public string searchKeyWord { get; set; }

    }
}