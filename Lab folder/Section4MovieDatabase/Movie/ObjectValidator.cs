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
        /// Tries to validate an object.
        /// </summary>
        /// <param name="value">the value to validate</param>
        /// <param name="errors">list of errors </param>
        /// <returns>validation succeded or false otherwise</returns>
        public static bool TryValidate( IValidatableObject value, out IEnumerable<ValidationResult> errors)
        {
            var context = new ValidationContext(value);
            var results = new List<ValidationResult>();

            errors = results;
            return Validator.TryValidateObject(value, context, results);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="Validation Exception"></exception>
        public static void Validate (IValidatableObject value)
        {
            Validator.ValidateObject(value, new ValidationContext(value)); 
        }
    }
}
