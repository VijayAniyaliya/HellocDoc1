using HellocDoc1.DataContext;
using HellocDoc1.DataModels;
using HellocDoc1.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;

namespace HellocDoc1.Services
{
    public class PatientRequest : IPatientRequest
    {
        private readonly ApplicationDbContext _context;

        public PatientRequest(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Patient_request(PatientRequestModel model)
        {
            AspNetUser aspnetuser= _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefault();

            if (aspnetuser == null)
            {
                AspNetUser aspnetuser1 = new AspNetUser
                {

                //Id= Guid.Parse("xyz");
                Id="10",
                UserName = model.FirstName + " " + model.LastName,
                PasswordHash = "abc",
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                CreatedDate = DateTime.Now

                 };

                _context.AspNetUsers.Add(aspnetuser1);
                //aspnetuser = aspnetuser1;
                User user = new User
                {
                    UserId = 6,
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
                _context.Users.Add(user);

            }



            Request request = new Request
            {
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
            _context.Requests.Add(request);

            RequestClient requestclient = new RequestClient
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
            request.RequestClients.Add(requestclient);
            _context.RequestClients.Add(requestclient);
            _context.SaveChanges();

        }

    }
}
