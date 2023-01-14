using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ValidationException:Exception
    {
        public ValidationException():base("se han producido uno o mas errores de validacion") 
        {
            Errors=new List<string>();

        }   
        
        public List<string> Errors { get; private set;}

        public ValidationException(IEnumerable<ValidationFailure> failures) :this()
        {
            foreach(var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }

        }

    }
}
