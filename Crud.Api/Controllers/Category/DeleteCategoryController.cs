using Crud.Application.IUseCases;
using Crud.Exception.ExceptionModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Category;

[Route("categories")]
[ApiController]
[Authorize]
public class DeleteCategoryController : ControllerBase{
    
    [HttpDelete]
    [Route("delete/{categoryId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType( StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCategory([FromServices]IDeleteCategoryUseCase useCase,[FromRoute] long categoryId){
        await useCase.Execute(categoryId);
        return NoContent();
    }
}