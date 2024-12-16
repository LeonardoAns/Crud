using Communication.Response.Category;
using Crud.Application.IUseCases;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Category;

[ApiController]
[Route("categories")]
public class GetAllCategoriesController : ControllerBase{
    
    [HttpGet]
    [Route("getall")]
    public async Task<IActionResult> GetAllCategories([FromServices] IGetAllCategoriesUseCase useCase){
        List<CategoryResponseJson> response = await useCase.Execute();
        return Ok(response);
    }
}