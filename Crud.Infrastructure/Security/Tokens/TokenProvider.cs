using Microsoft.AspNetCore.Http;

namespace Crud.Infrastructure.Security.Tokens;

public class TokenProvider : ITokenProvider
{
    private readonly IHttpContextAccessor _contextAccessor;

    public TokenProvider(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string TokenOnRequest()
    {
        var auth = _contextAccessor.HttpContext!.Request.Headers["Authorization"].ToString();

        if (string.IsNullOrEmpty(auth))
        {
            throw new InvalidOperationException("Authorization header is missing.");
        }

        return auth["Bearer ".Length..].Trim();
    }

}