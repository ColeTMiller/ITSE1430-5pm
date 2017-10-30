using System;
using System.Collections.Generic;
using System.Text;

namespace IMovieDatabase.Movielists
{
    public class MemoryMovieDatabase : MovieDatabase
    {
        protected override Movie AddCore(Movie movie)
        {
            var newMovie = CopyMovie(movie);
            _movie.Add(newMovie);

            if (newMovie.Id <= 0)
                newMovie.Id = _nextId++;
            else if (newMovie.Id >= _nextId)
                _nextId = newMovie.Id + 1;

            return CopyMovie(newMovie);
        }

        protected override IEnumerable<Movie> GetAllCore()
        {
            foreach (var movie in _movie)
                yield return CopyMovie(movie); 

        }

        protected override void RemoveCore (int id)
        {
            var movie = FindMovie(id);
            if (movie != null)
                _movie.Remove(movie); 
        }

        protected override Movie UpdateCore (Movie existing, Movie movie)
        {
            //Replace the newest information on the movie 
            existing = FindMovie(movie.Id);
            _movie.Remove(existing);

            var newMovie = CopyMovie(movie);
            _movie.Add(newMovie);

            return CopyMovie(newMovie); 
        }

        private Movie CopyMovie ( Movie movie)
        {
            if (movie == null)
                return null;

            var newMovie = new Movie();
            newMovie.Id = movie.Id;
            newMovie.Title = movie.Title;
            newMovie.Episode = movie.Episode;
            newMovie.Time = movie.Time;
            newMovie.Own = movie.Own;

            return newMovie; 


        }

        private Movie FindMovie( int id)
        {
            foreach (var movie in _movie)
            {
                if (movie.Id == id)
                    return movie; 
            };

            return null; 
        }

        protected override Movie GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        private List<Movie> _movie = new List<Movie>();
        private int _nextId = 1; 
    }
}
