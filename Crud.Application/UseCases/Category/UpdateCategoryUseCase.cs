using AutoMapper;
using Communication.Requests.Category;
using Crud.Application.IUseCases;
using Crud.Domain.Entities;
using Crud.Domain.Repositories.Category;
using Crud.Domain.Repositories.UnitOfWork;
using Crud.Exception.ExceptionModel;
using Crud.Exception.ExceptionModel.Validator.Category;

namespace Crud.Application.UseCases;

public class UpdateCategoryUseCase : IUpdateCategoryUseCase {

    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCategoryUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper){
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Execute(long id, CategoryRequestJson request){
        Category category = await _categoryRepository.FindByIdAsync(id) ?? throw new NotFoundException("Category Not Found");
        Validate(request);
        _mapper.Map(request, category);
        await _categoryRepository.UpdateAsync(id, category);
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