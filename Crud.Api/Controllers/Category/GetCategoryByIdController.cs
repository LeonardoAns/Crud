using Communication.Response.Category;
using Crud.Application.IUseCases;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Category;

[Route("categories")]
[ApiController]
public class GetCategoryByIdController : ControllerBase{
    
    [HttpGet]
    [Route("get/{categoryId}")]
    public async Task<IActionResult> GetById([FromServices] IGetCategoryByIdUseCase useCase, [FromRoute] long categoryId){
        CategoryResponseJson responseJson = await useCase.Execute(categoryId);
        return Ok(responseJson);
    }
}