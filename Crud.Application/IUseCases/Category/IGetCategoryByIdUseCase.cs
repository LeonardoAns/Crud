using Communication.Response.Category;
using Crud.Domain.Entities;

namespace Crud.Application.IUseCases;

public interface IGetCategoryByIdUseCase {
    Task<CategoryResponseJson> Execute(long id);
}