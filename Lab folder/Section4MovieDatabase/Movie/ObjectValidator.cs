using System;
using System.Collections.Generic;
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
        /// <param name="value">The value to validate</param>
        /// <param name="errors">the list of errors</param>
        /// <returns></returns>
        public static bool TryValidate(IValidatableObject value, out IEnumerable<ValidationResult> errors)
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
        /// <exception cref="ValidationException"> <paramref name="value"/> is invalid</exception>
        public static void Validate(IValidatableObject value)
        {
            ObjectValidator.ValidateObject(value, newValidationContext(value)); 
        }

        internal static void Validate(Movie movie)
        {
            throw new NotImplementedException();
        }

        public interface IValidatableObject
        {
        }
    }
}
