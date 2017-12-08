using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie 
{
    public class Titles : IValidatableObject 
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

        [Obsolete("Deprecated in v1.Use something else.")]
        public decimal CalculatedProperty => 0M; 
        public decimal Time { get; set; } = 0; 

        public bool Own { get; set; }


        public override string ToString() => Title; 

        public IEnumerable<ValidationResult>Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Title))
                yield return new ValidationResult("Title cannot be empty. ", new[] { nameof(Title) });

            if (Time < 0)
                yield return new ValidationResult("Time must be >=0.", new[] { nameof(Time) }); 
        }

        private string _title;
        private string _episode; 
    }
}
