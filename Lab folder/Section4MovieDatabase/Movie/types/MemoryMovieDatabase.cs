using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.types
{
    /// <summary>
    /// Provides an implementation of <see cref="IMovieDatabase"/>using a  memory collection 
    /// </summary>
    class MemoryMovieDatabase : MovieDatabase
    {
        protected override Movie AddCore(Movie movie)
        {
            var newMovie = CopyMovie(movie);
            _movies.Add(newMovie);

            if (newMovie.id <= 0)
                newMovie.id = _nextid++;
            else if (newMovie.id >= _nextid)
                _nextid = newMovie.id + 1;

            return CopyMovie(newMovie); 
        }

        protected override Movie GetCore(int id)
        {
            var movie = FindMovie(id); 

            return (movie != null) ? CopyMovie(movie) : throw new Exception("Movie not in memory"); 
        }
        protected override IEnumerable <Movie> GetAllCore()
        {
            return from item in _movies
                   select CopyMovie(item); 
        }
        protected override void RemoveCore(int id)
        {
            var movie = FindMovie(id);
            if (movie != null)
                _movies.Remove(movie); 
        }
        protected override Movie UpdateCore(Movie existing, Movie movie)
        {
            existing = FindMovie(movie.id);
            _movies.Remove(existing);

            var newMovie = CopyMovie(movie);
            _movies.Add(newMovie);

            return CopyMovie(newMovie); 
        }

       private Movie CopyMovie(Movie movie)
        {
            if (movie == null)
                return null;

            var newMovie = new Movie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Episode = movie.Episode,
                Time = movie.Time,
                Own = movie.Own
            }; 

            return newMovie; 
        }

        private Movie FindMovie(int id)
        {
            return (from movie in _movies
                    where movie.Id == id
                    select movie).FirstOrDefault(); 
        }


        private List<Movie> _movies = new List<Movie>();
        private int _nextid = 1; 
    }
}
