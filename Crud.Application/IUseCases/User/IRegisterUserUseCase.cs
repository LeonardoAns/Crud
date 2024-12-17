using Communication.Requests.User;
using Communication.Response.User;

namespace Crud.Application.IUseCases.User;

public interface IRegisterUserUseCase {
    Task<UserResponseJson> Execute(RegisterUserRequestJson request);
}