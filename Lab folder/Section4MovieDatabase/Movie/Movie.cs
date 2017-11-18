using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    public class Movie : IValidatableObject
    {
        public int Id { get; set; }

        public string Title
        {
            get => _title ?? "";
            set => _title = value?.Trim();
        }

        public string Episode
        {
            get => _episode ?? "";
            set => _episode = value?.Trim();
        }

        public decimal Time { get; set; } = 0;

        public bool Own {get; set;}


        public override string ToString() => Title;
        public override string ToString() => Episode;

        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Title))
                yield return new ValidationResult("Title cannot be empyt.", new[] { nameof(Title) });

            if (String.IsNullOrEmpty(Episode))
                yield return new ValidationResult("Episode cannot be empty.", new[] { nameof(Episode) });

            if (Time < 0)
                yield return new ValidationResult("Time must be >=0.", new[] {nameof( Time)}); 
        }

        private string _title;
        private string _episode;

    }
}
