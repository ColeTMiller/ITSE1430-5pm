//Cole Miller
//ObjectValidator
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
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static bool TryValidate (IValidatableObject value, out IEnumerable<ValidationResult> errors)
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
        public static void Validate (IValidatableObject value)
        {
            Validator.ValidateObject(value, new ValidationContext(value)); 
        }
    }
}
