using HellocDoc1.Services.Models;

namespace Services.Contracts
{
    public interface IConcirgeRequest
    {
        void Concierge_request(ConciergeRequestModel model);
    }
}