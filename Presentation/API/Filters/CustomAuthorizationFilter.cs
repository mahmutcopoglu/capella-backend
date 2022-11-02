using Application.Services.Token;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Persistence.Services;
using Persistence.Services.Token;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;

namespace API.Filters
{
    public class CustomAuthorizationFilter : IAsyncActionFilter
    {
        private readonly ITokenService _tokenService;

        public CustomAuthorizationFilter(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        
        public async Task OnActionExecutedAsync(ActionExecutedContext context)
        {
            return;
        }

        public bool HasRoleAttribute(FilterContext context)
        {
            return ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.CustomAttributes.Any(filterDescriptors => filterDescriptors.AttributeType == typeof(PermissionAttribute));
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (HasRoleAttribute(context))
            {
                try
                {
                    if (token != null && token.StartsWith("Bearer "))
                    {
                        var userToken = token.Substring("Bearer ".Length);

                        var verifierToken = _tokenService.isTokenValid(userToken);
                        if (verifierToken)
                        {

                            var arguments = ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.CustomAttributes.FirstOrDefault(fd => fd.AttributeType == typeof(PermissionAttribute)).ConstructorArguments;
                            var permission = (string)arguments[0].Value;
                            var yetkiDurumu = await _tokenService.getRolePermission(userToken, permission);

                            if (!yetkiDurumu)
                            {
                                context.Result = new ObjectResult(context.ModelState)
                                {
                                    Value = "You are not authorized for this page",
                                    StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status403Forbidden
                                };
                                return;
                            }
                            await next();

                        }
                    }
                }
                catch (Exception ex)
                {
                    context.Result = new ObjectResult(context.ModelState)
                    {
                        Value = "An error has occured while authorization:\n" + ex.Message,
                        StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized
                    };
                    return;
                }

            }
        }
    }
}
