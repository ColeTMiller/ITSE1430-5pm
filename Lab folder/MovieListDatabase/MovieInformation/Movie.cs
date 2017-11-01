using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformation
{
    public class Movie : IValidationObject 
    {
        public int id { get; set; }

        public string Title
        {
            get { return _title ?? "",}

            set { _title = value?.Trim(); }

        }

        public string Episode
        {
            get { return _episode ?? " "; }
            set { _episode = value?.Trim(); }
        }

        public decimal time { get; set; } = 0; 

        public bool Own { get; set; }

        public override string ToString()
        {
            return Title; 
        }

        public int[] Sizes
        {
            get
            {
                var copySizes = new int[_sizes.Length];
                Array.Copy(_sizes, copySizes, _sizes.Length);

                return copySizes; 
            }
        }

        private int[] _sizes = new int[1]; 

        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Title))
                yield return new ValidationResult("Title cannot be empyt.", new[] { nameof(Title) });

            if (String.IsNullOrEmpyt(Episode))
                yield return new ValidationResult("Episode cannot be empyt. ", new[] { nameof(Episode) });

            if (time < 1)
                yield return new ValidationResult("Time meust be >=1. ", new[] { nameof(time) }); 
        }
        private string _title;
        private string _episode; 
    }
}
