using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieList.MovieSource
{
    public class MemoryProductDatabase : MovieDatabase
    {
        protected override MovieDetail AddCore( MovieDetail moviedetail )
        {
            var newMovie = CopyMovie(moviedetail);
            _movies.Add(newMovie);

            if (newMovie.Id <= 0)
                newMovie.Id = _nextId++;
            else if (newMovie.Id >= _nextId)
                _nextId = newMovie.Id + 1;

            return CopyMovie(newMovie);
        }
        /// <summary>Get a specific product. </summary>
        /// <returns> the movie, if it exists. </returns>
        protected override MovieDetail GetCore( int id )
        {
            var moviedetail = FindMovie(id);

            return (moviedetail != null) ? CopyMovie(moviedetail) : null;
        }

        protected override IEnumerable<MovieDetail> GetAllCore()
        {
            foreach (var moviedetail in _movies)
                yield return CopyMovie(moviedetail);
        }

        protected override void RemoveCore( int id )
        {
            var moviedetail = FindMovie(id);
            if (moviedetail != null)
                _movies.Remove(moviedetail);
        }

        protected override MovieDetail UpdateCore( MovieDetail existing, MovieDetail moviedetail )
        {
            existing = FindMovie(moviedetail.Id);
            _movies.Remove(existing);

            var newMovie = CopyMovie(moviedetail);
            _movies.Add(newMovie);

            return CopyMovie(newMovie); 
        }

        private MovieDetail CopyMovie(MovieDetail moviedetail)
        {
            if (moviedetail == null)
                return null;

            var newMovie = new MovieDetail();
            newMovie.Id = moviedetail.Id;
            newMovie.Title = moviedetail.Title;
            newMovie.Episode = moviedetail.Episode;
            newMovie.Time = moviedetail.Time;
            newMovie.IsDiscontinued = moviedetail.IsDiscontinued;

            return newMovie; 
        }
        private MovieDetail FindMovie(int id)
        {
            foreach (var moviedetail in _movies)
            {
                if (moviedetail.Id == id)
                    return moviedetail; 
            }
            return null; 
        }

        private List<MovieDetail> _movies = new List<MovieDetail>; 
        private int _nextId = 1; 
    }
}
