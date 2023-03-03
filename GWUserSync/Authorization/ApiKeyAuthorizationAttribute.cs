using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GWUserSync.Authorization;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAuthorizationAttribute : Attribute, IAsyncActionFilter
{
    private const string apiKeyHeader="ApiKey";
     public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(apiKeyHeader, out var potentialKey))
        {
            context.Result=new UnauthorizedResult();
            return;
        }
        
        var configuration=context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

        var apiKey=configuration.GetValue<string>(key: "ApiKey");

        if (!apiKey.Equals(potentialKey))
        {
            context.Result=new UnauthorizedResult();
            return;
        }

        await next();
    }
}
