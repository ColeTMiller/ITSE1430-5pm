using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    public interface IMovieDatabase
    {
        /// <summary>
        /// Adds a move
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="movie"/>is null</exception>
        /// <exception cref="ValidationException"><paramref name="movie"/>is invalid</exception>
        Movie Add(Movie movie);
        /// <summary>
        /// Gets a specific movie
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><param name="id"></param></exception>
        /// <returns></returns>
        Movie Get(int id);
        /// <summary>
        /// gets all the movies 
        /// </summary>
        /// <returns> the movie </returns>
        IEnumerable<Movie> GetAll();

        /// <summary>
        /// Removes a movie 
        /// </summary>
        /// <param name="id">the movie to remove</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/>must be greater than or equat0 0l</exception>
        void Remove(int id);
        /// <summary>
        /// updates a movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="movie"/>is null</exception>
        /// <exception cref="Exception">Movie not found</exception>
        Movie Update(Movie movie);
    }
}
