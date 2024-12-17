using AutoMapper;
using Communication.Requests.Category;
using Crud.Application.IUseCases;
using Crud.Application.IUseCases.User;
using Crud.Domain.Entities;
using Crud.Domain.Repositories.Category;
using Crud.Domain.Repositories.UnitOfWork;
using Crud.Exception.ExceptionModel;
using Crud.Exception.ExceptionModel.Validator.Category;
using Microsoft.AspNetCore.Http;
using Crud.Domain.Repositories.User;

namespace Crud.Application.UseCases;

using Domain.Entities;

public class RegisterCategoryUseCase : IRegisterCategoryUseCase {

    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogedUserUseCase _logedUserUseCase;

    public RegisterCategoryUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper, ILogedUserUseCase logedUserUseCase){
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logedUserUseCase = logedUserUseCase;
    }

    public async Task Execute(CategoryRequestJson request){
        Validate(request);
        var logedUser = _logedUserUseCase.Get();
        Category category = _mapper.Map<Category>(request);
        category.UserId = logedUser.Id;
        
        await _categoryRepository.AddAsync(category);
        await _unitOfWork.Commit();
    }

    private void Validate(CategoryRequestJson request){
        var validator = new CategoryRequestValidator().Validate(request);

        if (!validator.IsValid){
            var errorMessages = validator.Errors.Select(error => error.ErrorMessage).ToList();
            throw new InvalidRequestException(errorMessages);
        }
    }
}