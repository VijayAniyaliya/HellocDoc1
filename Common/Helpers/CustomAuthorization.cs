using Data.Context;
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
        private readonly ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        private readonly string _PageName;

        public CustomAuthorize(string role = "", string PageName = "")
        {
            _role = role;
            _PageName = PageName;
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
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Admin", action = "AdminLogin" }));
                return;
            }


            //Code for Authorization
            var roleClaim = jwtSecurityToken.Claims.Where(claims => claims.Type == ClaimTypes.Role).Select(a => a.Value).ToList();

            var claims = jwtSecurityToken.Claims;
            context.HttpContext.User.AddIdentity(new ClaimsIdentity(claims));

            //Logged in but no roles found
            if (roleClaim is null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Patient", action = "Submit_request" }));
                return;
            }

            if (!roleClaim.Contains(_role))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "AccessdDenied" }));
                return;
            }
            else
            {
                var Id = jwtSecurityToken.Claims.FirstOrDefault(claims => claims.Type == "userId").Value;
                if (_role.ToLower() == "admin")
                {
                    if (!applicationDbContext.Menus.Any(a => a.Name == _PageName && a.AccountType == 1))
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "AccessdDenied" }));
                        return;
                    }

                    var RoleId = applicationDbContext.Admins.FirstOrDefault(a => a.AspNetUserId == Id).RoleId;
                    List<int> Menus = applicationDbContext.RoleMenus.Where(a => a.RoleId == RoleId).Select(a => a.MenuId).ToList();

                    int MenuID = applicationDbContext.Menus.FirstOrDefault(a => a.AccountType == 1 && a.Name == _PageName).MenuId;

                    if (Menus.Contains(MenuID))
                    {

                        return;
                    }
                    else
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "AccessdDenied" }));
                        return;
                    }
                }
                else if (_role.ToLower() == "physician")
                {
                    if (!applicationDbContext.Menus.Any(a => a.Name == _PageName && a.AccountType == 2))
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "AccessdDenied" }));
                        return;
                    }

                    var RoleId = applicationDbContext.Physicians.FirstOrDefault(a => a.AspNetUserId == Id).RoleId;
                    List<int> Menus = applicationDbContext.RoleMenus.Where(a => a.RoleId == RoleId).Select(a => a.MenuId).ToList();

                    int MenuID = applicationDbContext.Menus.FirstOrDefault(a => a.AccountType == 2 && a.Name == _PageName).MenuId;

                    if (Menus.Contains(MenuID))
                    {
                        return;
                    }
                    else
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "AccessdDenied" }));
                        return;
                    }
                }           
                else if (_role.ToLower() == "user")
                {
                    return;
                }
                else
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "AccessdDenied" }));
                    return;
                }
            }



        }
    }
}