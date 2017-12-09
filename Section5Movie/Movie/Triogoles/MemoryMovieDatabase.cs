//Cole Miller
//MemoryMovieDatabase
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Triogoles
{
  public  class MemoryMovieDatabase : MovieDatabase
    {
        protected override Titles AddCore(Titles title)
        {
            var newtitle = CopyTitle(title);
            _titles.Add(newtitle);

            if (newtitle.Id <= 0)
                newtitle.Id = _nextId++;
            else if (newtitle.Id >= _nextId)
                _nextId = newtitle.Id + 1;

            return CopyTitle(newtitle);
        }

        protected override Titles GetCore(int id)
        {
            var title = FindTitle(id);

            return (title != null) ? CopyTitle(title) : throw new Exception("Movie was not saved last");
        }

        protected override IEnumerable<Titles> GetAllCore()
        {
            return from item in _titles
            select CopyTitle(item); 
        }

        protected override void RemoveCore(int id)
        {
            var title = FindTitle(id);
            if (title != null)
                _titles.Remove(title); 
        }

        protected override Titles UpdateCore(Titles existing, Titles title)
        {
            existing = FindTitle(title.Id);
            _titles.Remove(existing);

            var newTitle = CopyTitle(title);
                _titles.Add(newTitle);

            return CopyTitle(newTitle); 
        }

        private Titles CopyTitle(Titles title)
        {
            if (title == null)
                return null;

            var newTitle = new Titles()
            {
                Id = title.Id,
                Title = title.Title,
                Episode = title.Episode,
                Time = title.Time,
                Own = title.Own
              };

            return newTitle; 
        }
        

        private Titles FindTitle(int id)
        {
            return (from title in _titles
                    where title.Id == id
                    select title).FirstOrDefault(); 
        }

        private List<Titles> _titles = new List<Titles>();
        private int _nextId = 1; 
    }
}
