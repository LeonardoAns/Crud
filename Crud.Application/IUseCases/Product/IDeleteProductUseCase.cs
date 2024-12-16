namespace Crud.Application.IUseCases.Product;

public interface IDeleteProductUseCase {
    Task Execute(long id);
}