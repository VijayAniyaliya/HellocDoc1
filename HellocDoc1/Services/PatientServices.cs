using HellocDoc1.DataContext;
using HellocDoc1.DataModels;
using HellocDoc1.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            RequestClient requestClient = _context.RequestClients.Where(x => x.RequestId == request_id).FirstOrDefault();
            List<RequestWiseFile> requestWiseFile = _context.RequestWiseFiles.Where(x => x.RequestId == request_id).ToList();

            PatientServiceModel patientService = new PatientServiceModel()
            {
                request = data,
                requestWiseFile = requestWiseFile,
                requestClient = requestClient

            };
            return patientService;



        }

    }
}
