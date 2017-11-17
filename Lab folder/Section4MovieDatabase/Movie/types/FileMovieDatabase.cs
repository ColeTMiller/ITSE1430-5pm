using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.types
{
    /// <summary>
    /// Provides an implementation of <see cref="IMovieDatabase"/>using a memory collection. 
    /// </summary>
    class FileMovieDatabase : MemoryMovieDatabase
    {
        public FileMovieDatabse(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException("Filename cannot be empyt.", nameof(filename));

            _filename = filename; 

            LoadFile(filename); 
        }

        protected override Movie AddCore(Movie movie)
        {
            var newMovie = base.AddCore(movie);

            SaveFile(_filename);

            return newMovie; 
        }

        protected override void RemoveCore(int id)
        {
            base.RemoveCore(id);

                SaveFile(_filename); 
        }
        private void LoadFile(string filename)
        {
            if (!File.Exists(filename))
                return;

            var lines = File.ReadAllLines(filename);
            foreach(var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                var fields = line.Split(';');
                var movie = new Movie()
                {
                    Id = Int32.Parse(fields[0]),
                    Title = fields[1],
                    Episode = fields[2],
                    Time = Decimal.Parse(fields[2]),
                    Own = Boolean.Parse(fields[4])
                };

                base.AddCore(movie); 
            };
        }
        protected override Movie UpdateCore(Movie existing, Movie movie)
        {
            var newMovie = base.UpdateCore(existing, movie);
            SaveFile(_filename);

            return newMovie; 
            
        }
        private void SaveFile(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                foreach (var movie in GetAllCore())
                {
                    var row = String.Join(",", movie.Id, movie.Title, movie.Episode, movie.Time, movie.Own);

                    writer.WriteLine(row); 
                }
            }
        }

        private readonly string _filename; 
    }
}
