using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator() 
        {
            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio ")
                .MaximumLength(80).WithMessage("{PropertyName} no puede ser mayor de {MaximumLength} caracteres");
                
            RuleFor(n=>n.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio ");

            RuleFor(n=>n.Address)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio ");

            RuleFor(n=>n.City)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio ");

        }
    }
}
