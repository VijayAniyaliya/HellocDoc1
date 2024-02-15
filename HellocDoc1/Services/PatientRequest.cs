using HellocDoc1.DataContext;
using HellocDoc1.DataModels;
using HellocDoc1.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Net;

namespace HellocDoc1.Services
{
    public class PatientRequest : IPatientRequest
    {
        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment environment;

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 6)
                      + Path.GetExtension(fileName);
        }

        public PatientRequest(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            this.environment = environment;
        }

        public async Task Patient_request(PatientRequestModel model)
        {
            AspNetUser aspnetuser= await _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

            if (aspnetuser == null)
            {
                AspNetUser aspnetuser1 = new AspNetUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    //Id="9",
                    UserName = model.FirstName + " " + model.LastName,
                    PasswordHash = "abc",
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    CreatedDate = DateTime.Now

                 };

                await _context.AspNetUsers.AddAsync(aspnetuser1);
                //aspnetuser = aspnetuser1;
                User user = new User()
                {
                    AspNetUserId= aspnetuser1.Id,
                    UserId= 9,
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
                    //AspNetUser = aspnetuser

                };
                await _context.Users.AddAsync(user);

            }



            Request request = new Request()
            {
                UserId= 6,
                RequestTypeId = 3,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Status =1,
                CreatedDate = DateTime.Now,
                IsUrgentEmailSent = new BitArray(1)
            //User = user,
        };
            await _context.Requests.AddAsync(request);

            RequestClient requestclient = new RequestClient()
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                State = model.State,
                Street= model.Street,
                City = model.City,
                ZipCode= model.ZipCode,
                Notes= model.Symptoms
                //Request= request,
            };

            var file = model.Doc;
            var uniqueFileName = GetUniqueFileName(file.FileName);
            var uploads = Path.Combine(environment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, uniqueFileName);
            file.CopyTo(new FileStream(filePath, FileMode.Create));

            RequestWiseFile requestWiseFile = new RequestWiseFile()
            {
                Request=request,
                FileName=uniqueFileName,
                CreatedDate= DateTime.Now,

            };

            await _context.RequestWiseFiles.AddAsync(requestWiseFile);


            request.RequestClients.Add(requestclient);
            await _context.RequestClients.AddAsync(requestclient);
            await _context.SaveChangesAsync();

        }

    }
}
