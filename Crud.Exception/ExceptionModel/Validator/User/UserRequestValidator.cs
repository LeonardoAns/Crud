using System.Data;
using Communication.Requests.User;
using FluentValidation;

namespace Crud.Exception.ExceptionModel.Validator.User;

public class UserRequestValidator : AbstractValidator<RegisterUserRequestJson> {
    
    public UserRequestValidator(){
        RuleFor(user => user.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty");
        
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty")
            .EmailAddress()
            .WithMessage("invalid Email");

        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RegisterUserRequestJson>());
    }
}