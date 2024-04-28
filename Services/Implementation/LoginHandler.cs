using Common.Enum;
using Common.Helpers;
using Data.Context;
using Data.Entity;
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

        public LoginHandler(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<LoginResponseViewModel> Login(LoginViewModel model)
        {
            var user = await _context.AspNetUsers.Where(u => u.Email == model.Email).Include(a => a.Roles).Include(a => a.Users).FirstOrDefaultAsync();

            if (user == null)
                return new LoginResponseViewModel() { Status = ResponseStatus.Failed, Message = "User Not Found" };
            if (user.PasswordHash == null)
                return new LoginResponseViewModel() { Status = ResponseStatus.Failed, Message = "There is no Password with this Account" };
            if (HashingServices.Decrypt(user.PasswordHash) == model.Password)
            {
                var jwtToken = JwtService.GetJwtToken(user);

                return new LoginResponseViewModel() { Status = ResponseStatus.Success, Token = jwtToken };
            }
            return new LoginResponseViewModel() { Status = ResponseStatus.Failed, Message = "Password does not match" };
        }

        public async Task<LoginResponseViewModel> CreateNewAccount(CreateAccountViewModel model)
        {
            RequestClient? user = await _context.RequestClients.Include(u => u.Request).Where(u => u.Email == model.Email).FirstOrDefaultAsync();

            if (user == null)
            {
                return new LoginResponseViewModel() { Status = ResponseStatus.Failed, Message = "Please entered the email you used when submitting your request" };
            }
            else
            {
                AspNetRole? aspNetRole = await _context.AspNetRoles.FirstOrDefaultAsync(a => a.Id == "f352aa19-76b5-4342-8364-c509077c5ab1");

                AspNetUser aspNetUser = new AspNetUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = user.FirstName + user.LastName,
                    PasswordHash = HashingServices.Encrypt(model.Password),
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    CreatedDate = DateTime.Now,
                };
                _context.AspNetUsers.Add(aspNetUser);
                await _context.SaveChangesAsync();

                User user1 = new User()
                {
                    AspNetUserId = aspNetUser.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Mobile = user.PhoneNumber,
                    Street = user.Street,
                    City = user.City,
                    State = user.State,
                    RegionId = user.RegionId,
                    ZipCode = user.ZipCode,
                    IntDate = user.IntDate,
                    IntYear = user.IntYear,
                    StrMonth = user.StrMonth,
                    CreatedBy = aspNetUser.Id,
                    CreatedDate = DateTime.Now,
                };

                aspNetUser.Roles.Add(aspNetRole);

                _context.Users.Add(user1);
                await _context.SaveChangesAsync();



                user.Request.UserId = user1.UserId;
                return new LoginResponseViewModel() { Status = ResponseStatus.Success, Message = "" };
            }
        }

        public async Task<LoginResponseViewModel> patientaccount(int request_id)
        {
            RequestClient? user = await _context.RequestClients.Where(u => u.RequestId == request_id).FirstOrDefaultAsync();

            if (user != null)
            {
                CreateAccountViewModel model = new CreateAccountViewModel()
                {
                    RequestId = request_id,
                    Email = user.Email,
                };
            }

            return new LoginResponseViewModel();
        }
    }
}
