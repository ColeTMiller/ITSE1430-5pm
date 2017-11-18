using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Films
{
    public abstract class MoveDatabase : IMovieDatabase
    {
        public Movie Add(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "Movie was null");

            ObjectValidator.Validate(movie);

            try
            {
                return AddCore(movie);
            } catch (Exception e)
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
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "id must be > 0");

            RemoveCore(id); 
        }

        public Movie Update(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            ObjectValidator.Validate(movie);

            var existing = GetCore(movie.Id) ?? throw new Exception("Movie was not found.");

            return UpdateCore(existing, movie); 
        }

        /// <summary>
        /// Adds a movie
        /// </summary>
        /// <param name="movie">the Movie to add to the list</param>
        /// <returns>The added movie to the list</returns>
        protected abstract Movie AddCore(Movie movie);

        /// <summary>
        /// Get a movie gieven its ID.
        /// </summary>
        /// <param name="id">the ID.</param>
        /// <returns>the movie, if any.</returns>
        protected abstract Movie GetCore(int id);

       
        protected abstract IEnumerable<Movie> GetAllCore();

        /// <summary>
        ///Removies a movie given its ID.
        /// </summary>
        /// <param name="id">the Id.</param>
        protected abstract void RemoveCore(int id);

        /// <summary>
        /// updates a movie.
        /// </summary>
        /// 
        /// <param name="existing"> the xisting movie.</param>
        /// <param name="newitem">the movie to update </param>
        /// <returns>the update movie.</returns>
        protected abstract Movie UpdateCore(Movie existing, Movie newitem); 

    }
}
