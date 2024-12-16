using Communication.Requests.Product;
using Crud.Application.IUseCases.Product;
using Crud.Exception.ExceptionModel;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Product;

[Route("products")]
[ApiController]
public class UpdateProductController : ControllerBase{

    [HttpPut]
    [Route("update/{productId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]    
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct([FromServices] IUpdateProductUseCase useCase,
        [FromRoute] long productId,
        [FromBody] ProductRequestJson request){
        await useCase.Execute(productId, request);
        return NoContent();
    }
    
}