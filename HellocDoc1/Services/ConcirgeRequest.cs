using HellocDoc1.DataContext;
using HellocDoc1.DataModels;
using HellocDoc1.DTO;
using System.Collections;

namespace HellocDoc1.Services
{
    public class ConcirgeRequest : IConcirgeRequest
    {
        private readonly ApplicationDbContext _context;

        public ConcirgeRequest(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Concierge_request(ConciergeRequestModel model)
        {
            AspNetUser aspnetuser = _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefault();

            if (aspnetuser != null)
            {


                Concierge concirge = new Concierge()
            {
                ConciergeName= model.FirstName + " " + model.LastName,
                Street= model.Street,
                State= model.State,
                City= model.City,
                ZipCode= model.ZipCode,
                CreatedDate= DateTime.Now,
                RegionId= 1
            };
            _context.Concierges.Add(concirge);


            Request request = new Request()
            {
                UserId = 6,
                RequestTypeId = 2,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Status = 1,
                IsUrgentEmailSent = new BitArray(1),
                CreatedDate = DateTime.Now

            };
            _context.Requests.Add(request);

            RequestClient requestclient = new RequestClient()
            {
                FirstName = model.PatientFirstName,
                LastName = model.PatientLastName,
                IntDate = model.PatientDOB.Day,
                IntYear = model.PatientDOB.Year,
                StrMonth = (model.PatientDOB.Month).ToString(),
                Email = model.PatientEmail,
                PhoneNumber = model.PatientPhoneNumber,
                Notes = model.Symptoms



                //Request= request,
            };

            RequestConcierge requestConcierge = new RequestConcierge()
            {
                RequestId= request.RequestId,
                ConciergeId= concirge.ConciergeId
            };


            request.RequestClients.Add(requestclient);
            _context.RequestClients.Add(requestclient);
            _context.SaveChanges();
            };
        }
    }
}
