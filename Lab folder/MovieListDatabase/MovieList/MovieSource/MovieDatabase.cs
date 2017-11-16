using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieList.MovieSource
{
    class MovieDatabase : IMovieDatabase
    {
        public MovieDetail Add (MovieDetail moviedetail)
        {
            if (moviedetail == null)
                return null;

            if (!ObjectValidatorcs.TryValidate(moviedetail, out var errors))
                return null;

            return AddCore(moviedetail); 
        }
        public MovieDetail Get (int id)
        {
            if (id <= 0)
                return null;

            return GetCore(id); 
        }

        public IEnumerable<MovieDetail> GetAll()
        {
            return GetAllCore(); 
        }

        public Remove (int id )
        {
            if (id <= 0)
                return;

            RemoveCore(id);
        }

        public MovieDetail Update (MovieDetail moviedetail)
        {
            if (moviedetail == null)
                return null;
            if (!ObjectValidatorcs.TryValidate(moviedetail, out var errors))
                return null;

            var existing = GetCore(moviedetail.Id);
            if (existing == null)
                return null;

            return UpdateCore(existing, moviedetail); 
        }
        /// <summary>Adds a movie. </summary>
        /// <param name="moviedetail"></param>
        /// <returns> the added product. </returns>
        protected abstract MovieDetail AddCore( MovieDetail moviedetail );
        /// <summary>Get a Movie given its ID.</summary>
        /// <param name="id"></param>
        /// <returns>the product, if any </returns>
        protected abstract MovieDetail GetCore( MovieDetail int id );

        protected abstract IEnumerable<MovieDetail> GetAllCore();

        /// <summary>Removes a product given its ID. </summary>
        /// <param name="id">The ID.</param>
        protected abstract void RemoveCore( int id );
        /// <summary> updates a movie.</summary>
        /// <param name="existing"></param>
        /// <param name="newItem"></param>
        /// <returns>updates a movie</returns>
        protected abstract MemoryProductDatabase UpdateCore( MovieDetail existing, MovieDetail newItem ); 

    }
}
