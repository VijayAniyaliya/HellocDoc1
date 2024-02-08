using HellocDoc1.DTO;
using Microsoft.AspNetCore.Identity;

namespace HellocDoc1.Services
{
    public interface ILoginHandler
    {
        IdentityResult Login(LoginViewModel model);
    }
}