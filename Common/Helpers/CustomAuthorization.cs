using Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Common.Helpers
{
    public class CustomAuthorize : Attribute, IAuthorizationFilter
    {
        private readonly string _role;

        public CustomAuthorize(string role = "") 
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
                return;

            //Fetch Request from the Header
            var request = context.HttpContext.Request;

            //Fetch tokens
            var token = request.Cookies["jwt"];


            //Code for Authentication
            if (token == null || !JwtService.ValidateToken(token, out JwtSecurityToken jwtSecurityToken))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Patient", action = "Login" }));
                return;
            }


            //Code for Authorization
            var roleClaim = jwtSecurityToken.Claims.Where(claims => claims.Type == ClaimTypes.Role).Select(a => a.Value).ToList();

            //Logged in but no roles found
            if (roleClaim is null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Patient", action = "Submit_request" }));
                return;
            }

            if (!roleClaim.Contains(_role))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Admin", action = "AccessDenied" }));
                return;
            }


            var claims = jwtSecurityToken.Claims;

            context.HttpContext.User.AddIdentity(new ClaimsIdentity(claims));
            //var email = User.FindFirstValue(ClaimTypes.Email);
            return;
        }
    }
}