using Crud.Application.IUseCases;
using Crud.Domain.Entities;
using Crud.Domain.Repositories.Category;
using Crud.Domain.Repositories.UnitOfWork;
using Crud.Exception.ExceptionModel;
using Exception = System.Exception;

namespace Crud.Application.UseCases;

public class DeleteCategoryUseCase : IDeleteCategoryUseCase {

    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryUseCase(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork){
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id){
        Category category = await _categoryRepository.FindByIdAsync(id) ??
                            throw new NotFoundException("Category Not Found");
        await _categoryRepository.DeleteAsync(category);
        await _unitOfWork.Commit();
    }
}