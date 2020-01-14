using MovieX.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieX.Models
{
    public class Movie
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public int NumberOfViews { get; }

        public double AverageRating { get; }

        // Its the hyperlink to the actual video's path.
        public string RootToDb { get; set; }

        // Its the hyperlink to the image's path.
        public string ImagePath { get; set; }
    }
}