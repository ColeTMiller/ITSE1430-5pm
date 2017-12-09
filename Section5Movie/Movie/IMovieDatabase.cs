//Cole Miller
//IMovieDatabase
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    /// <summary>Movies a databse of  <see cref="Titles"/>items</summary>
  public   interface  IMovieDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param >
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref title = "movie"/> is null</exception>
        /// <exception cref="ValidationException"><paramref name="movie"/> is invalid</exception>
        Titles Add (Titles movie);
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><param name="id">must be or greater than or equal to 0</param></exception>
        /// <returns></returns>
        Titles Get(int id);
        /// <summary>
        /// Gets all movies
        /// </summary>
        /// <returns> the movies.></returns>
      IEnumerable<Titles> GetAll();

        /// <summary>
        /// 
        /// </summary>
        ///<exception cref="ArgumentOutOfRangeException"><param name="id"></param> Must be greater than or equal to 0 </exception>
        void Remove(int id);

        /// <summary>
        /// Updates a product 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>the updated movie</returns>
        /// <exception cref="ArugmentNullException"><paramref name="movie"/></exception>
        /// <excpeiton cref ="ValidationException"><paramref name="movie"/>is invalid</excpeiton>
        /// <exception cref="Exception">Movie not found </exception>
        Titles Update(Titles movie); 
       
    }
}
