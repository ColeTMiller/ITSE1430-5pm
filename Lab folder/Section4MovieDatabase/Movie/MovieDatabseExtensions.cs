using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    public static class MovieDatabseExtensions
    {
        public static Movie GetByTitle(this IMovieDatabase source, string Title)
        {
            foreach (var item in source.GetAll())
            {
                if (String.Compare(item.Title, Title, true) == 0)
                    return item;
            };

            return null; 
        }

        public static IEnumerable<Movie> GetMovieByOwn(this IMovieDatabase source, Func<Movie, decimal> TimeCalculator)
        {
            var movies = from movie in source.GetAll()
                        where movie.Own
                        select new
                        {
                            Movie = movie,
                            AdjustMovie = movie.Own? movie.Time : movie.Time
                        };

            return from movie in movies
                   orderby movie.AdjustMovie
                   select movie.Movie; 

        }
    }
}
