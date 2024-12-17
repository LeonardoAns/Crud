using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;

namespace Crud.Exception.ExceptionModel.Validator.User;

public class PasswordValidator<T> : PropertyValidator<T, string> {

    protected override string GetDefaultMessageTemplate(string errorCode){
        return "{ErrorMessage}";
    }
    
    public override bool IsValid(ValidationContext<T> context, string password){
        if (string.IsNullOrWhiteSpace(password)){
            context.MessageFormatter.AppendArgument("ErrorMessage", "Password cannot be empty");
            return false;
        }
        if (password.Length < 8){
            context.MessageFormatter.AppendArgument("ErrorMessage", "Password cannot be empty and must be at least 8 characters long.");
            return false;
        }
        return true;
    }

    public override string Name => "PasswrodValidator";
}