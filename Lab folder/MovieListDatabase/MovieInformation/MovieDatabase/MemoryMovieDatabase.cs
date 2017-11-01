using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformation.MovieDatabase
{
    class MemoryMovieDatabase : MovieDatabase
    {
        protected override Movie AddCore( Movie movie )
        {
            var newMovie = CopyMovie(movie);
            _movies.Add(newMovie);

            if (newMovie.id <= 0)
                newMovie.id = _nextId++;
            else if (newMovie.id >= _nextId)
                _nextId = newMovie.id + 1;

            return CopyMovie(newMovie); 
        }
        protected override Movie GetCore( int id )
        {
            var movie = FindMovie(id);
            return (movie != null) ? CopyMovie(movie) : null; 

        }

        protected override IEnumerable<Movie> GetAllCore()
        {
            foreach (var movie in _movies)
                yield return CopyMovie(movie); 


        }

        protected override void RemoveCore(int id )
        {
            var movie = FindMovie(id);
            if (movie != null)
                _movies.Remove(movie); 
        }

        protected override Movie UpdateCore( Movie existing, Movie movie )
        {
            existing = FindMovie(movie.id);
            _movies.Remove(existing);

            var newMovie = CopyMovie(movie);
            _movies.Add(newMovie);

            return CopyMovie(newMovie); 
        }

        protected override void RemoveCore( int id )
        {
            var movie = FindMovie(id);
            if (movie != null)
                _movies.Remove(movie);
        }
        private Movie FindMovie(int id)
        {
            foreach (var movie in _movies)
            {
                if (movie.id == id)
                    return movie; 
            }

            return null; 
        }
        private Movie CopyMovie(Movie movie)
        {
            if (movie == null)
                return null;
            var newMovie = new Movie();
            newMovie.id = movie.id;
            newMovie.Title = movie.Title;
            newMovie.Episode = movie.Episode;
            newMovie.time = movie.time;
            newMovie.Own = movie.Own;

            return newMovie; 
        }
        private List<Movie> _movies = new List<Movie>();
        private int _nextId = 1; 
    }
}
