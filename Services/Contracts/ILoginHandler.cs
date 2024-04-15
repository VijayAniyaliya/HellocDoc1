using HellocDoc1.Services.Models;
using Microsoft.AspNetCore.Identity;
using Services.Models;

namespace Services.Contracts
{
    public interface ILoginHandler
    {
        Task<LoginResponseViewModel> CreateNewAccount(CreateAccountViewModel model);
        Task<LoginResponseViewModel> Login(LoginViewModel model);
    }
}