using Data.Context;
using Data.Entity;
using HellocDoc1.Services.Models;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System.Collections;

namespace HellocDoc1.Services
{
    public class BusinessRequest : IBusinessRequest
    {
        private readonly ApplicationDbContext _context;

        public BusinessRequest(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Business_request(BusinessRequestModel model)
        {

            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {
                    AspNetUser aspnetuser = await _context.AspNetUsers.Where(x => x.Email == model.PatientEmail).FirstOrDefaultAsync();

                    if (aspnetuser != null)
                    {


                        Business business = new Business()
                        {
                            Name = model.FirstName + " " + model.LastName,
                            PhoneNumber = model.PhoneNumber,
                            CreatedDate = DateTime.Now,
                            RegionId = 1,
                        };

                        await _context.Businesses.AddAsync(business);
                        User user = _context.Users.Where(a => a.Email == model.PatientEmail).FirstOrDefault();
                        var regiondata = _context.Regions.Where(x => x.RegionId == user.RegionId).FirstOrDefault();
                        var requestcount = _context.Requests.Where(a => a.CreatedDate.Date == DateTime.Now.Date && a.CreatedDate.Month == DateTime.Now.Month && a.CreatedDate.Year == DateTime.Now.Year && a.UserId == user.UserId).ToList();
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
                            CreatedDate = DateTime.Now,
                            ConfirmationNumber = regiondata.Abbreviation + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0')
                                             + DateTime.Now.Year.ToString().Substring(2) + model.LastName.Substring(0, 2) + model.FirstName.Substring(0, 2) +
                                             (requestcount.Count() + 1).ToString().PadLeft(4, '0'),
                        };
                        await _context.Requests.AddAsync(request);

                        RequestClient requestclient = new RequestClient()
                        {
                            FirstName = model.PatientFirstName,
                            LastName = model.PatientLastName,
                            IntDate = model.PatientDOB.Day,
                            IntYear = model.PatientDOB.Year,
                            StrMonth = model.PatientDOB.ToString("MMM"),
                            Email = model.PatientEmail,
                            PhoneNumber = model.PatientPhoneNumber,
                            Notes = model.Symptoms,
                            Street = model.PatientStreet,
                            City = model.PatientCity,
                            State = model.PatientState,
                            ZipCode = model.PatientZipCode,
                            RegionId = regiondata.RegionId,

                        };

                        RequestBusiness requestBusiness = new RequestBusiness()
                        {
                            RequestId = request.RequestId,
                            BusinessId = business.BusinessId
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
