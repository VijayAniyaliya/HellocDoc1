using Data.Context;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Services.Implementation;
using Services.Models;
using System.Collections;

namespace Services.Contracts
{

    public class RecordsServices : IRecordsServices
    {
        private ApplicationDbContext _context;

        public RecordsServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PatientHistoryViewModel> PatientHistory(PatientHistoryViewModel obj)
        {
            List<User> users = await _context.Users.ToListAsync();

            if (users != null)
            {
                users = users.Where(a =>
                    (string.IsNullOrWhiteSpace(obj.FirstName) || a.FirstName.ToLower().Contains(obj.FirstName.ToLower())) &&
                    (string.IsNullOrWhiteSpace(obj.LastName) || a.LastName.ToLower().Contains(obj.LastName.ToLower())) &&
                    (string.IsNullOrWhiteSpace(obj.Email) || a.Email.ToLower().Contains(obj.Email.ToLower())) &&
                    (string.IsNullOrWhiteSpace(obj.PhoneNumber) || a.Mobile.Contains(obj.PhoneNumber))
                ).ToList();

                int count = users.Count();
                int TotalPage = (int)Math.Ceiling(count / (double)5);
                users = users.Skip((obj.requestedPage - 1) * 5).Take(5).ToList();

                PatientHistoryViewModel model = new PatientHistoryViewModel()
                {
                    Users = users,
                    CurrentPage = obj.requestedPage,
                    TotalPage = TotalPage,
                };
                return model;
            }
            return new PatientHistoryViewModel();
        }

        public async Task<PatientHistoryViewModel> PatientRecords(int userid)
        {
            List<RequestClient>? requestClient = await _context.RequestClients.Include(a => a.Request).Include(a => a.Request.Physician).Where(a => a.Request.UserId == userid).ToListAsync();

            if (requestClient != null)
            {
                PatientHistoryViewModel model = new PatientHistoryViewModel()
                {
                    requestClients = requestClient!,
                };
                return model;
            }
            return new PatientHistoryViewModel();
        }

        public async Task<SearchRecordsViewModel> SearchRecords(SearchRecordsViewModel obj)
        {
            //obj.requestedPage = 1;
            List<RequestClient> requestClients = await _context.RequestClients
                .Include(a => a.Request).Include(a => a.Request.Physician)
                .Include(a => a.Request.RequestNotes)
                .Include(a => a.Request.RequestStatusLogs)
                .ToListAsync();

            if (requestClients != null)
            {
                requestClients = requestClients.Where(a =>

                    (obj.RequestStatus == 0 || a.Request.Status == obj.RequestStatus) &&
                     (obj.FromDate == new DateTime() || DateOnly.FromDateTime(a.Request.AcceptedDate.Value) >= DateOnly.FromDateTime(obj.FromDate)) &&
                      (obj.ToDate == new DateTime() || DateOnly.FromDateTime(a.Request.AcceptedDate.Value) <= DateOnly.FromDateTime(obj.ToDate)) &&
                    (string.IsNullOrWhiteSpace(obj.PatientName) || a.FirstName.ToLower().Contains(obj.PatientName.ToLower()) || a.LastName.ToLower().Contains(obj.PatientName.ToLower())) &&
                    (obj.RequestType == 0 || a.Request.RequestTypeId == obj.RequestType) &&
                    (string.IsNullOrWhiteSpace(obj.ProviderName) || a.Request.PhysicianId != null && a.Request.Physician.FirstName.ToLower().Contains(obj.ProviderName.ToLower())) &&
                    (string.IsNullOrWhiteSpace(obj.Email) || a.Email.ToLower().Contains(obj.Email.ToLower())) &&
                    (string.IsNullOrWhiteSpace(obj.PhoneNumber) || a.PhoneNumber.Contains(obj.PhoneNumber))
                ).ToList();

                int count = requestClients.Count();
                int TotalPage = (int)Math.Ceiling(count / (double)5);
                requestClients = requestClients.Skip((obj.requestedPage - 1) * 5).Take(5).ToList();

                SearchRecordsViewModel model = new SearchRecordsViewModel()
                {
                    requestClients = requestClients,
                    CurrentPage = obj.requestedPage,
                    TotalPage = TotalPage,
                };
                return model;
            }
            return new SearchRecordsViewModel();
        }

        public async Task<LogsDataViewModel> EmailLogs()
        {
            List<Role> roles = await _context.Roles.ToListAsync();

            if (roles != null)
            {
                LogsDataViewModel model = new LogsDataViewModel()
                {
                    Roles = roles
                };
                return model;
            }
            return new LogsDataViewModel();
        }

        public async Task<LogsDataViewModel> EmailLogsData(LogsDataViewModel model)
        {
            List<EmailLog> emailLogs = await _context.EmailLogs.ToListAsync();
            List<Physician> physicians = await _context.Physicians.ToListAsync();
            List<RequestClient> requestClients = await _context.RequestClients.Include(a => a.Request).ToListAsync();
            List<Role> roles = await _context.Roles.ToListAsync();

            if (emailLogs != null)
            {
                List<LogsData> logs = emailLogs.Select(a => new LogsData()
                {
                    ReceiverName = a.RequestId == null ? (physicians.FirstOrDefault(x => x.PhysicianId == a.PhysicianId)?.FirstName + " " + physicians.FirstOrDefault(x => x.PhysicianId == a.PhysicianId)?.LastName) : (requestClients.FirstOrDefault(x => x.RequestId == a.RequestId)?.FirstName + " " + requestClients.FirstOrDefault(x => x.RequestId == a.RequestId)?.LastName),
                    Email = a.EmailId!,
                    RoleId = a.RoleId!.Value,
                    CreatedDate = a.CreateDate,
                    SentDate = a.SentDate!.Value,
                    ConfirmationNo = a.RequestId == null ? "" : (requestClients.FirstOrDefault(x => x.Request.RequestId == a.RequestId)!.Request.ConfirmationNumber)!,
                    Action = a.SubjectName,
                    RoleName = roles.FirstOrDefault(x => x.RoleId == a.RoleId)!.Name,
                    IsEmailSent = a.IsEmailSent!,
                    SentTries = a.SentTries!.Value,
                }).ToList();

                logs = logs.Where(a =>
                (model.RoleId == 0 || a.RoleId == model.RoleId) &&
                (string.IsNullOrWhiteSpace(model.ReceiverName) || a.ReceiverName.ToLower().Contains(model.ReceiverName)) &&
                (model.CreatedDate == new DateTime() || DateOnly.FromDateTime(a.CreatedDate.Date) == DateOnly.FromDateTime(model.CreatedDate)) &&
                (model.SentDate == new DateTime() || DateOnly.FromDateTime(a.SentDate) == DateOnly.FromDateTime(model.SentDate)) &&
                (string.IsNullOrWhiteSpace(model.Email) || a.Email!.ToLower().Contains(model.Email.ToLower())))
                .ToList();

                int count = logs.Count();
                int TotalPage = (int)Math.Ceiling(count / (double)5);
                logs = logs.Skip((model.requestedPage - 1) * 5).Take(5).ToList();

                LogsDataViewModel logsDataViewModel = new LogsDataViewModel()
                {
                    logsDatas = logs,
                    CurrentPage = model.CurrentPage,
                    TotalPage = TotalPage,
                };
                return logsDataViewModel;
            }
            return new LogsDataViewModel();
        }

        public async Task<LogsDataViewModel> SMSLogsData(LogsDataViewModel model)
        {
            List<Smslog> smslogs = await _context.Smslogs.ToListAsync();
            List<Physician> physicians = await _context.Physicians.ToListAsync();
            List<RequestClient> requestClients = await _context.RequestClients.Include(a => a.Request).ToListAsync();
            List<Role> roles = await _context.Roles.ToListAsync();

            if (smslogs != null)
            {
                List<LogsData> logs = smslogs.Select(a => new LogsData()
                {
                    ReceiverName = a.RequestId == null ? (physicians.FirstOrDefault(x => x.PhysicianId == a.PhysicianId)?.FirstName + " " + physicians.FirstOrDefault(x => x.PhysicianId == a.PhysicianId)?.LastName) : (requestClients.FirstOrDefault(x => x.RequestId == a.RequestId)?.FirstName + " " + requestClients.FirstOrDefault(x => x.RequestId == a.RequestId)?.LastName),
                    PhoneNumber = a.MobileNumber!,
                    CreatedDate = a.CreateDate,
                    RoleId = a.RoleId!.Value,
                    SentDate = a.SentDate!.Value,
                    ConfirmationNo = a.RequestId == null ? "" : (requestClients.FirstOrDefault(x => x.Request.RequestId == a.RequestId)!.Request.ConfirmationNumber)!,
                    RoleName = roles.FirstOrDefault(x => x.RoleId == a.RoleId)!.Name,
                    IsEmailSent = a.IsSmssent!,
                    SentTries = a.SentTries,
                }).ToList();

                logs = logs.Where(a =>
                (model.RoleId == 0 || a.RoleId == model.RoleId) &&
                (string.IsNullOrWhiteSpace(model.ReceiverName) || a.ReceiverName.ToLower().Contains(model.ReceiverName)) &&
                (model.CreatedDate == new DateTime() || DateOnly.FromDateTime(a.CreatedDate.Date) == DateOnly.FromDateTime(model.CreatedDate)) &&
                (model.SentDate == new DateTime() || DateOnly.FromDateTime(a.SentDate) == DateOnly.FromDateTime(model.SentDate)) &&
                (string.IsNullOrWhiteSpace(model.Email) || a.Email!.ToLower().Contains(model.Email.ToLower())))
                .ToList();

                int count = logs.Count();
                int TotalPage = (int)Math.Ceiling(count / (double)5);
                logs = logs.Skip((model.requestedPage - 1) * 5).Take(5).ToList();

                LogsDataViewModel logsDataViewModel = new LogsDataViewModel()
                {
                    logsDatas = logs,
                    CurrentPage = model.CurrentPage,
                    TotalPage = TotalPage,
                };
                return logsDataViewModel;
            }
            return new LogsDataViewModel();
        }

        public async Task<BlockHistoryViewModel> BlockHistoryData(BlockHistoryViewModel obj)
        {
            List<BlockRequest> blockRequests = await _context.BlockRequests.ToListAsync();
            List<RequestClient> requestClients = await _context.RequestClients.Include(a => a.Request).ToListAsync();

            if (blockRequests != null && requestClients != null)
            {
                List<blockdata> blockdatas = blockRequests.Select(a => new blockdata()
                {
                    BlockRequestId = a.BlockRequestId,
                    PatientName = requestClients.FirstOrDefault(x => x.RequestId == int.Parse(a.RequestId))?.FirstName + " " + requestClients.FirstOrDefault(x => x.RequestId == int.Parse(a.RequestId))?.LastName,
                    PhoneNumber = a.PhoneNumber!,
                    Email = a.Email!,
                    CreatedDate = a.CreatedDate!.Value,
                    Notes = a.Reason!,
                    IsActive = a.IsActive!,
                }).ToList();

                if (!string.IsNullOrWhiteSpace(obj.Name))
                {
                    requestClients = requestClients.Where(a => a.FirstName.ToLower().Contains(obj.Name.ToLower()) || a.LastName.ToLower().Contains(obj.Name.ToLower())).ToList();
                }

                blockdatas = blockdatas.Where(a =>

                (obj.Date == new DateTime() || DateOnly.FromDateTime(a.CreatedDate.Date) == DateOnly.FromDateTime(obj.Date)) &&
                (string.IsNullOrWhiteSpace(obj.Email) || a.Email.ToLower().Contains(obj.Email.ToLower())) &&
                (string.IsNullOrWhiteSpace(obj.Name) || a.PatientName.ToLower().Contains(obj.Name)) &&
                (string.IsNullOrWhiteSpace(obj.PhoneNumber) || a.PhoneNumber.Contains(obj.PhoneNumber)))
                .ToList();

                int count = blockdatas.Count();
                int TotalPage = (int)Math.Ceiling(count / (double)5);
                blockdatas = blockdatas.Skip((obj.requestedPage - 1) * 5).Take(5).ToList();

                BlockHistoryViewModel model = new BlockHistoryViewModel()
                {
                    blockRequests = blockdatas,
                    CurrentPage = obj.requestedPage,
                    TotalPage = TotalPage,
                };
                return model;
            }
            return new BlockHistoryViewModel();
        }

        public async Task UnblockCase(int requestid)
        {
            BlockRequest? blockRequest = await _context.BlockRequests.Where(a => a.BlockRequestId == requestid).FirstOrDefaultAsync();
            Request? request = await _context.Requests.Where(a => a.RequestId == int.Parse(blockRequest!.RequestId)).FirstOrDefaultAsync();

            if (blockRequest != null)
            {
                blockRequest.IsActive = new BitArray(new[] { false });
                blockRequest.ModifiedDate = DateTime.Now;
                request!.Status = 1;
            }
            _context.BlockRequests.Update(blockRequest!);
            _context.Requests.Update(request!);
            await _context.SaveChangesAsync();
        }
    }
}
