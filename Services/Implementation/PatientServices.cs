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

namespace HellocDoc1.Services
{
    public class PatientServices : IPatientServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor HttpContextAccessor;
        private readonly IHostingEnvironment _environment;

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
                    ModifiedDate= DateTime.Now,

                };

                _context.AspNetUsers.Add(aspnetuser);
            }



        }

    }
}
