using Crud.Application.IUseCases.Product;
using Crud.Exception.ExceptionModel;
using Microsoft.AspNetCore.Mvc;

[Route("products")]
[ApiController]
public class GetProductByIdController : ControllerBase
{
    [HttpGet("get/{productId}")]
    public async Task<IActionResult> GetProductById([FromServices] IGetProductByIdUseCase useCase,
        [FromRoute] long productId)
    {
        var product = await useCase.Execute(productId); // Certifique-se de que está aguardando o método
        return Ok(product);
    }
}