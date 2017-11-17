using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie
{
    public static class ObjectValidator
    {
        /// <summary>
        /// the value to validate 
        /// </summary>
        /// <param name="value">the value to validate</param>
        /// <param name="errors">the list of errors</param>
        /// <returns>true if validation succeded ro false otherwise </returns>
        public static bool TryValidate(IValidatableObject value, out IEnumerable<ValidationResult> errors)
        {
            var context = new ValidationContext(value);
            var results = new List<ValidationResult>();

            errors = results;
            return ObjectValidator.TryValidateObject(value, context, results);
        }

        public static void Validate (IValidatableObject value)
        {
            ObjectValidator.ValidateObject(value, new ValidationContext(value)); 
        }
    }
}
