using System.Diagnostics;
using AutoMapper;
using Communication.Requests.Category;
using Crud.Application.IUseCases;
using Crud.Domain.Entities;
using Crud.Domain.Repositories.Category;
using Crud.Domain.Repositories.UnitOfWork;
using Crud.Exception.ExceptionModel;
using Crud.Exception.ExceptionModel.Validator.Category;

namespace Crud.Application.UseCases;

public class RegisterCategoryUseCase : IRegisterCategoryUseCase {

    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterCategoryUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper){
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Execute(CategoryRequestJson request){
        Validate(request);
        Category category = _mapper.Map<Category>(request);
        
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