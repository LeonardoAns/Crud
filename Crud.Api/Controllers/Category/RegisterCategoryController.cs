using Communication.Requests.Category;
using Crud.Application.IUseCases;
using Crud.Exception.ExceptionModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Category;

[Route("categories")]
[ApiController]
[Authorize]
public class RegisterCategoryController : ControllerBase{
    
    [HttpPost]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]    
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    public async Task<IActionResult> RegisterCategory([FromServices] IRegisterCategoryUseCase useCase, [FromBody] CategoryRequestJson request){
        await useCase.Execute(request);
        return Created(string.Empty, null);
    }
}