namespace Crud.Infrastructure.Security;

public interface ITokenProvider {
    string TokenOnRequest();
}