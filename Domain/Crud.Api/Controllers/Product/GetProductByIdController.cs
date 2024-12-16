using Crud.Application.IUseCases.Product;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Product;

[Route("products")]
[ApiController]
public class GetProductByIdController : ControllerBase{

    [HttpGet]
    [Route("get/{productId}")]
    public async Task<IActionResult> GetProductById([FromServices] IGetProductByIdUseCase useCase, [FromRoute] long productId){
        var product = await useCase.Execute(productId);
        return Ok(product);
    }

}