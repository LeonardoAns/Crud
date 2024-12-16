using Communication.Response.Response;
using Crud.Application.IUseCases.Product;
using Crud.Exception.ExceptionModel;
using Microsoft.AspNetCore.Mvc;

[Route("products")]
[ApiController]
public class GetProductByIdController : ControllerBase
{
    [HttpGet("get/{productId}")]
    [ProducesResponseType(typeof(ProductResponseJson),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductById([FromServices] IGetProductByIdUseCase useCase,
        [FromRoute] long productId)
    {
        var product = await useCase.Execute(productId); 
        return Ok(product);
    }
}