using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(r => r.title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("slug"));
        }
    }

}
