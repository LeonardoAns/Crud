using Communication.Requests.User;
using Communication.Response.User;
using Crud.Application.IUseCases.User;
using Crud.Domain.Repositories.User;
using Crud.Domain.Security;
using Crud.Exception.ExceptionModel;
using Crud.Infrastructure.Security;

namespace Crud.Application.UseCases.User;

public class LoginUserUseCase : ILoginUserUserCase {

    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _tokenGenerator;

    public LoginUserUseCase(IUserRepository userRepository, IPasswordEncripter passwordEncripter, IAccessTokenGenerator tokenGenerator){
        _userRepository = userRepository;
        _passwordEncripter = passwordEncripter;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<UserResponseJson> Execute(LoginUserRequestJson request){
        var user = await _userRepository.GetUserByEmail(request.Email) ??
                   throw new NotFoundException("email or psswordis invalid");

        var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

        if (!passwordMatch){
            throw new NotFoundException("email or password invalid");
        }

        return new UserResponseJson(_tokenGenerator.GenerateToken(user));
    }
}