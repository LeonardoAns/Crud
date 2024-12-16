using Crud.Application.IUseCases.Product;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Product;

[Route("products")]
[ApiController]
public class DeleteProductController : ControllerBase{

    [HttpDelete]
    [Route("delete/{productId}")]
    public async Task<IActionResult> DeleteProduct([FromServices] IDeleteProductUseCase useCase, [FromRoute] long productId){
        await useCase.Execute(productId);
        return NoContent();
    }

}