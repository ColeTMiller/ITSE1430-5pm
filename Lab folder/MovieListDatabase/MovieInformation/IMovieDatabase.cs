using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformation
{
    /// <summary>
    /// Provides a database of <see cref="Movie"/> Items. 
    /// </summary>
    class IMovieDatabase
    {
        /// <summary>
        /// Adds a movie.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Movie Add( Movie movie );

        /// <summary>
        /// Get  a specific product 
        /// </summary>
        /// <returns></returns>
        Movie Get( int id );

        /// <summary>
        ///  Gets all movie 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Movie> GetAll();

        /// <summary>
        /// removes the product 
        /// </summary>
        /// <param name="id"></param>
        void Remove( int id );

        /// <summary>
        /// updates a product.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Movie Update( Movie movie ); 
    }
}
