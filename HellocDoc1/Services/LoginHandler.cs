//using HellocDoc1.DataContext;
//using HellocDoc1.DataModels;
//using HellocDoc1.DTO;
//using HellocDoc1.Models;
//using HellocDoc1.Services;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace HellocDoc1.Services
//{
//    public class LoginHandler : ILoginHandler
//    {
//        private readonly ApplicationDbContext _applicationDbContext;

//        public LoginHandler(ApplicationDbContext applicationDbContext)
//        {
//            _applicationDbContext = applicationDbContext;
//        }
//        public IdentityResult Login(LoginViewModel model)
//        {
//            Aspnetuser? user = _applicationDbContext.Aspnetusers.Where(u => u.Email == model.Email).FirstOrDefault();

//            if (user == null)
//                return IdentityResult.Failed(new IdentityError() { Description = "Email is Not Found" });
//            if (user.Passwordhash == null)
//                return IdentityResult.Failed(new IdentityError() { Description = "There is no Password with this Account" });
//            String encryptedPassword = hashing.encrypt(user.Passwordhash);
//            //if (encryptedPassword == model.Password)
//            //    return IdentityResult.Success;
//            if (user.Passwordhash == model.Password)
//                return IdentityResult.Success;
//            return IdentityResult.Failed(new IdentityError() { Description = "Password Not Match" });
//        }
//    }
//}



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
            AspNetUser? user = _context.AspNetUser.Where(u => u.Email == model.Email).FirstOrDefault();

            if (user == null)
                return IdentityResult.Failed(new IdentityError() { Description = "Email is Not Found" });
            if (user.PasswordHash == null)
                return IdentityResult.Failed(new IdentityError() { Description = "There is no Password with this Account" });
            if (user.PasswordHash == model.Password)
                return IdentityResult.Success;
            return IdentityResult.Failed(new IdentityError() { Description = "Password Not Match" });
        }


    }
}
