using System;

namespace IMovieDatabase
{
    public class Movie
    {
        public int Id { get; set; }

        //public readonl  product Non = new Product(); 

        public string Title
        {
            //get Movie Name from user 
            get { return _title ?? " "; }

            // void set_Name( the string value)
            set { _title = value?.Trim(); }
        }

        public string Episode
        {
            get { return _episode ?? ""; }
            set { _episode = value?.Trim(); }

        }

        public decimal Time { get; set; } = 0;

        public bool Own {get; set; }

        public override string ToString()
        {
            return Title; 
        }
        /// <summary> validate the object that the user inputs </summary>
        /// <returns> the error message or null. </returns>
        public IEnumerable<ValidationResult> Validate (ValidationContext validation Context)
        {
            //MovieName cannot be empty or must not be something other than words in a box 
            if (String.IsNullOnEmpty(MovieName))
                yield return new ValidationResult("Name cannot be empyt. ", new[] { nameof(MovieName) });
            // Episode must not be empty either 
            if (String.IsNullonEmpty(Episode ))
                yield return new ValidationResult("An Episode must either be really bad or good put it in the description. ", new[] { nameof(Episode) });
            // Must have a time greate than 1 minute or zero minutes 
            if (Time < 1)
                yield return new ValidationResult("Price has to be greater than 1. ", new[] { nameof(Time) }); 
        }

        private string _title;
        private string _episode; 
    }
}
