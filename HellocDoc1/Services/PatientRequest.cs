using HellocDoc1.DataContext;
using HellocDoc1.DTO;
using Microsoft.AspNetCore.Identity;

namespace HellocDoc1.Services
{
    public class PatientRequest : IPatientRequest
    {
        private readonly ApplicationDbContext _context;

        public PatientRequest(ApplicationDbContext context)
        {
            _context = context;
        }

 
    }
}
