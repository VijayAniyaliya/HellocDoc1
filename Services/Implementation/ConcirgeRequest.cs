
using Data.Context;
using Data.Entity;
using HellocDoc1.Services.Models;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
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

        public async Task Concierge_request(ConciergeRequestModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {

                    AspNetUser aspnetuser = await _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

                    if (aspnetuser != null)
                    {


                        Concierge concirge = new Concierge()
                        {
                            ConciergeName = model.FirstName + " " + model.LastName,
                            Street = model.Street,
                            State = model.State,
                            City = model.City,
                            ZipCode = model.ZipCode,
                            CreatedDate = DateTime.Now,
                            RegionId = 1
                        };
                        await _context.Concierges.AddAsync(concirge);


                        Request request = new Request()
                        {
                            UserId = 6,
                            RequestTypeId = 3,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            Status = 1,
                            IsUrgentEmailSent = new BitArray(1),
                            CreatedDate = DateTime.Now

                        };
                        await _context.Requests.AddAsync(request);

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
                            RequestId = request.RequestId,
                            ConciergeId = concirge.ConciergeId
                        };


                        request.RequestClients.Add(requestclient);
                        await _context.RequestClients.AddAsync(requestclient);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }

            }
        }
    }
}
