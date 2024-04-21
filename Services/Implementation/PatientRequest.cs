using Common.Helpers;
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
                    AspNetUser? aspnetuser = await _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefaultAsync();
                    User? user1 = await _context.Users.Where(a => a.Email == model.Email).FirstOrDefaultAsync();
                    Region? region = await _context.Regions.Where(a => a.RegionId == model.State).FirstOrDefaultAsync();

                    User user = new User();

                    if (aspnetuser == null)
                    {
                        AspNetUser aspnetuser1 = new AspNetUser()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserName = model.FirstName + " " + model.LastName,
                            PasswordHash = HashingServices.Encrypt(model.Password!),
                            Email = model.Email,
                            PhoneNumber = model.PhoneNumber,
                            CreatedDate = DateTime.Now
                        };
                        await _context.AspNetUsers.AddAsync(aspnetuser1);
                        await _context.SaveChangesAsync();

                        user.AspNetUserId = aspnetuser1.Id;
                        user.FirstName = model.FirstName;
                        user.LastName = model.LastName;
                        user.Email = model.Email;
                        user.Mobile = model.PhoneNumber;
                        user.ZipCode = model.ZipCode;
                        user.State = region?.Name;
                        user.City = model.City;
                        user.Street = model.Street;
                        user.IntDate = model.DOB.Day;
                        user.IntYear = model.DOB.Year;
                        user.StrMonth = model.DOB.ToString("MMM");
                        user.CreatedDate = DateTime.Now;
                        user.CreatedBy = aspnetuser1!.Id;

                        await _context.Users.AddAsync(user);
                        await _context.SaveChangesAsync();
                    }

                    var requestcount = _context.Requests.Where(a => a.CreatedDate.Date == DateTime.Now.Date && a.CreatedDate.Month == DateTime.Now.Month && a.CreatedDate.Year == DateTime.Now.Year && a.UserId == (user1 != null ? user1.UserId : user!.UserId)).ToList();

                    Request request = new Request()
                    {
                        UserId = user1 != null ? user1.UserId : user!.UserId,
                        RequestTypeId = (int)Common.Enum.RequestType.Patient,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Status = (int)Common.Enum.RequestStatus.Unassigned,
                        CreatedDate = DateTime.Now,
                        IsUrgentEmailSent = new BitArray(1),
                        ConfirmationNumber = region?.Abbreviation?.ToUpper() + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0')
                                             + DateTime.Now.Year.ToString().Substring(2) + model.LastName.Substring(0, 2).ToUpper() + model.FirstName.Substring(0, 2).ToUpper() +
                                             (requestcount.Count() + 1).ToString().PadLeft(4, '0'),
                    };
                    await _context.Requests.AddAsync(request);

                    RequestClient requestclient = new RequestClient()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        IntDate = model.DOB.Day,
                        IntYear = model.DOB.Year,
                        StrMonth = model.DOB.ToString("MMM"),
                        State = region?.Name,
                        IsMobile = new BitArray(new[] { true }),
                        Street = model.Street,
                        City = model.City,
                        ZipCode = model.ZipCode,
                        Notes = model.Symptoms,
                        RegionId = model.State,
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