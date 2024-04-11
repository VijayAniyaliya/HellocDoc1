using Data.Context;
using Data.Entity;
using HalloDoc.Utility;
using HellocDoc1.Services.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System;
using System.Collections;

namespace HellocDoc1.Services
{
    public class FamilyRequest : IFamilyRequest
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment environment;

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 6)
                      + Path.GetExtension(fileName);
        }

        public FamilyRequest(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            this.environment = environment;
        }

        public async Task Family_request(FamilyRequestModel model)
        {   
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    AspNetUser? aspnetuser = await _context.AspNetUsers.Where(x => x.Email == model.PatientEmail).FirstOrDefaultAsync();


                    User? user = _context.Users.Where(a => a.Email == model.PatientEmail).FirstOrDefault(); 
                    var regiondata = _context.Regions.Where(a => a.RegionId == user.RegionId).FirstOrDefault();
                    var requestcount = _context.Requests.Where(a => a.CreatedDate.Date == DateTime.Now.Date && a.CreatedDate.Month == DateTime.Now.Month && a.CreatedDate.Year == DateTime.Now.Year && a.UserId == user.UserId).ToList();
                    Request request = new Request()
                    {
                        UserId = 6,
                        RequestTypeId = 2,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.PhoneNumber,
                        Email = model.Email,
                        RelationName = model.RelationWithPatient,
                        Status = 1,
                        IsUrgentEmailSent = new BitArray(1),
                        CreatedDate = DateTime.Now,
                        ConfirmationNumber = regiondata?.Abbreviation?.ToUpper() + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0')
                                         + DateTime.Now.Year.ToString().Substring(2) + model.LastName.Substring(0, 2).ToUpper() + model.FirstName.Substring(0, 2).ToUpper() +
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
                        Street = model.PatientStreet,
                        State = model.PatientState,
                        City = model.PatientCity,
                        ZipCode = model.PatientZipCode,
                        Notes = model.Symptoms,
                        RegionId = regiondata.RegionId,
                    };

                    if (model.Doc != null)
                    {
                        foreach (var item in model.Doc)
                        {
                            var file = item.FileName;
                            var uniqueFileName = GetUniqueFileName(file);
                            var uploads = Path.Combine(environment.WebRootPath, "uploads");
                            var filePath = Path.Combine(uploads, uniqueFileName);
                            item.CopyTo(new FileStream(filePath, FileMode.Create));

                            RequestWiseFile requestWiseFile = new RequestWiseFile()
                            {
                                Request = request,
                                FileName = uniqueFileName,
                                CreatedDate = DateTime.Now,

                            };
                            await _context.RequestWiseFiles.AddAsync(requestWiseFile);

                        }
                    }
                    request.RequestClients.Add(requestclient);
                    await _context.RequestClients.AddAsync(requestclient);
                    await _context.SaveChangesAsync();

                    if (aspnetuser == null)
                    {   
                        await EmailSender.SendEmail("vijay.aniyaliya@etatvasoft.com", "Hello", $"<a href=\"https://localhost:7208/Patient/CreatePatientAccount/{request.RequestId}\">Agreement</a>");

                        EmailLog emailLog = new EmailLog()
                        {
                            EmailTemplate = "https://localhost:7208/Patient/CreatePatientAccount/",
                            SubjectName = "Create Your Account",
                            EmailId = requestclient.Email,
                            ConfirmationNumber = request.ConfirmationNumber,
                            RequestId = request.RequestId,
                            CreateDate = DateTime.Now,
                            SentDate = DateTime.Now,
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
