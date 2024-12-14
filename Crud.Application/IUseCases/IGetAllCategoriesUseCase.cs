using Communication.Response.Category;

namespace Crud.Application.IUseCases;

public interface IGetAllCategoriesUseCase {
    Task<List<CategoryResponseJson>> Execute();
}