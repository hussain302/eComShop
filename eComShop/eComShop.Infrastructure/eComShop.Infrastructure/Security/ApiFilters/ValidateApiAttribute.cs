using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace eComShop.Infrastructure.Security.ApiFilters
{
    public class ValidateApiAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("X-Domain"))
            {
                var result = new ObjectResult(new { error = "X-Domain missing" });
                result.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = result;
            }            
        }
    }
}