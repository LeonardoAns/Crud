using Crud.Application.IUseCases.Product;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Product;

[Route("products")]
[ApiController]
public class GetAllProductsController : ControllerBase {

    [HttpGet]
    [Route("getall")]
    public async Task<IActionResult> GetAllProducts([FromServices] IGetAllProductUseCase useCase){
        var products = await useCase.Execute();
        return Ok(products);
    }
        
}