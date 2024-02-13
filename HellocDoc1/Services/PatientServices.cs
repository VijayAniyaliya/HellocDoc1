using HellocDoc1.DataContext;
using HellocDoc1.DataModels;
using HellocDoc1.DTO;

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
            List<Request> data = _context.Requests.Where(x => x.User.Email == Email).ToList();
            return data;
         
        }

    }
}
