using Crud.Application.IUseCases;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Category;

[Route("categories")]
[ApiController]
public class DeleteCategoryController : ControllerBase{
    
    [HttpDelete]
    [Route("delete/{categoryId}")]
    public async Task<IActionResult> DeleteCategory([FromServices]IDeleteCategoryUseCase useCase,[FromRoute] long categoryId){
        await useCase.Execute(categoryId);
        return NoContent();
    }
}