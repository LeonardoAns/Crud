namespace Crud.Application.IUseCases.User;

using Domain.Entities;

public interface ILogedUserUseCase {
    Task<User> Get();
}