﻿using Data.Context;
using Data.Entity;
using HellocDoc1.Services.Models;
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

        public void Business_request(BusinessRequestModel model)
        {

            AspNetUser aspnetuser = _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefault();

            if (aspnetuser != null)
            {


                Business business = new Business()
            {
                Name = model.FirstName + " " + model.LastName,
                PhoneNumber = model.PhoneNumber,
                CreatedDate = DateTime.Now,
                RegionId = 1
            };

            _context.Businesses.Add(business);

            Request request = new Request()
            {
                UserId = 6,
                RequestTypeId = 2,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Status = 1,
                IsUrgentEmailSent = new BitArray(1),
                CreatedDate = DateTime.Now

            };
            _context.Requests.Add(request);

            RequestClient requestclient = new RequestClient()
            {
                FirstName = model.PatientFirstName,
                LastName = model.PatientLastName,
                IntDate = model.PatientDOB.Day,
                IntYear = model.PatientDOB.Year,
                StrMonth = (model.PatientDOB.Month).ToString(),
                Email = model.PatientEmail,
                PhoneNumber = model.PatientPhoneNumber,
                Notes = model.Symptoms,
                Street= model.PatientStreet,
                City= model.PatientCity,
                State= model.PatientState,
                ZipCode= model.PatientZipCode



                //Request= request,
            };

            RequestBusiness requestBusiness = new RequestBusiness()
            {
                RequestId= request.RequestId,
                BusinessId= business.BusinessId
            };


            request.RequestClients.Add(requestclient);
            _context.RequestClients.Add(requestclient);
            _context.SaveChanges();
            };

        }
    }
}