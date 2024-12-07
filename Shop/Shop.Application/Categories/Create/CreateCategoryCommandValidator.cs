using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using FluentValidation;
using FluentValidation.Validators;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand> 
    {

        public CreateCategoryCommandValidator() 
        {
            RuleFor(r=>r.title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("slug"));
        }
    }
}
