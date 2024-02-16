using HellocDoc1.Services.Models;

namespace Services.Contracts
{
    public interface IFamilyRequest
    {
        void Family_request(FamilyRequestModel model);
    }
}