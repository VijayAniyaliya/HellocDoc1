using Data.Context;
using Data.Entity;
using HellocDoc1.Services.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System.Collections;

namespace HellocDoc1.Services
{
    public class PatientRequest : IPatientRequest
    {
        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment environment;

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 6)
                      + Path.GetExtension(fileName);
        }

        public PatientRequest(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            this.environment = environment;
        }

        public async Task Patient_request(PatientRequestModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    AspNetUser aspnetuser = await _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

                    if (aspnetuser == null)
                    {
                        AspNetUser aspnetuser1 = new AspNetUser()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserName = model.FirstName + " " + model.LastName,
                            PasswordHash = model.Password,
                            Email = model.Email,
                            PhoneNumber = model.PhoneNumber,
                            CreatedDate = DateTime.Now

                        };

                        await _context.AspNetUsers.AddAsync(aspnetuser1);
                        User user = new User()
                        {
                            AspNetUserId = aspnetuser1.Id,
                            UserId = 9,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Email = model.Email,
                            Mobile = model.PhoneNumber,
                            ZipCode = model.ZipCode,
                            State = model.State,
                            City = model.City,
                            Street = model.Street,
                            IntDate = model.DOB.Day,
                            IntYear = model.DOB.Year,
                            StrMonth = (model.DOB.Month).ToString(),
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Patient",
                        };
                        await _context.Users.AddAsync(user);
                    }

                    Request request = new Request()
                    {
                        UserId = 6,
                        RequestTypeId = 3,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Status = (int)Common.Enum.RequestStatus.Unassigned,
                        CreatedDate = DateTime.Now,
                        IsUrgentEmailSent = new BitArray(1)
                    };
                    await _context.Requests.AddAsync(request);

                    RequestClient requestclient = new RequestClient()
                    {

                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        State = model.State,
                        Street = model.Street,
                        City = model.City,
                        ZipCode = model.ZipCode,
                        Notes = model.Symptoms
                    };

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
                    request.RequestClients.Add(requestclient);
                    await _context.RequestClients.AddAsync(requestclient);
                    await _context.SaveChangesAsync();
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
