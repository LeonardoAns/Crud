using Communication.Response.Response;

namespace Crud.Application.IUseCases.Product;

public interface IGetAllProductUseCase {
    Task<List<ProductResponseJson>> Execute();
}