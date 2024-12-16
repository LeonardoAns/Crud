using Communication.Requests.Product;

namespace Crud.Application.IUseCases.Product;

public interface IRegisterProductUseCase {

    Task Execute(ProductRequestJson request);
}