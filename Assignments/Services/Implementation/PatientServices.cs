using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comman.Enum;
using Data.Context;
using Data.Entity;
using Services.Contracts;
using Services.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Services.Implementation
{

    public class PatientServices : IPatientServices
    {

        private ApplicationDbContext _context;

        public PatientServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SubmitPatientForm(PatientFormViewModel model, int gender)
        {
            Doctor? doctor = _context.Doctors.FirstOrDefault(a => a.Specialist == model.Specialist);
            Patient? patient1 = _context.Patients.FirstOrDefault(a => a.Id == model.PatientId);

            Patient patient = new Patient();

            if (doctor != null)
            {
                patient.DoctortId = doctor.DoctorId;
            }
            else
            {
                Doctor doctor1 = new Doctor()
                {
                    Specialist = model.Specialist,
                };
                _context.Doctors.Add(doctor1);
                _context.SaveChanges();

                patient.DoctortId = doctor1.DoctorId;
            }
            patient.FirstName = model.FirstName;
            patient.LastName = model.LastName;
            patient.Email = model.Email;
            patient.PhoneNo = model.PhoneNumber;
            patient.Age = short.Parse(model.Age);
            patient.Gender = gender;
            patient.Disease = model.Disease;
            patient.Specialist = model.Specialist;
            _context.Patients.Add(patient);
            _context.SaveChanges();

        }
        public void EditPatientData(PatientFormViewModel model, int gender)
        {
            Doctor? doctor = _context.Doctors.FirstOrDefault(a => a.Specialist == model.Specialist);
            Patient? patient1 = _context.Patients.FirstOrDefault(a => a.Id == model.PatientId);

            if (patient1 != null)
            {
                patient1.FirstName = model.FirstName;
                patient1.LastName = model.LastName;
                patient1.Email = model.Email;
                patient1.PhoneNo = model.PhoneNumber;
                patient1.Specialist = model.Specialist;
                patient1.Age = short.Parse(model.Age);
                patient1.Gender = gender;
                if (doctor != null)
                {
                    patient1.DoctortId = doctor.DoctorId;
                }
                else
                {
                    Doctor doctor1 = new Doctor()
                    {
                        Specialist = model.Specialist,
                    };
                    _context.Doctors.Add(doctor1);
                    _context.SaveChanges();

                    patient1.DoctortId = doctor1.DoctorId;
                }
                _context.Patients.Update(patient1);
                _context.SaveChanges();
            }
        }

        public PatientFormViewModel EditPatientForm(int PatientId)
        {
            Patient? patient1 = _context.Patients.FirstOrDefault(a => a.Id == PatientId);

            if (patient1 != null)
            {

                PatientFormViewModel model = new PatientFormViewModel()
                {
                    PatientId = PatientId,
                    FirstName = patient1.FirstName,
                    LastName = patient1.LastName,
                    Email = patient1.Email,
                    PhoneNumber = patient1.PhoneNo,
                    Age = patient1.Age.ToString(),
                    Specialist = patient1.Specialist,
                    Disease = patient1.Disease,
                };
                return model;
            };
            return new PatientFormViewModel();
        }


        public PatientTableViewModel PatientData(PatientTableViewModel model)
        {
            List<Patient> data = _context.Patients.ToList();

            if (data != null)
            {
                List<PatientData> obj = data.Select(a => new PatientData()
                {
                    PatientId = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email,
                    PhoneNumber = a.PhoneNo,
                    Age = a.Age,
                    Gender = a.Gender,
                    Disease = a.Disease,
                    Doctor = a.Specialist,
                }).ToList();

                obj = obj.Where(a =>
                (string.IsNullOrWhiteSpace(model.PatientName) || (a.FirstName.ToLower() + " " + a.LastName.ToLower()).Contains(model.PatientName.ToLower()))).ToList();

                int count = obj.Count();
                int TotalPage = (int)Math.Ceiling(count / (double)10);
                obj = obj.Skip((model.CurrentPage - 1) * 10).Take(10).ToList();

                PatientTableViewModel model1 = new PatientTableViewModel()
                {
                    patientDatas = obj,
                    CurrentPage = model.requestedPage,
                    TotalPage = TotalPage,
                };
                return model1;
            }
            return new PatientTableViewModel();
        }

        public void DeleteRecord(int PatientId)
        {
            Patient? patient = _context.Patients.FirstOrDefault(a => a.Id == PatientId);

            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }

    }
}
