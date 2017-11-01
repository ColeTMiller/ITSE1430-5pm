using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieList
{
    /// <summary> Provides a databe of <see cref="MovieDetail"/> Items.</summary>
    public interface IMovieDatabase
    {
        MovieDetail Add( MovieDetail moviedetail );

        MovieDetail Get( int id );

        IEnumerable<MovieDetail> GetAll();

        void Remove( int id );

        MovieDetail Update( MovieDetail moviedetail ); 
    }
}
