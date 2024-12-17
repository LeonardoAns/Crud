using System.Security.Claims;
using Crud.Application.IUseCases.User;
using Crud.Domain.Repositories.UnitOfWork;
using Crud.Domain.Repositories.User;
using Crud.Exception.ExceptionModel;
using Crud.Exception.ExceptionModel.Validator.Product;
using Microsoft.AspNetCore.Http;

namespace Crud.Application.UseCases.Product;

using AutoMapper;
using Communication.Requests.Product;
using Crud.Application.IUseCases.Product;
using Crud.Domain.Repositories.Product;
using Domain.Entities;

public class RegisterProductUseCase : IRegisterProductUseCase {

    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogedUserUseCase _logedUserUseCase;

    public RegisterProductUseCase(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogedUserUseCase logedUserUseCase){
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _logedUserUseCase = logedUserUseCase;
    }

    public async Task Execute(ProductRequestJson request){
        Validate(request);
        var logedUser = await _logedUserUseCase.Get();

        var category = await _productRepository.GetCategoryByIdAsync(request.CategoryId);
        if (category is null){
            throw new NotFoundException("Category not found"); 
        }

        var product = _mapper.Map<Product>(request);
        product.UserId = logedUser.Id;
        product.Category = category; 
        
        await _productRepository.AddAsync(product);
        await _unitOfWork.Commit();
    }
    
    private void Validate(ProductRequestJson request){
        var validator = new ProductRequestValidator().Validate(request);

        if (!validator.IsValid){
            var errorMessages = validator.Errors.Select(error => error.ErrorMessage).ToList();
            throw new InvalidRequestException(errorMessages);
        }
    }
}