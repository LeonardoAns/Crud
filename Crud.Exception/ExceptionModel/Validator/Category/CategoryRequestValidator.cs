using Communication.Requests.Category;
using FluentValidation;

namespace Crud.Exception.ExceptionModel.Validator.Category;

public class CategoryRequestValidator : AbstractValidator<CategoryRequestJson> {

    public CategoryRequestValidator(){
        RuleFor(category => category.Name)
            .NotEmpty()
            .WithMessage("Name is Required");
    }
}