using System;
using System.Collections.Generic;
using System.Text;

namespace IMovieDatabase
{
    public interface IMovieDatabase
    {
        /// <summary>
        /// Addas a movie to the list 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>The addded movie in the database</returns>
        Movie Add(Movie movie);

        /// <summary>
        /// Get a specific movie and uses it 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Gets the movie, if it does exiets in this databse or its a question that you need to solve with you brain lol</returns>
        Movie Get(int id);

        /// <summary>
        /// Gets all the movies in the list 
        /// </summary>
        /// <returns>The Movie</returns>
        IEnumerable<Movie> GetAll();

        /// <summary>
        /// Removes the movie from the list 
        /// </summary>
        /// <param name="id"></param>
        void Remove(int id);

        /// <summary>
        /// Updatres a Movie or movie list
        /// </summary>
        /// <param name="movie"></param>
        /// <returns> Updates the Movie</returns>
        Movie Update(Movie movie); 
    }
}
