using Communication.Requests.Product;
using Crud.Application.IUseCases.Product;
using Crud.Exception.ExceptionModel;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Product;

[Route("products")]
[ApiController]
public class RegisterProductController : ControllerBase{

    [HttpPost]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]    
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    public async Task<IActionResult> RegisterProduct([FromServices] IRegisterProductUseCase useCase, [FromBody] ProductRequestJson request){
        await useCase.Execute(request);
        return Created(string.Empty, null);
    }
    
}