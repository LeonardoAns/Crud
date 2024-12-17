using Crud.Application.IUseCases.Product;
using Crud.Exception.ExceptionModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.Product;

[Route("products")]
[ApiController]
[Authorize]
public class DeleteProductController : ControllerBase{

    [HttpDelete]
    [Route("delete/{productId}")] 
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType( StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct([FromServices] IDeleteProductUseCase useCase, [FromRoute] long productId){
        await useCase.Execute(productId);
        return NoContent();
    }
}