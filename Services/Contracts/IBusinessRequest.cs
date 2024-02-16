

using HellocDoc1.Services.Models;

namespace Services.Contracts
{
    public interface IBusinessRequest
    {
        void Business_request(BusinessRequestModel model);
    }
}