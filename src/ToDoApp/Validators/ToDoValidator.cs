using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Validators
{
    public class ToDoValidator : AbstractValidator<AppServices.Dtos.ToDoDto>
    {
        public ToDoValidator()
        {
            RuleFor(x => x.Text).NotNull().WithMessage("Text field is required.");
        }
    }
}
