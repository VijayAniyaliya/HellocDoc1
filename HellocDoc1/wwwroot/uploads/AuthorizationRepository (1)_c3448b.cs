using DataAccess.ServiceRepository.IServiceRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ServiceRepository
{
    public class AuthorizationRepository : Attribute, IAuthorizatoinRepository, IAuthorizationFilter
    {
        private readonly string _role;

        public AuthorizationRepository(string role = "")
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var person = SessionUtilsRepository.GetLoggedInPerson(context.HttpContext.Session);
            if (person == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "AdminLogin" }));
                return;
            }
            if (!string.IsNullOrEmpty(_role))
            {
                if (!(person.Role == _role))
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "AdminLogin" }));
                }
            }

        }
    }
}
