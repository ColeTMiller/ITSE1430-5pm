using System;
using System.IO; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Films
{
    public  class FileMovieDatabase : MemoryMovieDatabase 
    {
        public FileMovieDatabase (string filename)
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException("Filename cannot be empty:", nameof(filename));

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

        protected override Movie UpdateCore(Movie existing, Movie movie)
        {
            var newMovie = base.UpdateCore(existing, movie);
            SaveFile(_filename);

            return newMovie; 
        }

        private void LoadFile(string filename)
        {
            if (!File.Exists(filename))
                return; 
            foreach(var line in lines)
            {
                if (String.IsNullOrEmpty(line))
                    continue;

                var fields = line.Splite(';');
                var movie = new Movie()
                {
                    Id = Int32.Parse(fields[0]),
                    Title = fields[1],
                    Episode = fields[2],
                    Time = Decimal.Parse(fields[3]),
                    Own = Boolean.Parse(fields[4])
                };

                base.AddCore(movie); 
            }
        }

        private void SaveFile(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                foreach(var movie in GetAllCore())
                {
                    var row = String.Join(",", movie.Id, movie.Title, movie.Episode, movie.Time, movie.Own);

                    writer.WriteLine(row);
                };
            };
        }


        private readonly string _filename; 
    }
}
