using MovieX.Models;
using MovieX.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieX.Controllers
{
    public class SearchController : Controller
    {
        //// GET: Search
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private readonly MoviesRepository _moviesRepository = new MoviesRepository();

        public ActionResult SearchMovie(string searchTerm)
        {
            IEnumerable<Movie> movies = null;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                movies = _moviesRepository.SearchMovies(searchTerm);
            }

            return View(movies);
        }
    }
}