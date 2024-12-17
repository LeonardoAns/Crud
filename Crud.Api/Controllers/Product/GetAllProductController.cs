using Communication.Response.Response;
using Crud.Application.IUseCases.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Product;

[Route("products")]
[ApiController]
[Authorize]
public class GetAllProductController : ControllerBase{

    [Route("getall")]
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductResponseJson>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProducts([FromServices] IGetAllProductUseCase useCase){
        var products = await useCase.Execute();
        return Ok(products);
    }
}