using Communication.Requests.Category;
using Crud.Domain.Entities;

namespace Crud.Application.IUseCases;

public interface IUpdateCategoryUseCase {
    Task Execute(long id, CategoryRequestJson category);
}