using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieX.Models.Repositories
{
    public class MoviesRepository
    {
        private static readonly List<Movie> _movies = new List<Movie>();

        public IEnumerable<Movie> GetMovies()
        {
            return _movies;
        }

        public Movie FindById(int id)
        {
            return _movies.SingleOrDefault(i => i.Id == id);
        }

        public void Add(Movie movie)
        {
            int newId = _movies.Max(i => i.Id) + 1;
            movie.Id = newId;
            _movies.Add(movie);
        }

        public bool Delete(int id)
        {
            Movie movie = FindById(id);

            return _movies.Remove(movie);
        }

        public IEnumerable<Movie> SearchMovies(string searchTerm)
        {
            List<Movie> movies = new List<Movie>();
            using (var db = new ApplicationDbContext())
            {
                movies = db.Movies
                    .Include("Title")
                    .Where(movie => movie.Title.Contains(searchTerm)).ToList();
            }
            return movies;
        }
    }
}