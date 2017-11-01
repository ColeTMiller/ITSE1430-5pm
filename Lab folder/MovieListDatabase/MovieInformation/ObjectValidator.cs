using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformation
{
    class ObjectValidator
    {
        public static bool TryValidate ( IValidatableObject value, out IEnumerable<ValidationResult> errors)
        {
            var context = new ValidationContext(value);
            var results = new List<ValidationREsult>();

            errors = results;
            return ObjectValidator.TryValidateObject(value, context, results); 
        }
    }
}
