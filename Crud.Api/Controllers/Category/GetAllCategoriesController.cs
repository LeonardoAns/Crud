using Communication.Response.Category;
using Crud.Application.IUseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Category;

[ApiController]
[Route("categories")]
[Authorize]
public class GetAllCategoriesController : ControllerBase{
    
    [HttpGet]
    [Route("getall")]
    [ProducesResponseType(typeof(List<CategoryResponseJson>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCategories([FromServices] IGetAllCategoriesUseCase useCase){
        List<CategoryResponseJson> response = await useCase.Execute();
        return Ok(response);
    }
}