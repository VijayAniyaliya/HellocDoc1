using HellocDoc1.DataContext;
using HellocDoc1.DataModels;
using HellocDoc1.DTO;
using System.Collections;

namespace HellocDoc1.Services
{
    public class FamilyRequest : IFamilyRequest
    {
        private readonly ApplicationDbContext _context;

        public FamilyRequest(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Family_request(FamilyRequestModel model)
        {

            AspNetUser aspnetuser = _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefault();

            Request request = new Request
            {
                RequestTypeId = 2,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                RelationName= model.RelationWithPatient,
                Status = 1,
                IsUrgentEmailSent = new BitArray(1),
                CreatedDate = DateTime.Now

            };
            _context.Requests.Add(request);

            RequestClient requestclient = new RequestClient
            {
                FirstName= model.PatientFirstName, 
                LastName= model.PatientLastName,
                IntDate = model.PatientDOB.Day,
                IntYear= model.PatientDOB.Year, 
                StrMonth= (model.PatientDOB.Month).ToString(),
                Email= model.PatientEmail,
                PhoneNumber= model.PatientPhoneNumber,
                Street= model.PatientStreet,
                State= model.PatientState,
                City= model.PatientCity,
                ZipCode= model.PatientZipCode,
                Notes= model.Symptoms



                //Request= request,
            };
            request.RequestClients.Add(requestclient);
            _context.RequestClients.Add(requestclient);
            _context.SaveChanges();
        }
    }
}
