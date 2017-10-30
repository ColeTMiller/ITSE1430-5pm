using System;
using System.Collections.Generic;
using System.Text;

namespace IMovieDatabase.Movielists
{
    public abstract class MovieDatabase : IMovieDatabase
    {
        public Movie Add (Movie movie)
        {
            if (movie == null)
                return null;

            if (!ObjectValidator.TryValidate(movie, out var errors))
                return null;

            return AddCore(movie); 
        }

        public Movie Get (int Id)
            if (id <= 0)
               return null;
            
            return GetCore(id);

        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore();
        }

        public void Remove (int id )
        {
            if (id <= 0)
                return;

            RemoveCore(id); 
        }

        public Movie Update (Movie movie)
        {
            if (movie == null)
                return movie;

            //Using ivalidatableObject 
            if (!ObjectValidator.TryValidate(movie, out var errors))
                return null;

            var existing = GetCore(movie.Id);
            if (existing == null)
                return null;

            return UpdateCore(exisitng, movie); 
        }
        protected abstract Movie GetMovie(int id);
        protected abstract IEnumerable<Movie> GetAllCore();
        protected abstract void RemoveCore(int Id);

        protected abstract Movie UpdateCore(Movie exisiting, Movie newItem);

        protected abstract Movie AddCore(Movie movie); 
    }
}
