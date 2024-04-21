using Common.Helpers;
using Data.Context;
using Data.Entity;
using HalloDoc.Utility;
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
                    AspNetUser? aspnetuser = await _context.AspNetUsers.Where(x => x.Email == model.PatientEmail).FirstOrDefaultAsync();
                    User? user = await _context.Users.Where(a => a.Email == model.PatientEmail).FirstOrDefaultAsync();
                    Region? region = await _context.Regions.FirstOrDefaultAsync(a => a.RegionId == model.PatientState);
                    List<Request>? requestcount = await _context.Requests.Where(a => a.CreatedDate.Date == DateTime.Today).ToListAsync();


                    Business business = new Business()
                    {
                        Name = model.FirstName + " " + model.LastName,
                        PhoneNumber = model.PhoneNumber,
                        CreatedDate = DateTime.Now,
                        RegionId = model.PatientState,
                        Address1 = model.PatientStreet + " " + model.PatientCity + " " + region?.Name + " " + model.PatientZipCode,

                    };
                    await _context.Businesses.AddAsync(business);

                    Request request = new Request()
                    {
                        UserId = user != null ? user.UserId : null,
                        RequestTypeId = (int)Common.Enum.RequestType.Business,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.PhoneNumber,
                        Email = model.Email,
                        Status = (int)Common.Enum.RequestStatus.Unassigned,
                        IsUrgentEmailSent = new BitArray(1),
                        CreatedDate = DateTime.Now,
                        ConfirmationNumber = region?.Abbreviation?.ToUpper() + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0')
                                         + DateTime.Now.Year.ToString().Substring(2) + model.LastName.Substring(0, 2).ToUpper() + model.FirstName.Substring(0, 2).ToUpper() +
                                         (requestcount.Count() + 1).ToString().PadLeft(4, '0'),
                    };
                    await _context.Requests.AddAsync(request);
                    await _context.SaveChangesAsync();

                    RequestClient requestclient = new RequestClient()
                    {
                        RequestId= request.RequestId,
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
                        State = region.Name,
                        ZipCode = model.PatientZipCode,
                        RegionId = model.PatientState,

                    };

                    RequestBusiness requestBusiness = new RequestBusiness()
                    {
                        RequestId = request.RequestId,
                        BusinessId = business.BusinessId
                    };

                    await _context.RequestBusinesses.AddAsync(requestBusiness);
                    await _context.RequestClients.AddAsync(requestclient);
                    await _context.SaveChangesAsync();

                    if (aspnetuser == null)
                    {
                        string requestId = HashingServices.Encrypt(request.RequestId.ToString());
                        await EmailSender.SendGmail("aniyariyavijay441@gmail.com", "Create Your Account", $"<a href=\"https://localhost:7208/Patient/CreatePatientAccount/{requestId}\">Create Account</a>");

                        EmailLog emailLog = new EmailLog()
                        {
                            EmailTemplate = "https://localhost:7208/Patient/CreatePatientAccount/",
                            SubjectName = "Create Your Account",
                            EmailId = requestclient.Email,
                            ConfirmationNumber = request.ConfirmationNumber,
                            RequestId = request.RequestId,
                            CreateDate = DateTime.Now,
                            SentDate = DateTime.Now,
                            SentTries = 1,
                            IsEmailSent = new BitArray(new[] { true }),
                        };
                        _context.EmailLogs.Add(emailLog);
                        await _context.SaveChangesAsync();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }


            }

        }
    }
}
