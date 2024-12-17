using AutoMapper;
using Communication.Requests.User;
using Communication.Response.User;
using Crud.Application.IUseCases.User;
using Crud.Domain.Repositories.UnitOfWork;
using Crud.Domain.Repositories.User;
using Crud.Domain.Security;
using Crud.Exception.ExceptionModel;
using Crud.Exception.ExceptionModel.Validator.User;
using Crud.Infrastructure.Security;
using FluentValidation.Results;

namespace Crud.Application.UseCases.User;

using Domain.Entities;

public class RegisterUserUseCase : IRegisterUserUseCase {

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _tokenGenerator;

    public RegisterUserUseCase(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork, IPasswordEncripter passwordEncripter,IAccessTokenGenerator tokenGenerator){
        _userRepository = userRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _passwordEncripter = passwordEncripter;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<UserResponseJson> Execute(RegisterUserRequestJson request){ 
        await Validate(request);
        User user = _mapper.Map<User>(request);
        
        user.Password = _passwordEncripter.Encrypt(request.Password);
        user.Identifier = Guid.NewGuid();
        
        await _userRepository.AddAsync(user);
        await _unitOfWork.Commit();

        return new UserResponseJson(_tokenGenerator.GenerateToken(user));
    }

    private async Task Validate(RegisterUserRequestJson request){
        var result = new UserRequestValidator().Validate(request);

        var emailExists = await _userRepository.ExistsByEmail(request.Email);
        if (emailExists){
            result.Errors.Add(new ValidationFailure(string.Empty,"Email already exists"));
        }
        
        if (result.IsValid is false){
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new InvalidRequestException(errorMessages);
        }

    }
}