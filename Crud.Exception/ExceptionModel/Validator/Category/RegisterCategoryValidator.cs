using Communication.Requests.Category;
using FluentValidation;

namespace Crud.Exception.ExceptionModel.Validator.Category;

public class RegisterCategoryValidator : AbstractValidator<CategoryRequestJson> {

    public RegisterCategoryValidator(){
        RuleFor(category => category.Name)
            .NotEmpty()
            .WithMessage("Name is Required");
    }
}