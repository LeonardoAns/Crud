using Communication.Requests.Product;
using Crud.Application.UseCases;

namespace Crud.Application.IUseCases.Product;

public interface IUpdateProductUseCase {
    Task Execute(long id, ProductRequestJson request);

}