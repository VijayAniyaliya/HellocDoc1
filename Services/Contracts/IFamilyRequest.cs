using HellocDoc1.Services.Models;

namespace Services.Contracts
{
    public interface IFamilyRequest
    {
        Task Family_request(FamilyRequestModel model);
    }
}