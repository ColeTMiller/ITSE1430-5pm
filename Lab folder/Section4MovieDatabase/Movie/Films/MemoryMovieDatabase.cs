using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Films
{
    /// <summary>
    /// Provides an implementation of <see cref="IMovieDatabase"/> using a memory collection 
    /// </summary>
    public class MemoryMovieDatabase : MoveDatabase
    {
        protected override Movie AddCore(Movie movie)
        {
            var newMovie = CopyMovie(movie);
            _movies.Add(newMovie);

            if (newMovie.Id <= 0)
                newMovie.Id = _nextId++;
            else if (newMovie.Id >= _nextId)
                _nextId = newMovie.Id + 1;

            return CopyMovie(newMovie); 
        }

        protected override Movie GetCore(int id)
        {
            var movie = FindMovie(id);

            return (movie != null) ? CopyMovie(movie) : throw new Exception("Movie not in selection. "); 
        }

        protected override IEnumerable<Movie> GetAllCore()
        {
            return from item in _movies
                   select CopyMovie(item); 
        }

        protected override void RemoveCore( int id)
        {
            var movie = FindMovie(id);
            if (movie != null)
                _movies.Remove(movie);
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

        protected override Movie UpdateCore(Movie existing, Movie newitem)
        {
            existing = FindMovie(movie.Id);
                _movies.Remove(existing);

            var newMovie = CopyMovie(movie);
            _movies.Add(newMovie);

            return CopyMovie(newMovie); 
        }

        private List<Movie> _movies = new List<Movie>();
        private int _nextId = 1; 
    }
}
