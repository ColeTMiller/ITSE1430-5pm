using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    /// <summary>Movies a databse of  <see cref="Movie"/>items
    /// </summary>
  public   interface IMovieDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param >
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref title = "movie"/> is null</exception>
        /// <exception cref="ValidationException"><paramref name="movie"/> is invalid</exception>
        Titles Add (Titles movie);

        Titles Get(int id);

        IEnumerable<Titles> GetAll();

        void Remove(int id);

        Titles Update(Titles movie); 
       
    }
}
