using Communication.Requests.Category;
using Crud.Application.IUseCases;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers;

[Route("categories")]
[ApiController]
public class UpdateCategoryController : ControllerBase{

    [HttpPut]
    [Route("update/{categoryId}")]
    public async Task<IActionResult> updateCategory([FromServices] IUpdateCategoryUseCase useCase, [FromRoute] long categoryId,[FromBody] CategoryRequestJson request){
        await useCase.Execute(categoryId, request);
        return NoContent();
    }

}