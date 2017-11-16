using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieList
{
    public class MovieDetail : IValidatableObject 
    {
        public int Id { get; set; }

        public string Title
        {
            get { return _title ?? ""; }
            set { _title = value?.Trim(); }
        }
        public string Episode
        {
            get { return _episode ?? ""; }
            set { _episode = value?.Trim(); }
        }

        public decimal Time { get; set; } = 0; 

        public bool IsDiscontinued { get; set; }

        public override string ToString()
        {
            return Title; 
        }
        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
            //Title cannot be empty
            if (String.IsNullOrEmpty(Title))
                yield return new ValidationResult("Name cannot be empty.", new[] { nameof(Title) });

            if (Time < 1)
                yield return new ValidationResult("Time must be greater >=0.", new[] { nameof(Time) }); 
        }

        private string _title;
        private string _episode; 

    }
}
