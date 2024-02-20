using Common.Enum;
using Data.Context;
using HalloDoc.Utility;
using HellocDoc1.Services.Models;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using Services.Models;

namespace HelloDoc1.Services
{
    public class LoginHandler : ILoginHandler
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public LoginHandler(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public LoginResponseViewModel Login(LoginViewModel model)
        {
            var user = _context.AspNetUsers.Where(u => u.Email == model.Email).FirstOrDefault();

            if (user == null)
                return new LoginResponseViewModel() { Status = ResponseStatus.Failed, Message = "User Not Found" };
            if (user.PasswordHash == null)
                return new LoginResponseViewModel() { Status = ResponseStatus.Failed, Message = "There is no Password with this Account" };
            if (user.PasswordHash == model.Password)
            {
                _emailSender.SendEmailAsync("vijay.aniyaliya@etatvasoft.com", "Hello", "Please <a href=\"https://localhost:7208/Patient/Login\">login</a>");
                return new LoginResponseViewModel() { Status = ResponseStatus.Success};
            }
            return new LoginResponseViewModel(){ Status = ResponseStatus.Failed , Message="Password does not match"};
        }

    }
}
