using Common.Enum;
using Data.Context;
using Data.Entity;
using HalloDoc.Utility;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Models;

namespace Services.Implementation
{
    public class ProviderServices : IProviderServices
    {
        private ApplicationDbContext _context;
        public ProviderServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminDashboardViewModel> ProviderDashboard(string email)
        {
            Physician? physician = await _context.Physicians.FirstOrDefaultAsync(a => a.Email == email);

            if (physician != null)
            {
                var requestCount1 = await _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 1 && a.Request.PhysicianId == physician!.PhysicianId).CountAsync();
                var requestCount2 = await _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 2 && a.Request.PhysicianId == physician!.PhysicianId).CountAsync();
                var requestCount3 = await _context.RequestClients.Include(a => a.Request).Where(a => (a.Request.Status == 4 || a.Request.Status == 5) && (a.Request.PhysicianId == physician!.PhysicianId)).CountAsync();
                var requestCount4 = await _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 6 && a.Request.PhysicianId == physician!.PhysicianId).CountAsync();

                AdminDashboardViewModel model = new AdminDashboardViewModel()
                {
                    newCount = requestCount1,
                    pendingCount = requestCount2,
                    activeCount = requestCount3,
                    concludeCount = requestCount4,
                };
                return model;
            }
            return new AdminDashboardViewModel();
        }

        public async Task<AdminDashboardViewModel> NewState(AdminDashboardViewModel obj, string email)
        {
            List<RequestClient> clients = await _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 1).ToListAsync();
            Physician? physician = await _context.Physicians.FirstOrDefaultAsync(a => a.Email == email);
            clients = clients.Where(a => a.Request.PhysicianId == physician?.PhysicianId).ToList();

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

        public async Task<AdminDashboardViewModel> PendingState(AdminDashboardViewModel obj, string email)
        {
            List<RequestClient> clients = await _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Include(a => a.Request.RequestStatusLogs).Where(a => a.Request.Status == 2).ToListAsync();
            Physician? physician = await _context.Physicians.FirstOrDefaultAsync(a => a.Email == email);
            clients = clients.Where(a => a.Request.PhysicianId == physician?.PhysicianId).ToList();

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

        public async Task<AdminDashboardViewModel> ActiveState(AdminDashboardViewModel obj, string email)
        {
            List<RequestClient> clients = await _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Include(a => a.Request.RequestStatusLogs).Where(a => a.Request.Status == 4 || a.Request.Status == 5).ToListAsync();
            Physician? physician = await _context.Physicians.FirstOrDefaultAsync(a => a.Email == email);
            clients = clients.Where(a => a.Request.PhysicianId == physician?.PhysicianId).ToList();

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

        public async Task<AdminDashboardViewModel> ConcludeState(AdminDashboardViewModel obj, string email)
        {
            List<RequestClient> clients = await _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 6).ToListAsync();
            Physician? physician = await _context.Physicians.FirstOrDefaultAsync(a => a.Email == email);
            clients = clients.Where(a => a.Request.PhysicianId == physician?.PhysicianId).ToList();

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

        public async Task AcceptCase(int request_id)
        {
            var data = await _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefaultAsync();
            if (data != null)
            {
                data.Status = (int)RequestStatus.Accepted;
                RequestStatusLog requestStatusLog = new RequestStatusLog()
                {
                    RequestId = request_id,
                    Status = (int)RequestStatus.Accepted,
                    TransToPhysicianId = data.PhysicianId,
                    CreatedDate = DateTime.Now,
                };
                _context.Requests.Update(data);
                await _context.RequestStatusLogs.AddAsync(requestStatusLog);
                await EmailSender.SendEmail("vijay.aniyaliya@etatvasoft.com", "Agreement Video", $"Watch Aggreement Viedo Agreement Video</a>");
            }
            await _context.SaveChangesAsync();
        }

        public async Task AddNotes(ViewNotesViewModel model, int request_id, string email)
        {
            var data = await _context.RequestNotes.Where(a => a.RequestId == request_id).FirstOrDefaultAsync();
            AspNetUser? aspNetUser = await _context.AspNetUsers.FirstOrDefaultAsync(a => a.Email == email);

            if (data != null)
            {
                data!.PhysicianNotes = model.AdditionalNotes;
                data.ModifiedBy = aspNetUser!.Id;
                data.ModifiedDate = DateTime.Now;
                _context.RequestNotes.Update(data);
            }
            else
            {
                RequestNote requestNote = new RequestNote()
                {
                    RequestId = request_id,
                    PhysicianNotes = model.AdditionalNotes,
                    CreatedBy = aspNetUser!.Id,
                    CreatedDate = DateTime.Now,
                };
                _context.RequestNotes.Add(requestNote);
            }
            await _context.SaveChangesAsync();
        }

        public async Task TransferCaseToAdmin(int request_id, string reason, string email)
        {
            var data = await _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefaultAsync();
            Physician? physician = await _context.Physicians.FirstOrDefaultAsync(a => a.Email == email);


            if (data != null)
            {
                data.Status = (int)RequestStatus.Unassigned;
                data.PhysicianId = null;
                RequestStatusLog requestStatusLog = new RequestStatusLog()
                {
                    RequestId = request_id,
                    Status = (int)RequestStatus.Unassigned,
                    Notes = reason,
                    PhysicianId = data.PhysicianId,
                    CreatedDate = DateTime.Now,
                };
                _context.Requests.Update(data);
                await _context.RequestStatusLogs.AddAsync(requestStatusLog);
            }
            await _context.SaveChangesAsync();
        }
    }
}
