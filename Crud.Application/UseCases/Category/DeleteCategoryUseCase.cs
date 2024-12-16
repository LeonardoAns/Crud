using Crud.Application.IUseCases;
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
        bool response = await _categoryRepository.DeleteAsync(id);

        if (response != true){
            throw new NotFoundException("Category Not Found");
        }

        await _unitOfWork.Commit();
    }
}