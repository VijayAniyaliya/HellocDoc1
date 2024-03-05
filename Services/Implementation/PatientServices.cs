using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Services.Contracts;
using Data.Context;
using Data.Entity;
using HellocDoc1.Services.Models;
using Newtonsoft.Json.Linq;
using System.Text;
using System.IO.Compression;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Collections;
using Common.Enum;
using Services.Models;
using HalloDoc.Utility;

namespace HellocDoc1.Services
{
    public class PatientServices : IPatientServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor HttpContextAccessor;
        private readonly IHostingEnvironment _environment;

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 6)
                      + Path.GetExtension(fileName);
        }
        public PatientServices(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IHostingEnvironment environment)
        {
            _context = context;
            HttpContextAccessor = httpContextAccessor;
            _environment = environment;

        }
        public List<Request> DashboardService(string Email)
        {
            string lastName = _context.Users.FirstOrDefault(x => x.Email == Email).FirstName + " " + _context.Users.FirstOrDefault(x => x.Email == Email).LastName;
            HttpContextAccessor.HttpContext.Session.Set("username", Encoding.UTF8.GetBytes((string)lastName));
            List<Request> data = _context.Requests.Where(x => x.User.Email == Email).Include(a => a.RequestWiseFiles).ToList();
            return data;

        }

        public PatientServiceModel DocumentService(int request_id)
        {
            Request data = _context.Requests.Where(x => x.RequestId == request_id).FirstOrDefault();
            RequestClient requestClient = _context.RequestClients.Where(x => x.RequestId == request_id).FirstOrDefault()!;
            List<RequestWiseFile> requestWiseFile = _context.RequestWiseFiles.Where(x => x.RequestId == request_id).ToList();

            PatientServiceModel patientService = new PatientServiceModel()
            {
                request = data,
                requestWiseFile = requestWiseFile,
                requestClient = requestClient!

            };
            return patientService;

        }

        public void UploadDocument(PatientServiceModel model,int request_id)
        {
            IEnumerable<IFormFile>upload = model.Doc;
            foreach (var item in upload)
            {

                var file = item.FileName;
                var uniqueFileName = GetUniqueFileName(file);
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                item.CopyTo(new FileStream(filePath, FileMode.Create));

                RequestWiseFile requestWiseFile = new RequestWiseFile()
                {
                    FileName = uniqueFileName,
                    CreatedDate= DateTime.Now,
                    
                };
                _context.RequestWiseFiles.Add(requestWiseFile);
                requestWiseFile.RequestId = request_id;
                
            }
            _context.SaveChanges();
        }

        public async Task<byte[]> DownloadFilesForRequest(int request_id)
        {

            var zipName = $"RequestFiles-{request_id}-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

            using (MemoryStream ms = new MemoryStream())
            {
                using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    var filesForRequest = await _context.RequestWiseFiles
                        .Where(file => file.RequestId == request_id)
                        .ToListAsync();
                    var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                    foreach (var file in filesForRequest)
                    {
                        var filepath = Path.Combine(uploads, file.FileName);

                        if (!string.IsNullOrEmpty(filepath) && System.IO.File.Exists(filepath))
                        {
                            var entry = zip.CreateEntry(Path.GetFileName(filepath));

                            using (var entryStream = entry.Open())
                            using (var fileStream = System.IO.File.OpenRead(filepath))
                            {
                                await fileStream.CopyToAsync(entryStream);
                            }
                        }
                    }
                }



                return (ms.ToArray());
            }

        }

        public User ProfileService(string Email)
        {
            User data = _context.Users.Where(x => x.Email == Email).FirstOrDefault();
            return data;

        }

        public void Editing(string email, User model)
        {
            var userdata = _context.Users.Where(x => x.Email == email).FirstOrDefault();

            if (userdata.Email == model.Email)
            {

                userdata.FirstName = model.FirstName;
                userdata.LastName = model.LastName;
                userdata.Mobile = model.Mobile;
                userdata.Email = model.Email;
                userdata.Street = model.Street;
                userdata.City = model.City;
                userdata.State = model.State;
                userdata.ZipCode = model.ZipCode;
                userdata.ModifiedDate = DateTime.Now;

                _context.Users.Update(userdata);

                _context.SaveChanges();
            }
            else
            {
                AspNetUser aspnetuser = new AspNetUser()
                {
                    UserName = model.FirstName + " " + model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.Mobile,
                    ModifiedDate = DateTime.Now,

                };

                _context.AspNetUsers.Add(aspnetuser);
            }



        }

        public void SubmitInformationSomeone(SubmitInfoViewModel model)
        {

            AspNetUser aspnetuser = _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefault();

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
                _context.Requests.Add(request);

                RequestClient requestclient = new RequestClient()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    IntDate = model.DOB.Day,
                    IntYear = model.DOB.Year,
                    StrMonth = (model.DOB.Month).ToString(),
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Street = model.Street,
                    State = model.State,
                    City = model.City,
                    ZipCode = model.ZipCode,
                    Notes = model.Symptoms
                    //Request= request,
                };

                var file = model.Doc;
                var uniqueFileName = GetUniqueFileName(file.FileName);
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                file.CopyTo(new FileStream(filePath, FileMode.Create));

                RequestWiseFile requestWiseFile = new RequestWiseFile()
                {
                    Request = request,
                    FileName = uniqueFileName,
                    CreatedDate = DateTime.Now,

                };

                _context.RequestWiseFiles.Add(requestWiseFile);



                request.RequestClients.Add(requestclient);
                _context.RequestClients.Add(requestclient);
                _context.SaveChanges();
            };
        }

        public void ResetPassword(string email)
        {
            var user = _context.AspNetUsers.Where(u => u.Email == email).FirstOrDefault();

            if (user != null)
            {
                EmailSender.SendEmailAsync("vijay.aniyaliya@etatvasoft.com", "Hello", $"Please <a href=\"https://localhost:7208/Patient/ChangePassword/{email}\">Reset</a>");
            }
        }

        public void ChangePassword(string email, ChangePassViewModel model)
        {
            var user = _context.AspNetUsers.Where(u => u.Email == email).FirstOrDefault();

            user.PasswordHash = model.Password;

            _context.AspNetUsers.Update(user);
            _context.SaveChanges();
            
        }

    }
}
