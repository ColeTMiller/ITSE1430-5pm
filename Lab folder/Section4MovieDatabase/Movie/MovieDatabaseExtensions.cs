using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    public static class MovieDatabaseExtensions
    {
        public static Movie GetByTitle(this IMovieDatabase source, string title)
        {
            foreach(var item in source.GetAll())
            {
                if (String.Compare(item.Title, title, true) == 0)
                    return item; 
            };

            return null; 
        }

        public static IEnumerable<Movie> GetMoviesByOwn(this IMovieDatabase source, Func<Movie, decimal> timeCalculator)
        {
            var movies = from movie in source.GetAll()
                        where movie.Own
                        select new
                        {
                            Movie = movie,
                            AdjustedMovie = movie.Own ? timeCalculator(movie) : movie.Time
                        };

            return from movie in movies
                   orderby movie.AdjustedMovie
                   select movie.Movie; 
        }
    }
}
