using Communication.Requests.Category;
using Crud.Application.IUseCases;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Category;

[Route("categories")]
[ApiController]
public class RegisterCategoryController : ControllerBase{
    
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterCategory([FromServices] IRegisterCategoryUseCase useCase, [FromBody] CategoryRequestJson request){
        await useCase.Execute(request);
        return Created(string.Empty, null);
    }
}