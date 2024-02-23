

using HellocDoc1.Services.Models;

namespace Services.Contracts
{
    public interface IBusinessRequest
    {
        Task Business_request(BusinessRequestModel model);
    }
}