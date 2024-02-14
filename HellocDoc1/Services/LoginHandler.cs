using HellocDoc1.DataContext;
using HellocDoc1.DTO;
using HellocDoc1.Models;
using HellocDoc1.Services;
using Microsoft.AspNetCore.Identity;

namespace HelloDoc1.Services
{
    public class LoginHandler : ILoginHandler
    {
        private readonly ApplicationDbContext _context;

        public LoginHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public IdentityResult Login(LoginViewModel model)
        {
            var user = _context.AspNetUsers.Where(u => u.Email == model.Email).FirstOrDefault();

            if (user == null)
                return IdentityResult.Failed(new IdentityError() { Description = "Email is Not Found" });
            if (user.PasswordHash==  null)
                return IdentityResult.Failed(new IdentityError() { Description = "There is no Password with this Account" });
            if (user.PasswordHash == model.Password)
                return IdentityResult.Success;
            return IdentityResult.Failed(new IdentityError() { Description = "Password Not Match" });
        }


    }
}
