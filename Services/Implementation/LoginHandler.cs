using Common.Enum;
using Common.Helpers;
using Data.Context;
using HalloDoc.Utility;
using HellocDoc1.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Models;

namespace HelloDoc1.Services
{
    public class LoginHandler : ILoginHandler
    {
        private readonly ApplicationDbContext _context;

        public LoginHandler(ApplicationDbContext context )
        {
            _context = context;
            
        }

        public LoginResponseViewModel Login(LoginViewModel model)
        {
            var user = _context.AspNetUsers.Where(u => u.Email == model.Email).Include(a=> a.Roles).FirstOrDefault();

            if (user == null)
                return new LoginResponseViewModel() { Status = ResponseStatus.Failed, Message = "User Not Found" };
            if (user.PasswordHash == null)
                return new LoginResponseViewModel() { Status = ResponseStatus.Failed, Message = "There is no Password with this Account" };
            if (user.PasswordHash == model.Password)
            {
                var jwtToken = JwtService.GetJwtToken(user);

                return new LoginResponseViewModel() { Status = ResponseStatus.Success, Token = jwtToken };
            }
            return new LoginResponseViewModel(){ Status = ResponseStatus.Failed , Message="Password does not match"};
        }

    }
}
