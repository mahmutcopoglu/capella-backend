using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Persistence.Services;
using Persistence.Services.Token;
using System.IdentityModel.Tokens.Jwt;

namespace API.Filters
{
    public class CustomAuthorizationFilter : IActionFilter
    {
        private readonly TokenService _tokenService;

        public CustomAuthorizationFilter(TokenService tokenService)
        {
            _tokenService = tokenService;
        }
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (HasRoleAttribute(context))
            {
                if (token != null && token.StartsWith("Bearer "))
                {
                    var userToken = token.Substring("Bearer ".Length);

                    var verifierToken = _tokenService.isTokenValid(userToken);
                    if (verifierToken)
                    {

                    }
                }
               
                

            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        public bool HasRoleAttribute(FilterContext context)
        {
            return ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.CustomAttributes.Any(filterDescriptors => filterDescriptors.AttributeType == typeof(PermissionAttribute));
        }
    }
}
