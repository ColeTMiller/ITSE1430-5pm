//Cole Miller
//MovieDatabaseExtensions.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    /// <summary>
    ///Provides extensions for  <see cref="IMovieDatabase"/>
    /// </summary>
   public static  class MoiveDatabaseExtensions
    {


        public static Titles GetByTitle(this IMovieDatabase source, string title)
        {
            foreach (var item in source.GetAll())
            {
                if (String.Compare(item.Title, title, true) == 0)
                {
                    return item;
                }
            };

            return null; 
                
         }
    }
}
