using System.Data;
using Communication.Requests.Product;
using FluentValidation;

namespace Crud.Exception.ExceptionModel.Validator.Product;

public class ProductRequestValidator : AbstractValidator<ProductRequestJson> {
    
    public ProductRequestValidator(){
        RuleFor(product => product.Name)
            .NotEmpty()
            .WithMessage("Name is Required");

        RuleFor(product => product.Value)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("value must be greater than 0");

        RuleFor(product => product.CategoryId)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Category id must be greater than 0");


    }
}