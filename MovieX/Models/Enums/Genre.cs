using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieX.Models.Enums
{
    public enum Genre
    {
        Action,
        Anime,
        [Display(Name = "Award Winning")]
        AwardWinning,
        [Display(Name = "Children & Family")] Children_and_Family,
        Classics,
        Comedies,
        Crime,
        Documentaries,
        Dramas,
        [Display(Name = "European Movies")]
        EuropeanMovies,
        Holidays,
        Horror,
        Independent,
        Musicals,
        Romance,
        [Display(Name = "Sci-Fi & Fantasy")]
        Sci_Fi_and_Fantasy,
        Sports,
        [Display(Name = "Stand-Up Comdedy")]
        Stand_Up_Comedy,
        Thrillers
    }
}