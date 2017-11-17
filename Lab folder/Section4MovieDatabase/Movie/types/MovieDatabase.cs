using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.types
{
    public abstract class MovieDatabase : IMovieDatabase
    {
        public Movie Add( Movie movie)
        {
            //Validate 
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "Movie was empty");

           ObjectValidator.Validate(movie); 

            try
            {
                return AddCore(movie);
            }catch(Exception e)
            {
                throw new Exception("Add failed", e);

                throw; 
            }; 
        }

        public Movie Get(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "id must be > 0");

            return GetCore(id); 
        }
        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore(); 
        }

        public void Remove(int id)
        {
            if (id <  0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0,");

            RemoveCore(id); 
        }
        public Movie Update(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            ObjectValidator.Validate(movie);

            var existing = GetCore(movie.Id) ?? throw new Exception("Movie not  found");

            return UpdateCore(existing, movie); 
        }

        protected abstract Movie AddCore(Movie movie);

        protected abstract Movie GetCore(int id);

        protected abstract IEnumerable<Movie> GetAllCore();

        protected abstract void RemoveCore(int id);

        protected abstract Movie UpdateCore(Movie existing, Movie newItem); 
    }
}
