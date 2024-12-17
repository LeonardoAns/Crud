using Communication.Response.Category;
using Crud.Application.IUseCases;
using Crud.Exception.ExceptionModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Category;

[Route("categories")]
[ApiController]
[Authorize]
public class GetCategoryByIdController : ControllerBase{
    
    [HttpGet]
    [Route("get/{categoryId}")]
    [ProducesResponseType(typeof(CategoryResponseJson),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromServices] IGetCategoryByIdUseCase useCase, [FromRoute] long categoryId){
        CategoryResponseJson responseJson = await useCase.Execute(categoryId);
        return Ok(responseJson);
    }
}