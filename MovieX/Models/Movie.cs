using MovieX.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieX.Models
{
    public class Movie
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Display(Name = "Movie")]
        public int Id { get; set; }

        [Display(Name = "Movie")]
        public string Title { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Release Date (Year)")]
        [Range(1900,2020)]
        public int ReleaseDate { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public int NumberOfViews { get; }

        public double AverageRating { get; }

        // Its the hyperlink to the actual video's path.
        public string RootToDb { get; set; }

        public string Thumbnail { get; set; }

        [DisplayName("Upload File")]
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}