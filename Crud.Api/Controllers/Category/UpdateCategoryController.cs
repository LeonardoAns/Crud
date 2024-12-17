using Communication.Requests.Category;
using Crud.Application.IUseCases;
using Crud.Exception.ExceptionModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Category;

[Route("categories")]
[ApiController]
[Authorize]
public class UpdateCategoryController : ControllerBase{
    
    [HttpPut]
    [Route("update/{categoryId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]    
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> updateCategory([FromServices] IUpdateCategoryUseCase useCase, [FromRoute] long categoryId,[FromBody] CategoryRequestJson request){
        await useCase.Execute(categoryId, request);
        return NoContent();
    }
}