using Communication.Requests.User;
using Crud.Application.IUseCases.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Api.Controllers.User;

[ApiController]
[Route("users")]
public class LoginController : ControllerBase{

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginUser([FromServices] ILoginUserUserCase userCase,
        [FromBody] LoginUserRequestJson request){
        var response = await userCase.Execute(request);
        return Ok(response);
    }
    
}