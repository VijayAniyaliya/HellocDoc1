using Common.Enum;
using Common.Helpers;
using Data.Context;
using Data.Entity;
using HalloDoc.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Services.Contracts;
using Services.Models;
using System.Collections;

namespace Services.Implementation
{
    public class AdminServices : IAdminServices
    {
        private ApplicationDbContext _context;
        private IWebHostEnvironment _environment;
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 6)
                      + Path.GetExtension(fileName);
        }
        public AdminServices(ApplicationDbContext context, IWebHostEnvironment hostEnvironment /*IHostingEnvironment hostingEnvironment*/)
        {
            _context = context;
            _environment = hostEnvironment;
        }

        public async Task<AdminDashboardViewModel> AdminDashboard()
        {
            var requestCount1 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 1).Count();
            var requestCount2 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 2).Count();
            var requestCount3 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 3).Count();
            var requestCount4 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 4).Count();
            var requestCount5 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 5).Count();
            var requestCount6 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 6).Count();
            List<Region> regions = await _context.Regions.ToListAsync();

            AdminDashboardViewModel model = new AdminDashboardViewModel()
            {
                newCount = requestCount1,
                pendingCount = requestCount2,
                activeCount = requestCount3,
                concludeCount = requestCount4,
                tocloseCount = requestCount5,
                unpaidCount = requestCount6,
                regions = regions,
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

        public async Task<AdminDashboardViewModel> ToCloseState(AdminDashboardViewModel obj)
        {
            List<RequestClient> clients = await _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Include(a => a.Region).Include(a => a.Request.RequestStatusLogs).Where(a => a.Request.Status == 5).ToListAsync();
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

        public async Task<AdminDashboardViewModel> UnpaidState(AdminDashboardViewModel obj)
        {
            List<RequestClient> clients = await _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 6).ToListAsync();
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

        public async Task<ViewCaseViewModel> ViewCase(int request_id)
        {
            var data = await _context.RequestClients.Include(a => a.Request).Where(a => a.RequestId == request_id).FirstOrDefaultAsync();
            ViewCaseViewModel model = new ViewCaseViewModel();

            if (data != null)
            {
                model.PatientNotes = data?.Notes!;
                model.FirstName = data?.FirstName!;
                model.LastName = data.LastName;
                model.DOB = DateTime.Parse((data.IntDate).ToString() + "/" + data.StrMonth + "/" + (data.IntYear).ToString());
                model.PhoneNumber = data.PhoneNumber;
                model.Email = data.Email;
                model.Region = data.City;
                model.Address = data.City + " " + data.State + " " + data.ZipCode;
                model.RequestId = request_id;
                model.RequestTypeId = data.Request.RequestTypeId;
                model.Status = data.Request.Status;
            }

            return model;
        }

        public async Task<ViewNotesViewModel> ViewNotes(int request_id)
        {
            List<RequestStatusLog> data = await _context.RequestStatusLogs.Where(a => a.RequestId == request_id).ToListAsync();
            var data1 = _context.RequestNotes.Where(a => a.RequestId == request_id).FirstOrDefault();
            ViewNotesViewModel model = new ViewNotesViewModel();

            if (data != null || data1 != null)
            {
                model.TransferNotes = new List<TransferNote>();
                foreach (var item in data!)
                {
                    TransferNote transferNotes = new TransferNote
                    {
                        Notes = item.Notes,
                        CreatedDate = item.CreatedDate
                    };
                    model.TransferNotes.Add(transferNotes);
                }
                model.PhysicianNotes = data1?.PhysicianNotes;
                model.AdminNotes = data1?.AdminNotes;
                model.RequestId = request_id;
            }
            return model;
        }

        public async Task AddNotes(ViewNotesViewModel model, int request_id, string email)
        {
            var data = await _context.RequestNotes.Where(a => a.RequestId == request_id).FirstOrDefaultAsync();
            AspNetUser? aspNetUser = await _context.AspNetUsers.FirstOrDefaultAsync(a => a.Email == email);

            if (data != null)
            {
                data!.AdminNotes = model.AdditionalNotes;
                data.ModifiedBy = aspNetUser!.Id;
                data.ModifiedDate = DateTime.Now;
                _context.RequestNotes.Update(data);
            }
            else
            {
                RequestNote requestNote = new RequestNote()
                {
                    RequestId = request_id,
                    AdminNotes = model.AdditionalNotes,
                    CreatedBy = aspNetUser!.Id,
                    CreatedDate = DateTime.Now,
                };
                _context.RequestNotes.Add(requestNote);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<CancelCaseViewModel> CancelDetails(int request_id)
        {
            List<CaseTag> data = await _context.CaseTags.ToListAsync();
            List<CaseTagViewModel> obj = data.Select(a => new CaseTagViewModel() { CaseId = a.CaseTagId, CaseName = a.Name }).ToList();
            var data1 = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();

            if (data != null && data1 != null)
            {
                CancelCaseViewModel model = new CancelCaseViewModel()
                {
                    RequestId = request_id,
                    Name = data1.FirstName + " " + data1.LastName,
                    ReasonForCancel = obj,
                };
                return model;
            }
            return new CancelCaseViewModel();
        }

        public async Task CancelCase(int request_id, int caseId, string cancelNote)
        {
            var data = await _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefaultAsync();
            var reason = await _context.CaseTags.Where(a => a.CaseTagId == caseId).FirstOrDefaultAsync();

            if (data != null && reason != null)
            {
                data.Status = 5;
                data.CaseTag = reason.Name;
                RequestStatusLog requestStatusLog = new RequestStatusLog()
                {
                    RequestId = request_id,
                    Status = 5,
                    Notes = cancelNote,
                    CreatedDate = DateTime.Now,
                };
                _context.Requests.Update(data);
                await _context.RequestStatusLogs.AddAsync(requestStatusLog);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<AssignCaseViewModel> AssignDetails(int request_id)
        {
            List<Region> data = await _context.Regions.ToListAsync();

            if (data != null)
            {

                AssignCaseViewModel model = new AssignCaseViewModel()
                {
                    RequestId = request_id,
                    Regions = data,
                };
                return model;
            }
            return new AssignCaseViewModel();
        }

        public async Task<List<PhysicianSelectlViewModel>> FilterData(int regionid)
        {
            List<Physician> data = await _context.Physicians.Where(a => a.RegionId == regionid).ToListAsync();

            if (data != null)
            {

                List<PhysicianSelectlViewModel> data1 = data.Select(a => new PhysicianSelectlViewModel()
                {
                    Name = a.FirstName,
                    PhysicianId = a.PhysicianId
                }).ToList();

                return data1;
            }
            return new List<PhysicianSelectlViewModel>();
        }

        public async Task AssignCase(int request_id, int physicianid, string description)
        {
            var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();

            if (data != null)
            {

                data.Status = 2;
                data.PhysicianId = physicianid;
                RequestStatusLog requestStatusLog = new RequestStatusLog()
                {
                    RequestId = request_id,
                    Status = 2,
                    TransToPhysicianId = physicianid,
                    Notes = description,
                    CreatedDate = DateTime.Now,
                };

                _context.Requests.Update(data);
                await _context.RequestStatusLogs.AddAsync(requestStatusLog);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<BlockCaseViewModel> BlockDetails(int request_id)
        {
            var data = await _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefaultAsync();
            if (data != null)
            {
                BlockCaseViewModel model = new BlockCaseViewModel()
                {
                    RequestId = request_id,
                    Name = data.FirstName + " " + data.LastName,
                };
                return model;
            }
            return new BlockCaseViewModel();
        }

        public async Task BlockCase(int request_id, string reason)
        {
            var data = await _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefaultAsync();

            if (data != null)
            {
                data.Status = 10;
                RequestStatusLog requestStatusLog = new RequestStatusLog()
                {
                    RequestId = request_id,
                    Status = 10,
                    Notes = reason,
                    CreatedDate = DateTime.Now,
                };

                BlockRequest blockRequest = new BlockRequest()
                {
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email,
                    Reason = reason,
                    RequestId = request_id.ToString(),
                    IsActive = new BitArray(new[] { true }),
                CreatedDate = DateTime.Now,
                };
                _context.Requests.Update(data);
                await _context.RequestStatusLogs.AddAsync(requestStatusLog);
                await _context.BlockRequests.AddAsync(blockRequest);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<ViewUploadsViewModel> ViewUploads(int request_id)
        {
            Request? data = await _context.Requests.Include(a => a.RequestWiseFiles).Where(a => a.RequestId == request_id).FirstOrDefaultAsync();

            ViewUploadsViewModel viewUploads = new ViewUploadsViewModel();

            if (data != null)
            {
                data.RequestWiseFiles = data.RequestWiseFiles.Where(x => x.IsDeleted == null || x.IsDeleted[0] == false).ToList();

                viewUploads.RequestId = request_id;
                viewUploads.Name = data.FirstName + " " + data.LastName;

                foreach (var item in data.RequestWiseFiles)
                {
                    DocumentDetail documentDetail = new DocumentDetail()
                    {
                        DocumentId = item.RequestWiseFileId,
                        Document = item.FileName,
                        UploadDate = item.CreatedDate.ToString()
                    };
                    viewUploads.Documents.Add(documentDetail);
                }
            }

            return viewUploads;
        }

        public async Task UploadDocuments(ViewUploadsViewModel model, int request_id)
        {
            if (model.Upload != null)
            {
                IEnumerable<IFormFile> upload = model.Upload;
                foreach (var item in upload)
                {
                    var file = item.FileName;
                    var uniqueFileName = GetUniqueFileName(file);
                    var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream);
                    }

                    RequestWiseFile requestWiseFile = new RequestWiseFile()
                    {
                        FileName = uniqueFileName,
                        CreatedDate = DateTime.Now,
                    };
                    _context.RequestWiseFiles.Add(requestWiseFile);
                    requestWiseFile.RequestId = request_id;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int DocumentId)
        {
            RequestWiseFile? data = await _context.RequestWiseFiles.FirstOrDefaultAsync(a => a.RequestWiseFileId == DocumentId);
            if (data != null)
            {
                data.IsDeleted = new BitArray(new[] { true });
                _context.RequestWiseFiles.Update(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAll(List<int> DocumentId)
        {
            foreach (var item in DocumentId)
            {
                RequestWiseFile? data = await _context.RequestWiseFiles.FirstOrDefaultAsync(a => a.RequestWiseFileId == item);
                if (data != null)
                {
                    data.IsDeleted = new BitArray(new[] { true });
                    _context.RequestWiseFiles.Update(data);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task SendMail(List<int> DocumentId)
        {
            List<string> name = new List<string>();
            foreach (var item in DocumentId)
            {
                RequestWiseFile? data = await _context.RequestWiseFiles.FirstOrDefaultAsync(a => a.RequestWiseFileId == item);
                if (data != null)
                {
                    var file = data.FileName;
                    name.Add(file);
                    var filepath = "C:\\Users\\pca70\\source\\repos\\HellocDoc1\\HellocDoc1\\wwwroot\\uploads";
                    await EmailSender.SendMailOnGmail("aniyariyavijay441@gmail.com", "Your Documents", "Document", name, filepath);
                }
            }
        }

        public async Task<LoginResponseViewModel> AdminLogin(AdminLoginViewModel model)
        {
            var user = await _context.AspNetUsers.Where(u => u.Email == model.Email).Include(a => a.Roles).Include(a => a.Users).FirstOrDefaultAsync();

            if (user == null)
                return new LoginResponseViewModel() { Status = ResponseStatus.Failed, Message = "User Not Found" };
            if (user.PasswordHash == null)
                return new LoginResponseViewModel() { Status = ResponseStatus.Failed, Message = "There is no Password with this Account" };
            if (user.PasswordHash == model.Password)
            {
                var jwtToken = JwtService.GetJwtToken(user);

                return new LoginResponseViewModel() { Status = ResponseStatus.Success, Token = jwtToken };
            }

            return new LoginResponseViewModel() { Status = ResponseStatus.Failed, Message = "Password does not match" };
        }

        public async Task<SendOrdersViewModel> SendOders(int request_id)
        {
            List<HealthProfessionalType> data = await _context.HealthProfessionalTypes.ToListAsync();

            SendOrdersViewModel model = new SendOrdersViewModel();
            if (data != null)
            {
                List<HealthProfession> obj = data.Select(a => new HealthProfession() { ProfessionId = a.HealthProfessionalId, ProfessionName = a.ProfessionName }).ToList();
                model.RequestId = request_id;
                model.HealthProfessions = obj;
            }
            return model;
        }

        public async Task<SendOrdersViewModel> FilterDataByProfession(int ProfessionId)
        {
            List<HealthProfessional> data = await _context.HealthProfessionals.Where(a => a.Profession == ProfessionId).ToListAsync();

            SendOrdersViewModel model = new SendOrdersViewModel();
            if (data != null)
            {
                List<BusinessType> obj = data.Select(a => new BusinessType() { BusinessId = a.VendorId, BusinessName = a.VendorName }).ToList();
                model.Business = obj;
            }
            return model;
        }


        public async Task<SendOrdersViewModel> FilterDataByBusiness(int BusinessId)
        {
            List<HealthProfessional> data = await _context.HealthProfessionals.Where(a => a.VendorId == BusinessId).ToListAsync();

            SendOrdersViewModel model = new SendOrdersViewModel();
            if (data != null)
            {
                List<BusinessType> obj = data.Select(a => new BusinessType() { BusinessId = a.VendorId, BusinessName = a.VendorName, Contact = a.BusinessContact, Email = a.Email, FaxNumber = a.FaxNumber }).ToList();
                model.Business = obj;
            }
            return model;
        }

        public async Task SendOrderDetails(SendOrdersViewModel model, int request_id, int vendorid, string contact, string email, string faxnumber)
        {
            OrderDetail orderDetail = new OrderDetail()
            {
                VendorId = vendorid,
                RequestId = request_id,
                FaxNumber = faxnumber,
                Email = email,
                BusinessContact = contact,
                Prescription = model.Prescription,
                NoOfRefill = model.Refills,
                CreatedDate = DateTime.Now,
            };
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
        }


        public async Task<TransferCaseViewModel> TransferDetails(int request_id)
        {
            List<Region> data = await _context.Regions.ToListAsync();

            if (data != null)
            {

                TransferCaseViewModel model = new TransferCaseViewModel()
                {
                    RequestId = request_id,
                    Regions = data,
                };
                return model;
            }
            return new TransferCaseViewModel();
        }

        public async Task TransferCase(int request_id, int physicianid, string description)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();

                    if (data != null)
                    {
                        data.PhysicianId = physicianid;

                        RequestStatusLog requeststatuslog = new RequestStatusLog
                        {
                            RequestId = request_id,
                            Status = 2,
                            PhysicianId = physicianid,
                            Notes = description,
                            CreatedDate = DateTime.Now,
                            TransToPhysicianId = physicianid
                        };
                        _context.Requests.Update(data);
                        await _context.RequestStatusLogs.AddAsync(requeststatuslog);
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task<ClearCaseViewModel> ClearDetails(int request_id)
        {
            var data = await _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefaultAsync();

            if (data != null)
            {

                ClearCaseViewModel model = new ClearCaseViewModel()
                {
                    RequestId = request_id,
                };
                return model;
            }
            return new ClearCaseViewModel();
        }

        public async Task ClearCase(int request_id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var obj = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();

                    if (obj != null)
                    {
                        obj.Status = 10;
                        RequestStatusLog requestStatusLog = new RequestStatusLog()
                        {
                            RequestId = request_id,
                            Status = 10,
                            CreatedDate = DateTime.Now,

                        };
                        _context.Requests.Update(obj);
                        await _context.RequestStatusLogs.AddAsync(requestStatusLog);
                    }

                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

        }

        public async Task<SendAgreementViewModel> SendAgreementDetails(int request_id)
        {
            var data = await _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefaultAsync();

            if (data != null)
            {

                SendAgreementViewModel model = new SendAgreementViewModel()
                {
                    RequestId = request_id,
                    RequestTypeId = data.RequestTypeId,
                    Email = data.Email,
                    PhoneNumber = data.PhoneNumber,
                };
                return model;
            }
            return new SendAgreementViewModel();
        }

        public async Task SendAgreement(string request_id)
        {
            if (request_id != null)
            {
                await EmailSender.SendEmail("vijay.aniyaliya@etatvasoft.com", "Hello", $"<a href=\"https://localhost:7208/Patient/ReviewAgreement/{request_id}\">Agreement</a>");
            }
        }


        public async Task<CloseCaseViewModel> CloseCase(int request_id)
        {
            RequestClient? data = await _context.RequestClients.Include(a => a.Request).Include(a => a.Request.RequestWiseFiles).Where(a => a.RequestId == request_id).FirstOrDefaultAsync();
            data!.Request.RequestWiseFiles = data.Request.RequestWiseFiles.Where(x => x.IsDeleted == null || x.IsDeleted[0] == false).ToList();

            if (data != null)
            {

                CloseCaseViewModel model = new CloseCaseViewModel()
                {
                    RequestId = request_id,
                    PatientName = data.FirstName + " " + data.LastName,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    DOB = DateTime.Parse((data.IntDate).ToString() + "/" + data.StrMonth + "/" + (data.IntYear).ToString()),
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email
                };

                foreach (var item in data.Request.RequestWiseFiles)
                {
                    DocumentDetails documentDetail = new DocumentDetails()
                    {
                        DocumentId = item.RequestWiseFileId,
                        Document = item.FileName,
                        UploadDate = item.CreatedDate.ToString()
                    };
                    model.Documents.Add(documentDetail);
                }
                return model;
            }
            return new CloseCaseViewModel();
        }

        public async Task SaveCloseCase(CloseCaseViewModel model, int request_id)
        {
            RequestClient? requestClient = await _context.RequestClients.Where(a => a.RequestId == request_id).FirstOrDefaultAsync();

            if (requestClient != null)
            {
                requestClient.Email = model.Email;
                requestClient.PhoneNumber = model.PhoneNumber;
                _context.RequestClients.Update(requestClient);
            }
            await _context.SaveChangesAsync();
        }

        public async Task CloseCaseRequest(int request_id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var obj = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();

                    if (obj != null)
                    {
                        obj.Status = 6;
                        RequestStatusLog requestStatusLog = new RequestStatusLog()
                        {
                            RequestId = request_id,
                            Status = 6,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.RequestStatusLogs.AddAsync(requestStatusLog);
                        await _context.SaveChangesAsync();

                        RequestClosed requestClosed = new RequestClosed()
                        {
                            RequestId = request_id,
                            RequestStatusLogId = requestStatusLog.RequestStatusLogId
                        };
                        await _context.RequestCloseds.AddAsync(requestClosed);
                        _context.Requests.Update(obj);
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task<EncounterFormViewModel> EncounterForm(int request_id)
        {
            RequestClient? data = await _context.RequestClients.Include(a => a.Request).Where(a => a.RequestId == request_id).FirstOrDefaultAsync();
            EncounterForm? obj = await _context.EncounterForms.DefaultIfEmpty().Where(a => a.RequestId == request_id).FirstOrDefaultAsync();

            if (data != null)
            {
                EncounterFormViewModel model = new EncounterFormViewModel()
                {
                    RequestId = request_id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Location = data.Street + " " + data.City + " " + data.State + " " + data.ZipCode,
                    DOB = DateTime.Parse((data.IntDate).ToString() + "/" + data.StrMonth + "/" + (data.IntYear).ToString()),
                    Date = data.Request.CreatedDate,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email,
                };

                if (obj != null)
                {
                    model.HistoryOfPatient = obj.HistoryOfPresentIllnessOrInjury;
                    model.MedicalHistory = obj.MedicalHistory;
                    model.Medications = obj.Medications;
                    model.Allergies = obj.Allergies;
                    model.Temp = obj.Temp;
                    model.HeartRate = obj.Hr;
                    model.RespiratoryRate = obj.Rr;
                    model.BloodPressure = obj.BloodPressureSystolic;
                    model.BloodPressure1 = obj.BloodPressureDiastolic;
                    model.O2 = obj.O2;
                    model.Pain = obj.Pain;
                    model.Heent = obj.Heent;
                    model.CV = obj.Cv;
                    model.Chest = obj.Chest;
                    model.ABD = obj.Abd;
                    model.Extr = obj.Extremeties;
                    model.Skin = obj.Skin;
                    model.Neuro = obj.Neuro;
                    model.Other = obj.Other;
                    model.Disgnosis = obj.Diagnosis;
                    model.TreatmentPlan = obj.TreatmentPlan;
                    model.MedicationDispnsed = obj.MedicationsDispensed;
                    model.Procedure = obj.Procedures;
                    model.FollowUp = obj.FollowUp;
                }
                return model;
            }
            return new EncounterFormViewModel();
        }

        public async Task SubmitEncounterForm(EncounterFormViewModel model, int request_id)
        {
            EncounterForm? encounter = await _context.EncounterForms.Where(a => a.RequestId == request_id).FirstOrDefaultAsync();

            if (encounter == null)
            {
                EncounterForm encounterForm = new EncounterForm()
                {
                    RequestId = request_id,
                    HistoryOfPresentIllnessOrInjury = model.HistoryOfPatient,
                    MedicalHistory = model.MedicalHistory,
                    Medications = model.Medications,
                    Allergies = model.Allergies,
                    Temp = model.Temp,
                    Hr = model.HeartRate,
                    Rr = model.RespiratoryRate,
                    BloodPressureSystolic = model.BloodPressure,
                    BloodPressureDiastolic = model.BloodPressure1,
                    O2 = model.O2,
                    Pain = model.Pain,
                    Heent = model.Heent,
                    Cv = model.CV,
                    Chest = model.Chest,
                    Abd = model.ABD,
                    Extremeties = model.Extr,
                    Skin = model.Skin,
                    Neuro = model.Neuro,
                    Other = model.Other,
                    Diagnosis = model.Disgnosis,
                    TreatmentPlan = model.TreatmentPlan,
                    MedicationsDispensed = model.MedicationDispnsed,
                    Procedures = model.Procedure,
                    FollowUp = model.FollowUp,
                };
                await _context.EncounterForms.AddAsync(encounterForm);
            }

            else
            {
                encounter.HistoryOfPresentIllnessOrInjury = model.HistoryOfPatient;
                encounter.MedicalHistory = model.MedicalHistory;
                encounter.Medications = model.Medications;
                encounter.Allergies = model.Allergies;
                encounter.Temp = model.Temp;
                encounter.Hr = model.HeartRate;
                encounter.Rr = model.RespiratoryRate;
                encounter.BloodPressureSystolic = model.BloodPressure;
                encounter.BloodPressureDiastolic = model.BloodPressure1;
                encounter.O2 = model.O2;
                encounter.Pain = model.Pain;
                encounter.Heent = model.Heent;
                encounter.Cv = model.CV;
                encounter.Chest = model.Chest;
                encounter.Abd = model.ABD;
                encounter.Extremeties = model.Extr;
                encounter.Skin = model.Skin;
                encounter.Neuro = model.Neuro;
                encounter.Other = model.Other;
                encounter.Diagnosis = model.Disgnosis;
                encounter.TreatmentPlan = model.TreatmentPlan;
                encounter.MedicationsDispensed = model.MedicationDispnsed;
                encounter.Procedures = model.Procedure;
                encounter.FollowUp = model.FollowUp;
                _context.EncounterForms.Update(encounter);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<AdminProfileViewModel> ProfileData(string email)
        {
            AspNetUser? aspNetUser = await _context.AspNetUsers.Where(a => a.Email == email).FirstOrDefaultAsync();
            Admin? admin = _context.Admins.Where(a => a.Email == email).FirstOrDefault();
            List<Region> regions = _context.Regions.ToList();
            List<AdminRegion> adminRegions = _context.AdminRegions.Where(a => a.AdminId == admin.AdminId).ToList();

            if (aspNetUser != null && admin != null && regions != null)
            {
                AdminProfileViewModel model = new AdminProfileViewModel()
                {
                    AdminID = admin.AdminId,
                    Username = aspNetUser.UserName,
                    Password = aspNetUser.PasswordHash,
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Email = admin.Email,
                    PhoneNumber = admin.Mobile,
                    RegionList = regions,
                    AdminRegionList = adminRegions,
                    Address1 = admin.Address1,
                    Address2 = admin.Address2,
                    City = admin.City,
                    State = admin.City,
                    Zip = admin.Zip,
                    AltPhoneNumber = admin.AltPhone,
                };
                return model;
            }
            return new AdminProfileViewModel();
        }

        public async Task ResetPassword(string email, string password)
        {
            AspNetUser? aspNetUser = await _context.AspNetUsers.Where(a => a.Email == email).FirstOrDefaultAsync();
            if (aspNetUser != null)
            {
                aspNetUser.PasswordHash = password;
                aspNetUser.ModifiedDate = DateTime.Now;
                _context.AspNetUsers.Update(aspNetUser);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdminstrator(ProfileData model, string email)
        {
            Admin? admin = await _context.Admins.Where(a => a.Email == email).FirstOrDefaultAsync();
            AspNetUser? aspNetUser = await _context.AspNetUsers.Where(a => a.Email == email).FirstOrDefaultAsync();

            if (admin != null && aspNetUser != null)
            {
                List<AdminRegion> adminRegions = await _context.AdminRegions.Where(a => a.AdminId == admin.AdminId).ToListAsync();
                foreach (var item in adminRegions)
                {
                    _context.AdminRegions.Remove(item);
                }
                foreach (var item in model.RegionSelected)
                {
                    AdminRegion adminRegion = new AdminRegion();
                    adminRegion.AdminId = admin.AdminId;
                    adminRegion.RegionId = item;
                    await _context.AdminRegions.AddAsync(adminRegion);
                }
                admin.FirstName = model.firstname;
                admin.LastName = model.lastname;
                admin.Email = model.email;
                admin.Mobile = model.phonenumber;
                admin.ModifiedBy = aspNetUser.Id;
                admin.ModifiedDate = DateTime.Now;
                aspNetUser.UserName = model.firstname + " " + model.lastname;
                aspNetUser.Email = model.email;
                aspNetUser.PhoneNumber = model.phonenumber;
                aspNetUser.ModifiedDate = DateTime.Now;
                _context.Admins.Update(admin);
                _context.AspNetUsers.Update(aspNetUser);
            }

            await _context.SaveChangesAsync();
        }
        public async Task UpdateBillInfo(BillingData model, string email)
        {
            Admin? admin = await _context.Admins.Where(a => a.Email == email).FirstOrDefaultAsync();

            if (admin == null)
            {
                admin!.Address1 = model.address1;
                admin.Address2 = model.address2;
                admin.City = model.city;
                admin.Zip = model.zip;
                admin.AltPhone = model.altphonenumber;
                admin.ModifiedDate = DateTime.Now;
                _context.Admins.Update(admin);
            }
            await _context.SaveChangesAsync();
        }

        public async Task SendLink(SendLinkViewModel model, string email)
        {
            RequestClient? requestClient = await _context.RequestClients.Include(a => a.Request).Where(a => a.Email == model.Email).FirstOrDefaultAsync();
            Admin? admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == email);
            if (requestClient != null && admin != null)
            {
                await EmailSender.SendEmail("vijay.aniyaliya@etatvasoft.com", "Submit Your request", $" <a href=\"https://localhost:7208/Patient/Submit_request_screen/\">Submit Request</a>")!;

                //EmailLog emailLog = new EmailLog()
                //{
                //    EmailLogId = 10,
                //    EmailTemplate = "Submit_request_screen",
                //    SubjectName = "Submit Your Request",
                //    EmailId = model.Email,
                //    AdminId = admin.AdminId,
                //    RoleId = admin.RoleId,
                //    ConfirmationNumber = requestClient.Request.ConfirmationNumber,
                //    RequestId = requestClient.Request.RequestId,
                //    CreateDate = DateTime.Now,
                //    SentDate = DateTime.Now,
                //    IsEmailSent = new BitArray(new[] { true }),
                //    SentTries = 1,
                //};
                //_context.EmailLogs.Add(emailLog);
                //await _context.SaveChangesAsync();
            }
        }

        public async Task SubmitRequest(CreateRequestViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    AspNetUser? aspnetuser = await _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefaultAsync();
                    User user = new User();
                    if (aspnetuser == null)
                    {
                        AspNetUser aspnetuser1 = new AspNetUser()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserName = model.FirstName + " " + model.LastName,
                            Email = model.Email,
                            PhoneNumber = model.PhoneNumber,
                            CreatedDate = DateTime.Now

                        };
                        await _context.AspNetUsers.AddAsync(aspnetuser1);

                        user.AspNetUserId = aspnetuser1.Id;
                        user.UserId = 9;
                        user.FirstName = model.FirstName;
                        user.LastName = model.LastName;
                        user.Email = model.Email;
                        user.Mobile = model.PhoneNumber;
                        user.ZipCode = model.ZipCode;
                        user.State = model.State;
                        user.City = model.City;
                        user.Street = model.Street;
                        user.IntDate = model.DOB.Day;
                        user.IntYear = model.DOB.Year;
                        user.StrMonth = model.DOB.ToString("MMM");
                        user.CreatedDate = DateTime.Now;
                        user.CreatedBy = aspnetuser.UserName;
                        await _context.Users.AddAsync(user);
                    }
                    else
                    {
                        user = _context.Users.Where(a => a.Email == model.Email).FirstOrDefault()!;
                    }

                    var regiondata = _context.Regions.Where(x => x.RegionId == user.RegionId).FirstOrDefault();
                    var requestcount = _context.Requests.Where(a => a.CreatedDate.Date == DateTime.Now.Date && a.CreatedDate.Month == DateTime.Now.Month && a.CreatedDate.Year == DateTime.Now.Year && a.UserId == user.UserId).ToList();
                    Request request = new Request()
                    {
                        UserId = 6,
                        RequestTypeId = 1,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Status = (int)Common.Enum.RequestStatus.Unassigned,
                        CreatedDate = DateTime.Now,
                        IsUrgentEmailSent = new BitArray(1),
                        ConfirmationNumber = regiondata.Abbreviation + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0')
                                             + DateTime.Now.Year.ToString().Substring(2) + model.LastName.Substring(0, 2) + model.FirstName.Substring(0, 2) +
                                             (requestcount.Count() + 1).ToString().PadLeft(4, '0'),
                    };
                    await _context.Requests.AddAsync(request);

                    RequestClient requestclient = new RequestClient()
                    {

                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        IntDate = model.DOB.Day,
                        IntYear = model.DOB.Year,
                        StrMonth = model.DOB.ToString("MMM"),
                        State = model.State,
                        Street = model.Street,
                        City = model.City,
                        ZipCode = model.ZipCode,
                        RegionId = regiondata.RegionId,
                    };
                    await _context.SaveChangesAsync();

                    RequestNote requestNote = new RequestNote()
                    {
                        RequestId = request.RequestId,
                        AdminNotes = model.Notes,
                        CreatedBy = "Admin",
                        CreatedDate = DateTime.Now,
                    };
                    await _context.RequestNotes.AddAsync(requestNote);
                    request.RequestClients.Add(requestclient);
                    await _context.RequestClients.AddAsync(requestclient);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task<ProviderViewModel> provider()
        {
            List<Region> regions = await _context.Regions.ToListAsync();
            ProviderViewModel model = new ProviderViewModel();

            if (regions != null)
            {
                model.Regions = regions;
            }
            return model;
        }

        public async Task<ProviderViewModel> PhysicianData(int region)
        {
            List<Physician> data = await _context.Physicians.Include(x => x.Role).ToListAsync();
            data = data.Where(x => x.IsDeleted == null || x.IsDeleted[0] == false).ToList();
            List<PhysicianNotification> notifications = await _context.PhysicianNotifications.Where(a => a.IsNotificationStopped == (new BitArray(new[] { true }))).ToListAsync();

            if (data != null && notifications != null)
            {
                List<PhysicianData> obj = data.Select(a => new PhysicianData()
                {
                    physicianId = a.PhysicianId,
                    ProviderName = a.FirstName + " " +
                    a.LastName,
                    Status = (int)a.Status!,
                    role = a.Role!.Name,
                    PhysicianNotifications = notifications,
                    region = a.RegionId
                }).ToList();

                if (region != 0)
                {
                    obj = obj.Where(x => x.region == region).ToList();
                }
                ProviderViewModel model = new ProviderViewModel()
                {
                    Physicians = obj,
                };
                return model;
            }
            return new ProviderViewModel();
        }


        public async Task SendMessage(int PhysicianId, string message)
        {
            Physician? data = await _context.Physicians.Where(a => a.PhysicianId == PhysicianId).FirstOrDefaultAsync();

            if (data != null)
            {
                var email = data.Email;
            }
            EmailSender.SendEmail("vijay.iya@etatvasoft.com", "Message send by admin", $"{message}");
        }

        public async Task StopNotification(int PhysicianId)
        {
            PhysicianNotification? notification = await _context.PhysicianNotifications.Where(a => a.PhysicianId == PhysicianId).FirstOrDefaultAsync();
            PhysicianNotification physicianNotification = new PhysicianNotification();

            if (notification == null)
            {
                physicianNotification.PhysicianId = PhysicianId;
                physicianNotification.IsNotificationStopped = (new BitArray(new[] { true }));
                _context.PhysicianNotifications.Add(physicianNotification);
            }
            else if (notification.IsNotificationStopped[0] == false)
            {
                notification.IsNotificationStopped = (new BitArray(new[] { true }));
                _context.PhysicianNotifications.Update(notification);
            }
            else
            {
                notification.IsNotificationStopped = (new BitArray(new[] { false }));
                _context.PhysicianNotifications.Update(notification);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<byte[]> DownloadExcle(AdminDashboardViewModel model)
        {
            using (var workbook = new XSSFWorkbook())
            {
                ISheet sheet = workbook.CreateSheet("FilteredRecord");
                IRow headerRow = sheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("Sr No.");
                headerRow.CreateCell(1).SetCellValue("Request Id");
                headerRow.CreateCell(2).SetCellValue("Patient Name");
                headerRow.CreateCell(3).SetCellValue("Patient DOB");
                headerRow.CreateCell(4).SetCellValue("RequestorName");
                headerRow.CreateCell(5).SetCellValue("RequestedDate");
                headerRow.CreateCell(6).SetCellValue("PatientPhone");
                headerRow.CreateCell(7).SetCellValue("TransferNotes");
                headerRow.CreateCell(8).SetCellValue("RequestorPhone");
                headerRow.CreateCell(9).SetCellValue("RequestorEmail");
                headerRow.CreateCell(10).SetCellValue("Address");
                headerRow.CreateCell(11).SetCellValue("Notes");
                headerRow.CreateCell(12).SetCellValue("ProviderEmail");
                headerRow.CreateCell(13).SetCellValue("PatientEmail");
                headerRow.CreateCell(14).SetCellValue("RequestType");
                //headerRow.CreateCell(15).SetCellValue("Region");
                headerRow.CreateCell(16).SetCellValue("PhysicainName");
                headerRow.CreateCell(17).SetCellValue("Status");

                for (int i = 0; i < model.requestClients.Count; i++)
                {
                    var reqclient = model.requestClients.ElementAt(i);
                    var type = "";
                    if (reqclient.Request.RequestTypeId == 1)
                    {
                        type = "Patient";
                    }
                    else if (reqclient.Request.RequestTypeId == 2)
                    {
                        type = "Family";
                    }
                    else if (reqclient.Request.RequestTypeId == 3)
                    {
                        type = "Business";
                    }
                    else if (reqclient.Request.RequestTypeId == 4)
                    {
                        type = "Concierge";
                    }
                    IRow row = sheet.CreateRow(i + 1);
                    row.CreateCell(0).SetCellValue(i + 1);
                    row.CreateCell(1).SetCellValue(reqclient.Request.RequestId);
                    row.CreateCell(2).SetCellValue(reqclient.FirstName);
                    row.CreateCell(3).SetCellValue(reqclient.IntDate + "/" + reqclient.StrMonth + "/" + reqclient.IntYear);
                    row.CreateCell(4).SetCellValue(reqclient.Request.FirstName);
                    row.CreateCell(5).SetCellValue(reqclient.Request.CreatedDate);
                    row.CreateCell(6).SetCellValue(reqclient.PhoneNumber);
                    if (reqclient.Request.RequestStatusLogs.Count() == 0)
                    {
                        row.CreateCell(7).SetCellValue("");
                    }
                    else
                    {
                        row.CreateCell(7).SetCellValue(reqclient.Request.RequestStatusLogs.ElementAt(0).Notes);
                    }
                    row.CreateCell(8).SetCellValue(reqclient.Request.PhoneNumber);
                    row.CreateCell(9).SetCellValue(reqclient.Request.Email);
                    row.CreateCell(10).SetCellValue(reqclient.Request.RequestClients.ElementAt(0).Address);
                    row.CreateCell(11).SetCellValue(reqclient.Notes);
                    if (reqclient.Request.Physician == null)
                    {
                        row.CreateCell(12).SetCellValue("");
                    }
                    else
                    {
                        row.CreateCell(12).SetCellValue(reqclient.Request.Physician.Email);
                    }
                    row.CreateCell(13).SetCellValue(reqclient.Email);
                    row.CreateCell(14).SetCellValue(type);
                    //row.CreateCell(15).SetCellValue(reqclient.Region.Name);
                    if (reqclient.Request.Physician == null)
                    {
                        row.CreateCell(16).SetCellValue("");
                    }
                    else
                    {
                        row.CreateCell(16).SetCellValue(reqclient.Request.Physician.FirstName);
                    }
                    row.CreateCell(17).SetCellValue(reqclient.Request.Status);
                }

                using (var stream = new MemoryStream())
                {
                    workbook.Write(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }
        }


        public async Task<PhysicianAccountViewModel> EditPhysician(int PhysicianId)
        {
            Physician? physician = await _context.Physicians.Include(x => x.Role).FirstOrDefaultAsync(a => a.PhysicianId == PhysicianId);
            AspNetUser? aspNetUser = await _context.AspNetUsers.Where(a => a.Id == physician.AspNetUserId).FirstOrDefaultAsync();
            List<Role> role = await _context.Roles.ToListAsync();
            List<Region> regions = await _context.Regions.ToListAsync();
            List<PhysicianRegion> physicianRegions = await _context.PhysicianRegions.Where(a => a.PhysicianId == physician.PhysicianId).ToListAsync();

            if (physician != null && regions != null)
            {
                PhysicianAccountViewModel model = new PhysicianAccountViewModel()
                {
                    PhysicianId = PhysicianId,
                    Username = aspNetUser.UserName,
                    Password = aspNetUser.PasswordHash,
                    rolename = physician.Role.Name,
                    StatusCode = (int)physician.Status,
                    Role = role,
                    FirstName = physician.FirstName,
                    LastName = physician.LastName,
                    Email = physician.Email,
                    PhoneNumber = physician.Mobile,
                    MediLiencense = physician.MedicalLicense,
                    NPI = physician.Npinumber,
                    SynchroEmail = physician.SyncEmailAddress,
                    RegionList = regions,
                    physicianRegions = physicianRegions,
                    address1 = physician.Address1,
                    address2 = physician.Address2,
                    city = physician.City,
                    state = physician.City,
                    zip = physician.Zip,
                    altphonenumber = physician.AltPhone,
                    BusinessName = physician.BusinessName,
                    BusinessWeb = physician.BusinessWebsite,
                    Photo = physician.Photo,
                    Sign = physician.Signature,
                    AdminNotes = physician.AdminNotes,
                };

                if (physician?.IsAgreementDoc?[0] == true)
                {
                    model.AggrementDoc = true;
                }
                if (physician?.IsBackgroundDoc?[0] == true)
                {
                    model.BackgoundDoc = true;
                }
                if (physician?.IsNonDisclosureDoc?[0] == true)
                {
                    model.DisclosureDoc = true;
                }
                if (physician?.IsLicenseDoc?[0] == true)
                {
                    model.LicenseDoc = true;
                }

                return model;
            }
            return new PhysicianAccountViewModel();
        }

        public async Task ResetAccountPass(int PhysicianId, string password)
        {
            Physician? physician = await _context.Physicians.Where(a => a.PhysicianId == PhysicianId).FirstOrDefaultAsync();

            if (physician != null)
            {
                AspNetUser? aspNetUser = await _context.AspNetUsers.Where(a => a.Id == physician.AspNetUserId).FirstOrDefaultAsync();
                aspNetUser!.PasswordHash = password;
                aspNetUser.ModifiedDate = DateTime.Now;
                _context.AspNetUsers.Update(aspNetUser);
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserInfo(AccountData model)
        {
            Physician? physician = await _context.Physicians.Where(a => a.PhysicianId == model.PhysicianId).FirstOrDefaultAsync();

            if (physician != null)
            {
                AspNetUser? aspNetUser = await _context.AspNetUsers.Where(a => a.Id == physician.AspNetUserId).FirstOrDefaultAsync();
                aspNetUser!.UserName = model.Username;
                aspNetUser.ModifiedDate = DateTime.Now;
                if (model.status != 0)
                {
                    physician!.Status = (short)model.status;
                }
                if (model.Role != 0)
                {
                    physician.RoleId = model.Role;
                }
                physician.ModifiedDate = DateTime.Now;

                _context.Physicians.Update(physician);
                _context.AspNetUsers.Update(aspNetUser);

            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePhysicianInfo(UpdatePhycisianInfo model)
        {
            Physician? physician = await _context.Physicians.Where(a => a.PhysicianId == model.PhysicianId).FirstOrDefaultAsync();

            if (physician != null)
            {
                List<PhysicianRegion> physicianRegions = await _context.PhysicianRegions.Where(a => a.PhysicianId == physician.PhysicianId).ToListAsync();
                AspNetUser? aspNetUser = await _context.AspNetUsers.Where(a => a.Id == physician.AspNetUserId).FirstOrDefaultAsync();

                foreach (var item in physicianRegions)
                {
                    _context.PhysicianRegions.Remove(item);
                }
                foreach (var item in model.RegionSelected)
                {
                    PhysicianRegion physicianRegion = new PhysicianRegion();
                    physicianRegion.PhysicianId = physician.PhysicianId;
                    physicianRegion.RegionId = item;
                    _context.PhysicianRegions.Add(physicianRegion);
                }
                physician.FirstName = model.firstname;
                physician.LastName = model.lastname;
                physician.Email = model.email;
                physician.Mobile = model.phonenumber;
                physician.MedicalLicense = model.mediliencense;
                physician.SyncEmailAddress = model.synchroemail;
                physician.ModifiedBy = aspNetUser.Id;
                physician.ModifiedDate = DateTime.Now;
                aspNetUser.UserName = model.firstname + " " + model.lastname;
                aspNetUser.Email = model.email;
                aspNetUser.PhoneNumber = model.phonenumber;
                aspNetUser.ModifiedDate = DateTime.Now;
                _context.Physicians.Update(physician);
                _context.AspNetUsers.Update(aspNetUser);
            }
            await _context.SaveChangesAsync();
        }

        public async Task ModifyBillInfo(ModifyBillingData model)
        {
            Physician? physician = await _context.Physicians.Where(a => a.PhysicianId == model.PhysicianId).FirstOrDefaultAsync();

            if (physician != null)
            {
                physician.Address1 = model.address1;
                physician.Address2 = model.address2;
                physician.City = model.city;
                physician.Zip = model.zip;
                physician.AltPhone = model.altphonenumber;
                physician.ModifiedDate = DateTime.Now;
                _context.Physicians.Update(physician);
            }
            await _context.SaveChangesAsync();
        }

        public async Task ModifyProfileInfo(ModifyProfileData model)
        {
            Physician? physician = await _context.Physicians.Where(a => a.PhysicianId == model.PhysicianId).FirstOrDefaultAsync();
            if (physician != null)
            {
                physician.BusinessName = model.businessname;
                physician.BusinessWebsite = model.businessweb;
                physician.AdminNotes = model.adminnotes;
                physician.ModifiedDate = DateTime.Now;

                if (model.Photo != null)
                {
                    var photo = model.Photo.FileName;
                    var uniquephotoName = GetUniqueFileName(photo);
                    var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                    var photoPath = Path.Combine(uploads, uniquephotoName);
                    model.Photo.CopyTo(new FileStream(photoPath, FileMode.Create));
                    physician.Photo = uniquephotoName;
                }

                if (model.Signature != null)
                {
                    var sign = model.Signature.FileName;
                    var uniquesignName = GetUniqueFileName(sign);
                    var uploadssign = Path.Combine(_environment.WebRootPath, "uploads");
                    var signPath = Path.Combine(uploadssign, uniquesignName);
                    model.Signature.CopyTo(new FileStream(signPath, FileMode.Create));
                    physician.Signature = uniquesignName;
                }
                _context.Physicians.Update(physician);
            }
            await _context.SaveChangesAsync();
        }

        public async Task ModifyDocInfo(DocumentDataModel model)
        {
            Physician? physician = await _context.Physicians.Where(a => a.PhysicianId == model.PhysicianId).FirstOrDefaultAsync();

            if (physician != null)
            {
                if (model.AggrementDoc != null)
                {
                    var uniquefileName = model.PhysicianId + "_" + "Agreement";
                    IFormFile item = model.AggrementDoc;
                    NewMethod(item, uniquefileName);
                    physician.IsAgreementDoc = new BitArray(new[] { true });
                }
                if (model.BackgoundDoc != null)
                {
                    var uniquefileName = model.PhysicianId + "_" + "BackgroundDoc";
                    IFormFile item = model.BackgoundDoc;
                    NewMethod(item, uniquefileName);
                    physician.IsBackgroundDoc = new BitArray(new[] { true });
                }
                if (model.DisclosureDoc != null)
                {
                    var uniquefileName = model.PhysicianId + "_" + "Disclosure";
                    IFormFile item = model.DisclosureDoc;
                    NewMethod(item, uniquefileName);
                    physician.IsNonDisclosureDoc = new BitArray(new[] { true });
                }
                if (model.LicenseDoc != null)
                {
                    var uniquefileName = model.PhysicianId + "_" + "License";
                    IFormFile item = model.LicenseDoc;
                    NewMethod(item, uniquefileName);
                    physician.IsLicenseDoc = new BitArray(new[] { true });
                }
                _context.Physicians.Update(physician);
            }
            await _context.SaveChangesAsync();
        }

        private void NewMethod(IFormFile item, string uniquefileName)
        {
            string extension = Path.GetExtension(item.FileName);
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            var photoPath = Path.Combine(uploads, uniquefileName + extension);
            item.CopyTo(new FileStream(photoPath, FileMode.Create));
        }

        public async Task DeleteAccount(int PhysicianId)
        {
            Physician? physician = await _context.Physicians.Where(a => a.PhysicianId == PhysicianId).FirstOrDefaultAsync();
            if (physician != null)
            {
                physician!.IsDeleted = new BitArray(new[] { true });
                _context.Physicians.Update(physician);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<AccessViewModel> Access()
        {
            List<Role> roles = await _context.Roles.ToListAsync();

            roles = roles.Where(x => x.IsDeleted == null || x.IsDeleted[0] == false).ToList();
            List<RoleData> roleData = roles.Select(a => new RoleData() { RoleId = a.RoleId, Name = a.Name, AccountType = a.AccountType }).ToList();

            if (roles != null)
            {
                AccessViewModel accessViewModel = new AccessViewModel()
                {
                    roleData = roleData,
                };
                return accessViewModel;
            }
            return new AccessViewModel();
        }

        public CreateAccessViewModel CreateAccess()
        {
            var menu = _context.Menus.ToList().DistinctBy(a => a.AccountType).Select(a => (int)a.AccountType).ToList();

            if (menu != null)
            {
                CreateAccessViewModel model = new CreateAccessViewModel()
                {
                    menus = menu,
                };
                return model;
            }
            return new CreateAccessViewModel();
        }

        public async Task DeleteRole(int RoleId)
        {
            Role? role = await _context.Roles.Where(a => a.RoleId == RoleId).FirstOrDefaultAsync();

            if (role != null)
            {
                role.IsDeleted = new BitArray(new[] { true });
                _context.Roles.Update(role);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<CreateAccessViewModel> FilterByAccountType(int accounttype)
        {
            List<Menu> menus = await _context.Menus.ToListAsync();
            CreateAccessViewModel model = new CreateAccessViewModel();

            if (menus != null)
            {
                model.Menu = menus;
                if (accounttype != 4)
                {
                    model.Menu = menus.Where(a => a.AccountType == accounttype).ToList();
                }
                return model;
            }
            return new CreateAccessViewModel();
        }

        public async Task CreateRole(CreateAccessViewModel model, string Email)
        {
            AspNetUser? aspNetUser = await _context.AspNetUsers.Where(a => a.Email == Email).FirstOrDefaultAsync();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (aspNetUser != null)
                    {
                        Role role = new Role()
                        {
                            Name = model.RoleName,
                            CreatedDate = DateTime.Now,
                            CreatedBy = aspNetUser!.Id,
                            AccountType = (short)model.AccountType,
                            IsDeleted = new BitArray(new[] { false }),
                        };
                        await _context.Roles.AddAsync(role);
                        await _context.SaveChangesAsync();

                        foreach (var item in model.MenuData)
                        {
                            RoleMenu roleMenu = new RoleMenu();
                            roleMenu.RoleId = role.RoleId;
                            roleMenu.MenuId = item;
                            await _context.RoleMenus.AddAsync(roleMenu);
                        }
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task<CreatePhysicianViewModel> CreatePhysician()
        {
            List<Role> role = await _context.Roles.ToListAsync();
            List<Region> regions = await _context.Regions.ToListAsync();

            if (role != null && regions != null)
            {
                CreatePhysicianViewModel model = new CreatePhysicianViewModel()
                {
                    Role = role,
                    RegionList = regions,
                };
                return model;
            }
            return new CreatePhysicianViewModel();
        }

        public async Task CreatePhysicianAccount(CreatePhysicianViewModel model, List<int> regionselected)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    AspNetUser aspNetUser = new AspNetUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = model.Username,
                        PasswordHash = model.Password,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        CreatedDate = DateTime.Now,
                    };
                    _context.AspNetUsers.Add(aspNetUser);

                    var role = _context.AspNetRoles.FirstOrDefault(a => a.Name == "Physician");
                    aspNetUser.Roles.Add(role);
                    await _context.SaveChangesAsync();


                    var file = model.Photo.FileName;
                    var uniqueFileName = GetUniqueFileName(file);
                    var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                    Physician physician = new Physician()
                    {
                        AspNetUserId = aspNetUser.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Mobile = model.PhoneNumber,
                        MedicalLicense = model.MediLiencense,
                        AdminNotes = model.AdminNotes,
                        Address1 = model.address1,
                        Address2 = model.address2,
                        City = model.city,
                        Zip = model.zip,
                        AltPhone = model.altphonenumber,
                        CreatedBy = "21c57981-a679-4b62-8eee-57c1ce429643",
                        CreatedDate = DateTime.Now,
                        BusinessName = model.BusinessName,
                        BusinessWebsite = model.BusinessWeb,
                        Npinumber = model.NPI,
                        Photo = uniqueFileName,
                        RegionId = model.state,
                        Status = (int)Common.Enum.PhysicianStatus.NotActive,
                        RoleId = model.role,
                        IsAgreementDoc = new BitArray(new[] { false }),
                        IsBackgroundDoc = new BitArray(new[] { false }),
                        IsNonDisclosureDoc = new BitArray(new[] { false }),
                    };

                    if (model.AggrementDoc != null)
                    {
                        var uniquefileName = physician.PhysicianId + "_" + "Agreement";
                        IFormFile item = model.AggrementDoc;
                        DocumentMethod(item, uniquefileName);
                        physician.IsAgreementDoc = new BitArray(new[] { true });
                    }
                    if (model.BackgoundDoc != null)
                    {
                        var uniquefileName = physician.PhysicianId + "_" + "BackgroundDoc";
                        IFormFile item = model.BackgoundDoc;
                        DocumentMethod(item, uniquefileName);
                        physician.IsBackgroundDoc = new BitArray(new[] { true });
                    }
                    if (model.DisclosureDoc != null)
                    {
                        var uniquefileName = physician.PhysicianId + "_" + "Disclosure";
                        IFormFile item = model.DisclosureDoc;
                        DocumentMethod(item, uniquefileName);
                        physician.IsNonDisclosureDoc = new BitArray(new[] { true });
                    }
                    _context.Physicians.Add(physician);
                    await _context.SaveChangesAsync();

                    foreach (var item in regionselected)
                    {
                        PhysicianRegion physicianRegion = new PhysicianRegion();
                        physicianRegion.PhysicianId = physician.PhysicianId;
                        physicianRegion.RegionId = item;
                        _context.PhysicianRegions.Add(physicianRegion);
                    }
                    await _context.SaveChangesAsync();

                    PhysicianNotification physicianNotification = new PhysicianNotification()
                    {
                        PhysicianId = physician.PhysicianId,
                        IsNotificationStopped = new BitArray(new[] { false }),
                    };
                    _context.PhysicianNotifications.Add(physicianNotification);
                    await _context.SaveChangesAsync();

                    //PhysicianLocation physicianLocation = new PhysicianLocation()
                    //{
                    //    PhysicianId = physician.PhysicianId,
                    //    PhysicianName = model.FirstName + " " + model.LastName,
                    //    Address = model.address1,
                    //    CreatedDate = DateTime.Now,
                    //};
                    //_context.PhysicianLocations.Add(physicianLocation);
                    //await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        private void DocumentMethod(IFormFile item, string uniquefileName)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            var photoPath = Path.Combine(uploads, uniquefileName);
            item.CopyTo(new FileStream(photoPath, FileMode.Create));
        }

        public async Task<CreateAdminViewModel> CreateAdmin()
        {
            List<Role> role = await _context.Roles.ToListAsync();
            List<Region> regions = await _context.Regions.ToListAsync();

            if (role != null && regions != null)
            {
                CreateAdminViewModel model = new CreateAdminViewModel()
                {
                    Role = role,
                    RegionList = regions,
                };
                return model;
            }
            return new CreateAdminViewModel();
        }

        public async Task CreateAdminAccount(CreateAdminViewModel model, List<int> regionselected)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    AspNetUser aspNetUser = new AspNetUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = model.Username,
                        PasswordHash = model.Password,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        CreatedDate = DateTime.Now,
                    };
                    _context.AspNetUsers.Add(aspNetUser);

                    var role = _context.AspNetRoles.FirstOrDefault(a => a.Name == "Admin");
                    aspNetUser.Roles.Add(role);
                    /*await _context.SaveChangesAsync();*/

                    Admin admin = new Admin()
                    {
                        AspNetUserId = aspNetUser.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Mobile = model.PhoneNumber,
                        Address1 = model.address1,
                        Address2 = model.address2,
                        City = model.city,
                        RegionId = model.state,
                        Zip = model.zip,
                        AltPhone = model.altphonenumber,
                        CreatedBy = aspNetUser.Id,
                        CreatedDate = DateTime.Now,
                        Status = (int)Common.Enum.PhysicianStatus.NotActive,
                        RoleId = model.role,
                    };
                    _context.Admins.Add(admin);
                    await _context.SaveChangesAsync();

                    foreach (var item in regionselected)
                    {
                        AdminRegion adminRegion = new AdminRegion();
                        adminRegion.AdminId = admin.AdminId;
                        adminRegion.RegionId = item;
                        _context.AdminRegions.Add(adminRegion);
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task<SchedullingViewModel> Schedulling()
        {
            List<Region> region = await _context.Regions.ToListAsync();

            if (region != null)
            {
                SchedullingViewModel model = new SchedullingViewModel()
                {
                    RegionList = region,
                };
                return model;
            }
            return new SchedullingViewModel();
        }

        public async Task<SchedullingViewModel> SchedullingData(int region, DateTime date)
        {
            List<Physician> physician = await _context.Physicians.ToListAsync();
            List<ShiftDetail> shiftDetails = await _context.ShiftDetails.Include(a => a.Shift).ToListAsync();
            shiftDetails = shiftDetails.Where(x => x.IsDeleted == null || x.IsDeleted[0] == false).ToList();

            SchedullingViewModel model = new SchedullingViewModel();
            if (physician != null && shiftDetails != null)
            {
                if (region != 0)
                {
                    physician = physician.Where(x => x.RegionId == region).ToList();
                }
                model.ShiftDetailList = shiftDetails;
                model.physicians = physician;
                model.ShiftDate = date;
            }
            return model;
        }

        public async Task<CreateNewShift> NewShift()
        {
            List<Region> regions = await _context.Regions.ToListAsync();

            if (regions != null)
            {
                CreateNewShift model = new CreateNewShift()
                {
                    RegionList = regions,
                };
                return model;
            }
            return new CreateNewShift();
        }

        public async Task<CreateNewShift> ViewShift(int ShiftDetailId)
        {
            ShiftDetail? shiftDetails = await _context.ShiftDetails.Include(a => a.Shift).Where(a => a.ShiftDetailId == ShiftDetailId).FirstOrDefaultAsync();
            Physician? physicians = await _context.Physicians.Where(a => a.PhysicianId == shiftDetails.Shift.PhysicianId).FirstOrDefaultAsync();
            Region? region = await _context.Regions.Where(a => a.RegionId == physicians!.RegionId).FirstOrDefaultAsync();

            if (shiftDetails != null)
            {
                CreateNewShift model = new CreateNewShift()
                {
                    ShiftDetailId = ShiftDetailId,
                    PhysicianId = physicians.PhysicianId,
                    PhysicianName = physicians.FirstName + " " + physicians.LastName,
                    RegionId = region.RegionId,
                    RegionName = region.Name,
                    ShiftDate = shiftDetails.ShiftDate,
                    Start = shiftDetails.StartTime,
                    End = shiftDetails.EndTime,
                };
                return model;
            }
            return new CreateNewShift();
        }

        public async Task ReturnShift(int ShiftDetailId, string email)
        {
            AspNetUser? aspNetUser = await _context.AspNetUsers.FirstOrDefaultAsync(a => a.Email == email);
            ShiftDetail? shiftDetails = await _context.ShiftDetails.Include(a => a.Shift).Where(a => a.ShiftDetailId == ShiftDetailId).FirstOrDefaultAsync();

            if (shiftDetails != null)
            {
                shiftDetails!.Status = 1;
                shiftDetails.ModifiedDate = DateTime.Now;
                shiftDetails.ModifiedBy = aspNetUser!.Id;
                _context.ShiftDetails.Update(shiftDetails);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShift(int ShiftDetailId, string email)
        {
            AspNetUser? aspNetUser = await _context.AspNetUsers.FirstOrDefaultAsync(a => a.Email == email);
            ShiftDetail? shiftDetails = await _context.ShiftDetails.Include(a => a.Shift).Where(a => a.ShiftDetailId == ShiftDetailId).FirstOrDefaultAsync();

            if (shiftDetails != null)
            {
                shiftDetails.IsDeleted = new BitArray(new[] { true });
                shiftDetails.ModifiedDate = DateTime.Now;
                shiftDetails.ModifiedBy = aspNetUser!.Id;
                _context.ShiftDetails.Update(shiftDetails);
            }
            await _context.SaveChangesAsync();
        }

        public async Task EditShift(CreateNewShift model, string email)
        {
            AspNetUser? aspNetUser = await _context.AspNetUsers.FirstOrDefaultAsync(a => a.Email == email);
            ShiftDetail? shiftDetails = await _context.ShiftDetails.Include(a => a.Shift).Where(a => a.ShiftDetailId == model.ShiftDetailId).FirstOrDefaultAsync();

            if (shiftDetails != null)
            {
                shiftDetails.ShiftDate = model.ShiftDate;
                shiftDetails.StartTime = model.Start;
                shiftDetails.EndTime = model.End;
                shiftDetails.ModifiedDate = DateTime.Now;
                shiftDetails.ModifiedBy = aspNetUser!.Id;
                _context.ShiftDetails.Update(shiftDetails);
            }
            await _context.SaveChangesAsync();
        }

        public async Task CreateShift(CreateNewShift model, string Email, List<int> repeatdays)
        {
            AspNetUser? aspNetUser = await _context.AspNetUsers.FirstOrDefaultAsync(a => a.Email == Email);

            if (aspNetUser != null)
            {
                var chk = repeatdays.ToList();

                var shiftid = _context.Shifts.Where(u => u.PhysicianId == model.PhysicianId).Select(u => u.ShiftId).ToList();
                if (shiftid.Count() > 0)
                {
                    foreach (var obj in shiftid)
                    {
                        var shiftdetailchk = _context.ShiftDetails.Where(u => u.ShiftId == obj && u.ShiftDate == model.ShiftDate).ToList();
                        if (shiftdetailchk.Count() > 0)
                        {
                            foreach (var item in shiftdetailchk)
                            {
                                if ((model.Start >= item.StartTime && model.Start <= item.EndTime) || (model.End >= item.StartTime && model.End <= item.EndTime))
                                {
                                    //TempData["error"] = "Shift is already assigned in this time";
                                    //return RedirectToAction("Scheduling");
                                }
                            }
                        }
                    }
                }
                Shift shift = new Shift
                {
                    PhysicianId = model.PhysicianId,
                    StartDate = DateOnly.FromDateTime(model.ShiftDate),
                    RepeatUpto = model.RepeatEnd,
                    CreatedDate = DateTime.Now,
                    CreatedBy = aspNetUser!.Id
                };
                if (chk.Count != 0)
                {
                    foreach (var obj in chk)
                    {
                        shift.WeekDays += obj;
                    }
                }
                if (model.RepeatEnd > 0)
                {
                    shift.IsRepeat = new BitArray(new[] { true });
                }
                else
                {
                    shift.IsRepeat = new BitArray(new[] { false });
                }
                _context.Shifts.Add(shift);
                await _context.SaveChangesAsync();
                DateTime curdate = model.ShiftDate;

                ShiftDetail shiftdetail = new ShiftDetail();
                shiftdetail.ShiftId = shift.ShiftId;
                shiftdetail.ShiftDate = curdate;
                shiftdetail.RegionId = model.RegionId;
                shiftdetail.StartTime = model.Start;
                shiftdetail.EndTime = model.End;
                shiftdetail.IsDeleted = new BitArray(new[] { false });
                _context.ShiftDetails.Add(shiftdetail);
                await _context.SaveChangesAsync();

                var dayofweek = model.ShiftDate.DayOfWeek.ToString();
                int valueforweek;
                if (dayofweek == "Sunday")
                {
                    valueforweek = 0;
                }
                else if (dayofweek == "Monday")
                {
                    valueforweek = 1;
                }
                else if (dayofweek == "Tuesday")
                {
                    valueforweek = 2;
                }
                else if (dayofweek == "Wednesday")
                {
                    valueforweek = 3;
                }
                else if (dayofweek == "Thursday")
                {
                    valueforweek = 4;
                }
                else if (dayofweek == "Friday")
                {
                    valueforweek = 5;
                }
                else
                {
                    valueforweek = 6;
                }
                if (shift.IsRepeat[0] == true)
                {
                    for (int j = 0; j < shift.WeekDays.Count(); j++)
                    {
                        var z = shift.WeekDays;
                        var p = shift.WeekDays.ElementAt(j).ToString();
                        int ele = Int32.Parse(p);
                        int x;
                        if (valueforweek > ele)
                        {
                            x = 6 - valueforweek + 1 + ele;
                        }
                        else
                        {
                            x = ele - valueforweek;
                        }
                        if (x == 0)
                        {
                            x = 7;
                        }
                        DateTime newcurdate = model.ShiftDate.AddDays(x);
                        for (int i = 0; i < model.RepeatEnd; i++)
                        {
                            ShiftDetail shiftdetailnew = new ShiftDetail
                            {
                                ShiftId = shift.ShiftId,
                                ShiftDate = newcurdate,
                                RegionId = model.RegionId,
                                StartTime = model.Start,
                                EndTime = model.End,
                                IsDeleted = new BitArray(new[] { false })
                            };
                            _context.ShiftDetails.Add(shiftdetailnew);
                            await _context.SaveChangesAsync();
                            newcurdate = newcurdate.AddDays(7);
                        }
                    }
                }
            }
        }

        public async Task<SchedullingViewModel> MonthSchedullingData(int region, DateTime date)
        {
            List<ShiftDetail> shiftDetails = await _context.ShiftDetails.Include(a => a.Shift).Include(a => a.Shift.Physician)
                .Where(x => x.ShiftDate.Month == date.Month).ToListAsync();
            SchedullingViewModel model = new SchedullingViewModel();

            if (shiftDetails != null)
            {
                shiftDetails = shiftDetails.Where(x => x.IsDeleted == null || x.IsDeleted[0] == false).ToList();

                if (region != 0)
                {
                    shiftDetails = shiftDetails.Where(x => x.Shift.Physician.RegionId == region).ToList();
                }

                model.ShiftDetailList = shiftDetails;
                model.ShiftDate = date;
            }
            return model;
        }

        public async Task<SchedullingViewModel> MdOnCall()
        {
            List<Region> regions = await _context.Regions.ToListAsync();

            if (regions != null)
            {
                SchedullingViewModel model = new SchedullingViewModel()
                {
                    RegionList = regions
                };
                return model;
            }
            return new SchedullingViewModel();
        }

        public async Task<SchedullingViewModel> MdOnCallData(int region)
        {
            List<Physician> physicians = await _context.Physicians.Include(a => a.Shifts).ThenInclude(x => x.ShiftDetails).ToListAsync();

            SchedullingViewModel model = new SchedullingViewModel();
            if (physicians != null)
            {
                model.physicians = physicians;
                if (region != 0)
                {
                    model.physicians = model.physicians!.Where(a => a.RegionId == region).ToList();
                }
            }

            return model;
        }

        public async Task<RequestedShiftViewModel> RequestedShifts()
        {
            List<Region> regions = await _context.Regions.ToListAsync();

            if (regions != null)
            {
                RequestedShiftViewModel model = new RequestedShiftViewModel()
                {
                    RegionList = regions
                };
                return model;
            }
            return new RequestedShiftViewModel();
        }

        public async Task<RequestedShiftViewModel> RequestedShiftsData(int region, int requestedPage)
        {
            List<ShiftDetail> shiftDetails = await _context.ShiftDetails.Include(a => a.Shift).ThenInclude(a => a.Physician).Include(a => a.Region).Where(a => a.Status == 0).ToListAsync();
            RequestedShiftViewModel model = new RequestedShiftViewModel();

            if (shiftDetails != null)
            {
                shiftDetails = shiftDetails.Where(x => x.IsDeleted == null || x.IsDeleted[0] == false).ToList();
                model.ShiftDetailList = shiftDetails;
                if (region != 0)
                {
                    model.ShiftDetailList = model.ShiftDetailList!.Where(a => a.RegionId == region).ToList();
                }
                int count = model.ShiftDetailList!.Count();
                int TotalPage = (int)Math.Ceiling(count / (double)5);
                model.ShiftDetailList = model.ShiftDetailList!.Skip((requestedPage - 1) * 5).Take(5).ToList();
                model.CurrentPage = requestedPage;
                model.TotalPage = TotalPage;
            }
            return model;
        }

        public async Task DeleteSelectedShift(List<int> selectedShifts, string email)
        {
            AspNetUser? aspNetUser = await _context.AspNetUsers.FirstOrDefaultAsync(a => a.Email == email);
            if (selectedShifts != null)
            {
                foreach (var item in selectedShifts)
                {
                    ShiftDetail? data = _context.ShiftDetails.FirstOrDefault(a => a.ShiftDetailId == item);
                    if (data != null && aspNetUser != null)
                    {
                        data.IsDeleted = new BitArray(new[] { true });
                        data.ModifiedBy = aspNetUser.Id;
                        data.ModifiedDate = DateTime.Now;
                        _context.ShiftDetails.Update(data);
                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task ApproveSelectedShift(List<int> selectedShifts, string email)
        {
            AspNetUser? aspNetUser = await _context.AspNetUsers.FirstOrDefaultAsync(a => a.Email == email);
            if (selectedShifts != null)
            {
                foreach (var item in selectedShifts)
                {
                    ShiftDetail? data = _context.ShiftDetails.FirstOrDefault(a => a.ShiftDetailId == item);
                    if (data != null && aspNetUser != null)
                    {
                        data.Status = 1;
                        data.ModifiedBy = aspNetUser.Id;
                        data.ModifiedDate = DateTime.Now;
                        _context.ShiftDetails.Update(data);
                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<VendorsDetailsViewModel> VendorsData()
        {
            List<HealthProfessionalType> healthProfessionalTypes = await _context.HealthProfessionalTypes.ToListAsync();

            if (healthProfessionalTypes != null)
            {
                VendorsDetailsViewModel model = new VendorsDetailsViewModel()
                {
                    healthProfessionalTypes = healthProfessionalTypes,
                };
                return (model);
            }
            return new VendorsDetailsViewModel();
        }


        public async Task<VendorsDetailsViewModel> VendorMenu(int profession, string searchvendor)
        {
            List<HealthProfessional> healthProfessionals = await _context.HealthProfessionals.Include(a => a.ProfessionNavigation).ToListAsync();
            healthProfessionals = healthProfessionals.Where(x => x.IsDeleted == null || x.IsDeleted[0] == false).ToList();

            if (healthProfessionals != null)
            {
                if (!string.IsNullOrWhiteSpace(searchvendor))
                {
                    healthProfessionals = healthProfessionals.Where(a => a.VendorName.ToLower().Contains(searchvendor.ToLower())).ToList();
                }
                if (profession != 0)
                {
                    healthProfessionals = healthProfessionals.Where(a => a.ProfessionNavigation.HealthProfessionalId == profession).ToList();
                }

                List<VendorsData> vendorsData = healthProfessionals.Select(a => new VendorsData
                {
                    ProfessionId = a.VendorId,
                    Profession = a.ProfessionNavigation.ProfessionName,
                    VendorName = a.VendorName,
                    Email = a.Email,
                    PhoneNumber = a.PhoneNumber,
                    FaxNumber = a.FaxNumber,
                    BusinessContact = a.BusinessContact
                }).ToList();

                VendorsDetailsViewModel model = new VendorsDetailsViewModel()
                {
                    vendorsDatas = vendorsData,
                };
                return (model);
            }
            return new VendorsDetailsViewModel();
        }

        public async Task<AddBusinessViewModel> AddBusiness(int VendorId)
        {
            HealthProfessional? healthProfessional = await _context.HealthProfessionals.FirstOrDefaultAsync(a => a.VendorId == VendorId);
            List<HealthProfessionalType> healthProfessionalTypes = await _context.HealthProfessionalTypes.ToListAsync();

            if (healthProfessionalTypes != null)
            {
                AddBusinessViewModel model = new AddBusinessViewModel()
                {
                    professionalTypes = healthProfessionalTypes,
                };

                if (healthProfessional != null)
                {
                    model.professionalTypes = healthProfessionalTypes;
                    model.VendorName = healthProfessional!.VendorName;
                    model.VendorId = VendorId;
                    model.Email = healthProfessional.Email!;
                    model.PhoneNumber = healthProfessional!.PhoneNumber!;
                    model.FaxNumber = healthProfessional.FaxNumber;
                    model.BusinessContact = healthProfessional.BusinessContact;
                }
                return (model);
            }
            return new AddBusinessViewModel();
        }

        public async Task AddNewBusiness(AddBusinessViewModel model, int VendorId)
        {
            HealthProfessional? healthProfessional1 = await _context.HealthProfessionals.FirstOrDefaultAsync(a => a.VendorId == VendorId);

            if (healthProfessional1 != null)
            {
                healthProfessional1.VendorName = model.VendorName;
                healthProfessional1.Profession = model.ProfessionId;
                healthProfessional1.Email = model.Email;
                healthProfessional1.PhoneNumber = model.PhoneNumber;
                healthProfessional1.FaxNumber = model.FaxNumber;
                healthProfessional1.BusinessContact = model.BusinessContact;
                healthProfessional1.State = model.State;
                healthProfessional1.City = model.City;
                healthProfessional1.Zip = model.ZipCode;
                healthProfessional1.Address = model.Street + " " + model.City + " " + model.State;
                healthProfessional1.ModifiedDate = DateTime.Now;
                _context.HealthProfessionals.Update(healthProfessional1);
            }
            else
            {
                HealthProfessional healthProfessional = new HealthProfessional()
                {
                    VendorName = model.VendorName,
                    Profession = model.ProfessionId,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    FaxNumber = model.FaxNumber,
                    BusinessContact = model.BusinessContact,
                    State = model.State,
                    City = model.City,
                    Zip = model.ZipCode,
                    Address = model.Street + " " + model.City + " " + model.State,
                    CreatedDate = DateTime.Now,
                };
                _context.HealthProfessionals.Add(healthProfessional);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBusiness(int VendorId)
        {
            HealthProfessional? healthProfessional = await _context.HealthProfessionals.FirstOrDefaultAsync(a => a.VendorId == VendorId);

            if (healthProfessional != null)
            {
                healthProfessional.IsDeleted = new BitArray(new[] { true });
                _context.HealthProfessionals.Update(healthProfessional);
            }
            await _context.SaveChangesAsync();

        }

        public async Task<List<PhysicianLocation>> GetPhysicianlocations()
        {
            var phyLocation = await _context.PhysicianLocations.ToListAsync();
            return phyLocation;
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
