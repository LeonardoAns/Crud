using Communication.Requests.Product;
using Crud.Application.IUseCases.Product;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Product;

[Route("products")]
[ApiController]
public class RegisterProductController : ControllerBase{

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterProduct([FromServices] IRegisterProductUseCase useCase, [FromBody] ProductRequestJson request){
        await useCase.Execute(request);
        return Created(string.Empty, null);
    }
    
}