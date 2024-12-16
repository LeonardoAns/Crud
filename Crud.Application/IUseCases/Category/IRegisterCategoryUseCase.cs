using Communication.Requests.Category;

namespace Crud.Application.IUseCases;

public interface IRegisterCategoryUseCase {
    Task Execute(CategoryRequestJson request);
}