using Data.Context;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Models;

namespace Services.Implementation
{
    public class ProviderServices: IProviderServices
    {
        private ApplicationDbContext _context;
        public ProviderServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminDashboardViewModel> ProviderDashboard()
        {
            var requestCount1 = await _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 1).CountAsync();
            var requestCount2 = await _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 2).CountAsync();
            var requestCount3 = await _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 3).CountAsync();
            var requestCount4 = await _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 4).CountAsync();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                newCount = requestCount1,
                pendingCount = requestCount2,
                activeCount = requestCount3,
                concludeCount = requestCount4,
            };
            return model;
        }

        public async Task<AdminDashboardViewModel> NewState(AdminDashboardViewModel obj)
        {
            List<RequestClient> clients = await _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 1).ToListAsync();

            AdminDashboardViewModel model = new AdminDashboardViewModel();

            if (clients != null)
            {
                model.requestClients = clients;

                if (!string.IsNullOrWhiteSpace(obj.patientname))
                {
                    model.requestClients = model.requestClients.Where(a => a.FirstName.ToLower().Contains(obj.patientname.ToLower()) || a.LastName.ToLower().Contains(obj.patientname.ToLower())).ToList();
                }
                if (obj.requesttype == 1 || obj.requesttype == 2 || obj.requesttype == 3 || obj.requesttype == 4)
                {
                    model.requestClients = model.requestClients.Where(a => a.Request.RequestTypeId == obj.requesttype).ToList();
                }
                if (obj.region != 0)
                {
                    model.requestClients = model.requestClients.Where(a => a.RegionId == obj.region).ToList();
                }
                int count = model.requestClients.Count();
                int TotalPage = (int)Math.Ceiling(count / (double)5);
                model.requestClients = model.requestClients.Skip((obj.requestedPage - 1) * 5).Take(5).ToList();
                model.CurrentPage = obj.requestedPage;
                model.TotalPage = TotalPage;
            }
            return model;
        }

        public async Task<AdminDashboardViewModel> PendingState(AdminDashboardViewModel obj)
        {
            List<RequestClient> clients = await _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Include(a => a.Request.RequestStatusLogs).Where(a => a.Request.Status == 2).ToListAsync();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = clients;

            if (clients != null)
            {
                if (!string.IsNullOrWhiteSpace(obj.patientname))
                {
                    model.requestClients = model.requestClients.Where(a => a.FirstName.ToLower().Contains(obj.patientname.ToLower()) || a.LastName.ToLower().Contains(obj.patientname.ToLower())).ToList();
                }
                if (obj.requesttype == 1 || obj.requesttype == 2 || obj.requesttype == 3 || obj.requesttype == 4)
                {
                    model.requestClients = model.requestClients.Where(a => a.Request.RequestTypeId == obj.requesttype).ToList();
                }
                if (obj.region != 0)
                {
                    model.requestClients = model.requestClients.Where(a => a.RegionId == obj.region).ToList();
                }
                int count = model.requestClients.Count();
                int TotalPage = (int)Math.Ceiling(count / (double)5);
                model.requestClients = model.requestClients.Skip((obj.requestedPage - 1) * 5).Take(5).ToList();
                model.CurrentPage = obj.requestedPage;
                model.TotalPage = TotalPage;
            }

            return model;
        }

        public async Task<AdminDashboardViewModel> ActiveState(AdminDashboardViewModel obj)
        {
            List<RequestClient> clients = await _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Include(a => a.Request.RequestStatusLogs).Where(a => a.Request.Status == 3).ToListAsync();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = clients;

            if (clients != null)
            {
                if (!string.IsNullOrWhiteSpace(obj.patientname))
                {
                    model.requestClients = model.requestClients.Where(a => a.FirstName.ToLower().Contains(obj.patientname.ToLower()) || a.LastName.ToLower().Contains(obj.patientname.ToLower())).ToList();
                }
                if (obj.requesttype == 1 || obj.requesttype == 2 || obj.requesttype == 3 || obj.requesttype == 4)
                {
                    model.requestClients = model.requestClients.Where(a => a.Request.RequestTypeId == obj.requesttype).ToList();
                }
                if (obj.region != 0)
                {
                    model.requestClients = model.requestClients.Where(a => a.RegionId == obj.region).ToList();
                }
                int count = model.requestClients.Count();
                int TotalPage = (int)Math.Ceiling(count / (double)5);
                model.requestClients = model.requestClients.Skip((obj.requestedPage - 1) * 5).Take(5).ToList();
                model.CurrentPage = obj.requestedPage;
                model.TotalPage = TotalPage;
            }

            return model;
        }

        public async Task<AdminDashboardViewModel> ConcludeState(AdminDashboardViewModel obj)
        {
            List<RequestClient> clients = await _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 4).ToListAsync();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = clients;

            if (clients != null)
            {
                if (!string.IsNullOrWhiteSpace(obj.patientname))
                {
                    model.requestClients = model.requestClients.Where(a => a.FirstName.ToLower().Contains(obj.patientname.ToLower()) || a.LastName.ToLower().Contains(obj.patientname.ToLower())).ToList();
                }
                if (obj.requesttype == 1 || obj.requesttype == 2 || obj.requesttype == 3 || obj.requesttype == 4)
                {
                    model.requestClients = model.requestClients.Where(a => a.Request.RequestTypeId == obj.requesttype).ToList();
                }
                if (obj.region != 0)
                {
                    model.requestClients = model.requestClients.Where(a => a.RegionId == obj.region).ToList();
                }
                int count = model.requestClients.Count();
                int TotalPage = (int)Math.Ceiling(count / (double)5);
                model.requestClients = model.requestClients.Skip((obj.requestedPage - 1) * 5).Take(5).ToList();
                model.CurrentPage = obj.requestedPage;
                model.TotalPage = TotalPage;
            }

            return model;
        }
    }
}
