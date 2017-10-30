using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace IMovieDatabase
{
    public class MvieValidator
    {
        public static bool TryValidate ( IValidatableObject value, out IEnumerable<ValidationResult> errors )
        {
            var context = new ValidationContext(value);
            var results = new List<ValidationResult>();

            errors = results;
            return Validator.TryValidateObject(value, context, results); 
        }

    }
}
