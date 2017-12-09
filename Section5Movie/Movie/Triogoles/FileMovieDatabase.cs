//Cole Miller
//FileMovieDatabase
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Triogoles
{
    public class FileMovieDatabase : MemoryMovieDatabase
    {

        public FileMovieDatabase(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentNullException("Filename cannot be empyt", nameof(filename));

            _filename = filename;

            LoadFile(filename);
        }
        protected override Titles AddCore(Titles title)
        {
            var newTitle = base.AddCore(title);

            SaveFile(_filename);

            return newTitle; 
        }
        protected override void RemoveCore(int id)
        {
            base.RemoveCore(id);

            SaveFile(_filename); 
        }

        protected override Titles UpdateCore(Titles existing, Titles title)
        {
            var newTitle = base.UpdateCore(existing, title);
            SaveFile(_filename);

            return newTitle; 
        }

        private void LoadFile(string Filename)
        {
            if (!File.Exists(Filename))
                return;

            var lines = File.ReadAllLines(Filename); 
            foreach(var line in lines)
            {
                if (String.IsNullOrEmpty(line))
                    continue;

                var fields = line.Split(';');
                var title = new Titles()
                {
                    Id = Int32.Parse(fields[0]),
                    Title = fields[1],
                    Episode = fields[2],
                    Time = Decimal.Parse(fields[3]),
                    Own = Boolean.Parse(fields[4])
                };

                base.AddCore(title); 
            };

        }

        private void SaveFile(string Filename)
        {
            using (var writer = new StreamWriter(Filename))
            {
                foreach (var title in GetAllCore())
                {
                    var row = String.Join(";",
                                                                  title.Id,
                                                                  title.Title,
                                                                  title.Episode,
                                                                  title.Time,
                                                                  title.Own);

                    writer.WriteLine(row); 
                }
            }
        }

        private readonly string _filename; 


    }
}

