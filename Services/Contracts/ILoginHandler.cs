using HellocDoc1.Services.Models;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface ILoginHandler
    {
        IdentityResult Login(LoginViewModel model);
    }
}