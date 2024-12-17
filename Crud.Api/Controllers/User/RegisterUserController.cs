using Communication.Requests.User;
using Communication.Response.User;
using Crud.Application.IUseCases.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Crud.Api.Controllers.User;

[ApiController]
[Route("users")]
public class RegisterUserController : ControllerBase{

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser([FromServices] IRegisterUserUseCase useCase, [FromBody] RegisterUserRequestJson request){
        UserResponseJson response = await useCase.Execute(request); 
        return Created(string.Empty, response);
    }
}