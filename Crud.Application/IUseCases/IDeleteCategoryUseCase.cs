namespace Crud.Application.IUseCases;

public interface IDeleteCategoryUseCase {
    Task Execute(long id);
}