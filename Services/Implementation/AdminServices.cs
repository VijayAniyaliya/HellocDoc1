using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Entity;
using HellocDoc1.Services.Models;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Models;

namespace Services.Implementation
{
    public class AdminServices : IAdminServices
    {
        private ApplicationDbContext _context;
        public AdminServices(ApplicationDbContext context)
        {
            _context = context;

        }

        public AdminDashboardViewModel AdminDashboard()
        {
            var requestCount1 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 1).Count();
            var requestCount2 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 2).Count();
            var requestCount3 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 3).Count();
            var requestCount4 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 4).Count();
            var requestCount5 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 5).Count();
            var requestCount6 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 6).Count();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                newCount = requestCount1,
                pendingCount = requestCount2,
                activeCount = requestCount3,
                concludeCount = requestCount4,
                tocloseCount = requestCount5,
                unpaidCount = requestCount6
            };
            return model;

        }
        public AdminDashboardViewModel NewState()
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 1).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = clients;
            return model;

        }

        public List<RequestClient> PendingState()
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 2).ToList();
            return clients;

        }

        public List<RequestClient> ActiveState()
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 3).ToList();
            return clients;

        }

        public List<RequestClient> ConcludeState()
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 4).ToList();
            return clients;

        }

        public List<RequestClient> ToCloseState()
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 5).ToList();
            return clients;

        }

        public List<RequestClient> UnpaidState()
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 6).ToList();
            return clients;

        }

        public ViewCaseViewModel ViewCase(int request_id)
        {
            var data = _context.RequestClients.Include(a => a.Request).Where(a => a.RequestClientId == request_id).FirstOrDefault();
            ViewCaseViewModel model = new ViewCaseViewModel();
            model.PatientNotes = data?.Notes!;
            model.FirstName = data.FirstName;
            model.LastName = data.LastName;
            model.DOB = DateTime.Parse((data.IntDate).ToString() + "-" + data.StrMonth + "-" + (data.IntYear).ToString());
            model.PhoneNumber = data.PhoneNumber;
            model.Email = data.Email;
            model.Region = data.City;
            model.Address = data.City + " " + data.State + " " + data.ZipCode;
            model.RequestTypeId = data.Request.RequestTypeId;
            model.Status = data.Request.Status;

            return model;

        }

        public ViewNotesViewModel ViewNotes(int request_id)
        {
            var data = _context.RequestStatusLogs.Where(a => a.RequestId == request_id).FirstOrDefault();
            var data1 = _context.RequestNotes.Where(a => a.RequestId == request_id).FirstOrDefault();
            ViewNotesViewModel model = new ViewNotesViewModel();
            model.TransferNotes = data?.Notes;
            model.PhysicianNotes = data1?.PhysicianNotes;
            model.AdminNotes = data1?.AdminNotes;
            model.RequestId = request_id;

            return model;

        }

        public void AddNotes(ViewNotesViewModel model, int request_id)
        {
            var data = _context.RequestNotes.Where(a => a.RequestId == request_id).FirstOrDefault();
            data!.AdminNotes = model.AdditionalNotes;

            _context.Update(data);
            _context.SaveChanges();
        }

        public CancelCaseViewModel CancelDetails(int request_id)
        {
            List<CaseTag> data = _context.CaseTags.ToList();
            List<CaseTagViewModel> obj = data.Select(a => new CaseTagViewModel() { CaseId = a.CaseTagId, CaseName = a.Name }).ToList();
            var data1 = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();

            CancelCaseViewModel model = new CancelCaseViewModel()
            {
                RequestId = request_id,
                Name = data1.FirstName + " " + data1.LastName,
                ReasonForCancel = obj,

            };
            return model;
        }

        public async Task CancelCase(CancelCaseViewModel model, int request_id)
        {
            var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();
            data.Status = 5;
            data.CaseTag = model.CaseTag;
            RequestStatusLog requestStatusLog = new RequestStatusLog()
            {
                RequestId = request_id,
                Status = 5,
                Notes = model.AdditionalNotes,
                CreatedDate = DateTime.Now,

            };

            _context.Requests.Update(data);
            await _context.RequestStatusLogs.AddAsync(requestStatusLog);
            await _context.SaveChangesAsync();
        }

        public AssignCaseViewModel AssignDetails(int request_id)
        {
            List<Region> data = _context.Regions.ToList();
            AssignCaseViewModel model = new AssignCaseViewModel()
            {
                RequestId=request_id,
                Regions = data,
            };
            return model;
        }

        public List<PhysicianSelectlViewModel> FilterData(int regionid) 
        {
            List<Physician> data=_context.Physicians.Where(a=> a.RegionId == regionid).ToList();
            List<PhysicianSelectlViewModel> data1 = data.Select(a => new PhysicianSelectlViewModel() { Name = a.FirstName, PhysicianId = a.PhysicianId }).ToList();

            return data1;
        }

        public async Task AssignCase(AssignCaseViewModel model, int request_id)
        {
            var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();
            data.Status = 2;
            RequestStatusLog requestStatusLog = new RequestStatusLog()
            {
                RequestId = request_id,
                Status = 2,
                TransToPhysicianId=model.PhysicianId,
                Notes = model.Description,
                CreatedDate = DateTime.Now,

            };

            _context.Requests.Update(data);
            await _context.RequestStatusLogs.AddAsync(requestStatusLog);
            await _context.SaveChangesAsync();
        }

        public BlockCaseViewModel BlockDetails(int request_id)
        {
            var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();

            BlockCaseViewModel model = new BlockCaseViewModel()
            {
                RequestId = request_id,
                Name = data.FirstName + " " + data.LastName,
            };
            return model;
        }

        public async Task BlockCase(BlockCaseViewModel model, int request_id)
        {
            var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();
            data.Status = 10;
            RequestStatusLog requestStatusLog = new RequestStatusLog()
            {
                RequestId = request_id,
                Status = 10,
                Notes = model.ReasonForBlock,
                CreatedDate = DateTime.Now,

            };

            BlockRequest blockRequest = new BlockRequest()
            {
                PhoneNumber = data.PhoneNumber,
                Email = data.Email,
                Reason = model.ReasonForBlock,
                RequestId = request_id.ToString(),
                CreatedDate= DateTime.Now,
            };

            _context.Requests.Update(data);
            await _context.RequestStatusLogs.AddAsync(requestStatusLog);
            await _context.BlockRequests.AddAsync(blockRequest);
            await _context.SaveChangesAsync();
        }
    }
}
