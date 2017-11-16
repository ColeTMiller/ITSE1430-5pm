using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformation.MovieDatabase
{
    class MovieDatabase : IMovieDatabase
    {
        public Movie Add (Movie movie)
        {
            if (movie == null)
                return null;

            if (!ObjectValidator.TryValidate( movie, out var errors))
                return null;

            return AddCore(movie); 
        }

        public Movie Get (int id )
        {
            if (id <= 0)
                return null;

            return Getcore(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore(); 
        }

        public void Remove(int id)
        {
            RemoveCore(id); 
        }
        public Movie Update(Movie movie)
        {
            if (movie == null)
                return null;
            if (!ObjectValidator.TryValidate(movie, out var errors))
                return null;

            var existing = Getcore(movie.id);
            if (existing == null)
                return null;

            return UpdateCore(existing, movie); 
        }

        protected abstract Movie GetCore( int id );

        protected abstract IEnumerable<Movie> GetAllCore();

        protected abstract RemoveCore( int id );

        protected abstract Movie UpdateCore( Movie existing, Movie newItem );

        protected abstract Movie AddCore( Movie movie ); 
    }
}
