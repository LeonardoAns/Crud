using Crud.Application.IUseCases.User;
using Crud.Domain.Repositories.User;


namespace Crud.Application.UseCases.User;

public class LogedUserUseCase : ILogedUserUseCase {

    private readonly IUserRepository _userRepository;

    public LogedUserUseCase(IUserRepository userRepository){
        _userRepository = userRepository;
    }

    public async Task<Domain.Entities.User> Get(){
        return await _userRepository.GetByIdentifier();
    }
}