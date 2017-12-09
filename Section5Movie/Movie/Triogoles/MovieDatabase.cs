//Cole Miller
//MovieDatabase
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Triogoles
{
    public abstract class MovieDatabase : IMovieDatabase
    {
        public Titles Add (Titles title)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title), "Title was null");

            ObjectValidator .Validate(title); 

            try
            {
                return AddCore(title); 
            }catch (Exception e)
            {
                throw new Exception("Add failed", e);

                throw; 
            };
        }
        /// <summary>
        /// 
        /// </summary>
        ///<exception cref="ArgumentOutOfRangeException"><paramref name="id"/></exception>
        /// <returns></returns>
         public Titles Get(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0");

            return GetCore(id); 
        }

        public IEnumerable<Titles> GetAll()
        {
            return GetAllCore(); 
        }

        public void Remove (int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "id must be > 0");

            RemoveCore(id); 
        }

        public Titles Update (Titles title)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            ObjectValidator.Validate(title);

            var existing = GetCore(title.Id) ?? throw new Exception("Title not found.");

            return UpdateCore(existing, title); 
        }

        protected abstract Titles AddCore(Titles title);

        protected abstract Titles GetCore(int id);

        protected abstract IEnumerable<Titles> GetAllCore();

        protected abstract void RemoveCore(int id);

        protected abstract Titles UpdateCore(Titles existing, Titles newItem); 
    }
}
