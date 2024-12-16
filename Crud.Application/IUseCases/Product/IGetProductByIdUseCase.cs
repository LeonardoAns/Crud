using Communication.Response.Response;

namespace Crud.Application.IUseCases.Product;

public interface IGetProductByIdUseCase {
    Task<ProductResponseJson> Execute(long id);
}