using Communication.Requests.Product;
using Crud.Application.IUseCases.Product;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Product;

[Route("products")]
[ApiController]
public class UpdateProductController : ControllerBase{

    [HttpPut]
    [Route("update/{productId}")]
    public async Task<IActionResult> UpdateProduct([FromServices] IUpdateProductUseCase useCase,
        [FromRoute] long productId,
        [FromBody] ProductRequestJson request){
        await useCase.Execute(productId, request);
        return NoContent();
    }
    
}