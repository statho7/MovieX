using MovieX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieX.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        //public IEnumerable<ApplicationUser> UsersList { get; set; }
        public bool UserPaid { get; set; }
    }
}