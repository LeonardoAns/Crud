using Communication.Requests.User;
using Communication.Response.User;

namespace Crud.Application.IUseCases.User;

public interface ILoginUserUserCase {
    Task<UserResponseJson> Execute(LoginUserRequestJson request);
}