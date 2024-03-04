using Data.Context;
using Data.Entity;
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
                    AspNetUser aspnetuser = await _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

                    if (aspnetuser != null)
                    {


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
                            Street = model.PatientStreet,
                            State = model.PatientState,
                            City = model.PatientCity,
                            ZipCode = model.PatientZipCode,
                            Notes = model.Symptoms
                            //Request= request,
                        };

                        var file = model?.Doc!;
                        var uniqueFileName = GetUniqueFileName(file.FileName);
                        var uploads = Path.Combine(environment.WebRootPath, "uploads");
                        var filePath = Path.Combine(uploads, uniqueFileName);
                        file.CopyTo(new FileStream(filePath, FileMode.Create));

                        RequestWiseFile requestWiseFile = new RequestWiseFile()
                        {
                            Request = request,
                            FileName = uniqueFileName,
                            CreatedDate = DateTime.Now,

                        };

                        await _context.RequestWiseFiles.AddAsync(requestWiseFile);


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
