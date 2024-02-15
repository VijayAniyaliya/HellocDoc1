using HellocDoc1.DataContext;
using HellocDoc1.DataModels;
using HellocDoc1.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System;

namespace HellocDoc1.Services
{
    public class PatientServices : IPatientServices
    {
        private readonly ApplicationDbContext _context;

        public PatientServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Request> DashboardService(string Email)
        {
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



        }

    }
}
