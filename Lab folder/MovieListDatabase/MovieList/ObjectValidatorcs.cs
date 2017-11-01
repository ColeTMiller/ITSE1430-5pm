using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieList
{
    public class ObjectValidatorcs
    {
        /// <summary>
        /// Tries to validate an object.
        /// </summary>
        /// <param name="value"> The value to validate.</param>
        /// <param name="errors"> the list of errors. </param>
        /// <returns> true if validation succeeded or false otherwise.</returns>
        public static bool TryValidate( IValidatableObject value, out IEnumerable<ValidationResult> errors )
        {
            var context = new ValidationContext(value);
            var results = new List<ValidationResult>();

            errors = results;
            return Validator.TryValidateObject(value, context, results);
        }
    }
}
