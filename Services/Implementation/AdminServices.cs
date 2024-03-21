using Common.Enum;
using Common.Helpers;
using Data.Context;
using Data.Entity;
using HalloDoc.Utility;
using HellocDoc1.Services.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MimeKit.Cryptography;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Services.Contracts;
using Services.Models;
using System;
using System.Collections;

namespace Services.Implementation
{
    public class AdminServices : IAdminServices
    {
        private ApplicationDbContext _context;
        private IHostingEnvironment _environment;

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 6)
                      + Path.GetExtension(fileName);
        }
        public AdminServices(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }

        public AdminDashboardViewModel AdminDashboard()
        {
            var requestCount1 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 1).Count();
            var requestCount2 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 2).Count();
            var requestCount3 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 3).Count();
            var requestCount4 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 4).Count();
            var requestCount5 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 5).Count();
            var requestCount6 = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 6).Count();
            List<Region> regions = _context.Regions.ToList();

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
        public AdminDashboardViewModel NewState(AdminDashboardViewModel obj)
       {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 1).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = clients;

            if (!string.IsNullOrWhiteSpace(obj.patientname))
            {
                model.requestClients = model.requestClients.Where(a => a.FirstName.ToLower().Contains(obj.patientname.ToLower()) || a.LastName.ToLower().Contains(obj.patientname.ToLower())).ToList();
            }
            if (obj.requesttype == 1 || obj.requesttype == 2 || obj.requesttype == 3 || obj.requesttype == 4)
            {
                model.requestClients = model.requestClients.Where(a => a.Request.RequestTypeId == obj.requesttype).ToList();
            }
            if(obj.region != 0) {
                model.requestClients = model.requestClients.Where(a => a.RegionId == obj.region).ToList();
            }
            int count = model.requestClients.Count();
            int TotalPage = (int)Math.Ceiling(count / (double)5);
            model.requestClients = model.requestClients.Skip((obj.requestedPage - 1) * 5).Take(5).ToList();
            model.CurrentPage = obj.requestedPage;
            model.TotalPage = TotalPage;
            return model;
        }

        public AdminDashboardViewModel PendingState(AdminDashboardViewModel obj)
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 2).ToList();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
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
            return model;
        }

        public AdminDashboardViewModel ActiveState(AdminDashboardViewModel obj)
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 3).ToList();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
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
            return model;
        }

        public AdminDashboardViewModel ConcludeState(AdminDashboardViewModel obj)
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 4).ToList();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
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
            return model;
        }

        public AdminDashboardViewModel ToCloseState(AdminDashboardViewModel obj)
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Include(a => a.Region).Where(a => a.Request.Status == 5).ToList();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
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
            return model;
        }

        public AdminDashboardViewModel UnpaidState(AdminDashboardViewModel obj)
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 6).ToList();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
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
            return model;
        }

        public ViewCaseViewModel ViewCase(int request_id)
        {
            var data = _context.RequestClients.Include(a => a.Request).Where(a => a.RequestId == request_id).FirstOrDefault();
            ViewCaseViewModel model = new ViewCaseViewModel();
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

        public async Task CancelCase(int request_id, int caseId, string cancelNote)
        {
            var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();
            var reason = _context.CaseTags.Where(a => a.CaseTagId == caseId).FirstOrDefault();
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
            await _context.SaveChangesAsync();
        }

        public AssignCaseViewModel AssignDetails(int request_id)
        {
            List<Region> data = _context.Regions.ToList();
            AssignCaseViewModel model = new AssignCaseViewModel()
            {
                RequestId = request_id,
                Regions = data,
            };
            return model;
        }

        public List<PhysicianSelectlViewModel> FilterData(int regionid)
        {
            List<Physician> data = _context.Physicians.Where(a => a.RegionId == regionid).ToList();
            List<PhysicianSelectlViewModel> data1 = data.Select(a => new PhysicianSelectlViewModel() { Name = a.FirstName, PhysicianId = a.PhysicianId }).ToList();

            return data1;
        }

        public async Task AssignCase(int request_id, int physicianid, string description)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();
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
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

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

        public async Task BlockCase(int request_id, string reason)
        {
            var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();
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
                CreatedDate = DateTime.Now,
            };

            _context.Requests.Update(data);
            await _context.RequestStatusLogs.AddAsync(requestStatusLog);
            await _context.BlockRequests.AddAsync(blockRequest);
            await _context.SaveChangesAsync();
        }

        public ViewUploadsViewModel ViewUploads(int request_id)
        {
            Request data = _context.Requests.Include(a => a.RequestWiseFiles).Where(a => a.RequestId == request_id).FirstOrDefault();
            data.RequestWiseFiles = data.RequestWiseFiles.Where(x => x.IsDeleted == null || x.IsDeleted[0] == false).ToList();
            ViewUploadsViewModel viewUploads = new ViewUploadsViewModel()
            {
                RequestId = request_id,
                Name = data.FirstName + " " + data.LastName,
            };

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
            return viewUploads;
        }

        public void UploadDocuments(ViewUploadsViewModel model, int request_id)
        {
            IEnumerable<IFormFile> upload = model.Upload;
            foreach (var item in upload)
            {

                var file = item.FileName;
                var uniqueFileName = GetUniqueFileName(file);
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                item.CopyTo(new FileStream(filePath, FileMode.Create));

                RequestWiseFile requestWiseFile = new RequestWiseFile()
                {
                    FileName = uniqueFileName,
                    CreatedDate = DateTime.Now,

                };
                _context.RequestWiseFiles.Add(requestWiseFile);
                requestWiseFile.RequestId = request_id;

            }
            _context.SaveChanges();
        }

        public void Delete(int DocumentId)
        {
            RequestWiseFile data = _context.RequestWiseFiles.Where(a => a.RequestWiseFileId == DocumentId).FirstOrDefault();
            data.IsDeleted = new BitArray(new[] { true });
            _context.RequestWiseFiles.Update(data);
            _context.SaveChanges();
        }

        public void DeleteAll(List<int> DocumentId)
        {
            foreach (var item in DocumentId)
            {
                RequestWiseFile data = _context.RequestWiseFiles.Where(a => a.RequestWiseFileId == item).FirstOrDefault();
                data.IsDeleted = new BitArray(new[] { true });
                _context.RequestWiseFiles.Update(data);

            }
            _context.SaveChanges();
        }

        public void SendMail(List<int> DocumentId)
        {
            List<string> name = new List<string>();
            foreach (var item in DocumentId)
            {
                RequestWiseFile data = _context.RequestWiseFiles.Where(a => a.RequestWiseFileId == item).FirstOrDefault();
                var file = data.FileName;
                name.Add(file);


            }
            var filepath = "C:\\Users\\pca70\\source\\repos\\HellocDoc1\\HellocDoc1\\wwwroot\\uploads";

            EmailSender.SendMailOnGmail("aniyariyavijay441@gmail.com", "Your Documents", "Document", name, filepath);
        }

        public LoginResponseViewModel AdminLogin(AdminLoginViewModel model)
        {
            var user = _context.AspNetUsers.Where(u => u.Email == model.Email).Include(a => a.Roles).FirstOrDefault();

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

        public SendOrdersViewModel SendOders(int request_id)
        {
            List<HealthProfessionalType> data = _context.HealthProfessionalTypes.ToList();
            List<HealthProfession> obj = data.Select(a => new HealthProfession() { ProfessionId = a.HealthProfessionalId, ProfessionName = a.ProfessionName }).ToList();


            SendOrdersViewModel model = new SendOrdersViewModel()
            {
                RequestId = request_id,
                HealthProfessions = obj,

            };
            return model;
        }

        public SendOrdersViewModel FilterDataByProfession(int ProfessionId)
        {
            List<HealthProfessional> data = _context.HealthProfessionals.Where(a => a.Profession == ProfessionId).ToList();
            List<BusinessType> obj = data.Select(a => new BusinessType() { BusinessId = a.VendorId, BusinessName = a.VendorName }).ToList();

            SendOrdersViewModel model = new SendOrdersViewModel()
            {
                Business = obj,
            };

            return model;
        }


        public SendOrdersViewModel FilterDataByBusiness(int BusinessId)
        {
            List<HealthProfessional> data = _context.HealthProfessionals.Where(a => a.VendorId == BusinessId).ToList();
            List<BusinessType> obj = data.Select(a => new BusinessType() { BusinessId = a.VendorId, BusinessName = a.VendorName, Contact = a.BusinessContact, Email = a.Email, FaxNumber = a.FaxNumber }).ToList();

            SendOrdersViewModel model = new SendOrdersViewModel()
            {
                Business = obj,
            };

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

        public TransferCaseViewModel TransferDetails(int request_id)
        {
            List<Region> data = _context.Regions.ToList();
            TransferCaseViewModel model = new TransferCaseViewModel()
            {
                RequestId = request_id,
                Regions = data,
            };
            return model;
        }

        public async Task TransferCase(int request_id, int physicianid, string description)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();
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
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

        }

        public ClearCaseViewModel ClearDetails(int request_id)
        {
            var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();

            ClearCaseViewModel model = new ClearCaseViewModel()
            {
                RequestId = request_id,
            };
            return model;
        }

        public async Task ClearCase(ClearCaseViewModel model, int request_id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var obj = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();
                    obj.Status = 10;
                    RequestStatusLog requestStatusLog = new RequestStatusLog()
                    {
                        RequestId = request_id,
                        Status = 10,
                        CreatedDate = DateTime.Now,

                    };

                    _context.Requests.Update(obj);
                    await _context.RequestStatusLogs.AddAsync(requestStatusLog);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

        }

        public SendAgreementViewModel SendAgreementDetails(int request_id)
        {
            var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();

            SendAgreementViewModel model = new SendAgreementViewModel()
            {
                RequestId = request_id,
                RequestTypeId = data.RequestTypeId,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
            };
            return model;
        }

        public void SendAgreement(string request_id)
        {
            EmailSender.SendEmailAsync("vijay.aniyaliya@etatvasoft.com", "Hello", $" <a href=\"https://localhost:7208/Patient/ReviewAgreement/{request_id}\">Agreement</a>");
        }

        public CloseCaseViewModel CloseCase(int request_id)
        {
            RequestClient data = _context.RequestClients.Include(a => a.Request).Include(a => a.Request.RequestWiseFiles).Where(a => a.RequestId == request_id).FirstOrDefault();
            data!.Request.RequestWiseFiles = data.Request.RequestWiseFiles.Where(x => x.IsDeleted == null || x.IsDeleted[0] == false).ToList();

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


        public async Task SaveCloseCase(CloseCaseViewModel model, int request_id)
        {
            RequestClient requestClient = _context.RequestClients.Where(a => a.RequestId == request_id).FirstOrDefault();
            requestClient.Email = model.Email;
            requestClient.PhoneNumber = model.PhoneNumber;

            _context.RequestClients.Update(requestClient);
            await _context.SaveChangesAsync();
        }

        public async Task CloseCaseRequest(int request_id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var obj = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();
                    obj.Status = 6;
                    RequestStatusLog requestStatusLog = new RequestStatusLog()
                    {
                        RequestId = request_id,
                        Status = 6,
                        CreatedDate = DateTime.Now,

                    };

                    _context.Requests.Update(obj);
                    await _context.RequestStatusLogs.AddAsync(requestStatusLog);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

        }

        public EncounterFormViewModel EncounterForm(int request_id)
        {
            RequestClient data = _context.RequestClients.Include(a => a.Request).Where(a => a.RequestId == request_id).FirstOrDefault();
            EncounterForm obj = _context.EncounterForms.DefaultIfEmpty().Where(a => a.RequestId == request_id).FirstOrDefault();

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

        public async Task SubmitEncounterForm(EncounterFormViewModel model, int request_id)
        {
            EncounterForm encounter = _context.EncounterForms.Where(a => a.RequestId == request_id).FirstOrDefault();

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

        public AdminProfileViewModel ProfileData(string email)
        {
            AspNetUser aspNetUser = _context.AspNetUsers.Where(a => a.Email == email).FirstOrDefault();
            Admin admin = _context.Admins.Where(a => a.Email == email).FirstOrDefault();
            List<Region> regions = _context.Regions.ToList();
            List<AdminRegion> adminRegions = _context.AdminRegions.Where(a => a.AdminId == admin.AdminId).ToList();
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

        public async Task ResetPassword(string email, string password)
        {
            AspNetUser aspNetUser = _context.AspNetUsers.Where(a => a.Email == email).FirstOrDefault();
            aspNetUser.PasswordHash = password;
            aspNetUser.ModifiedDate = DateTime.Now;

            _context.AspNetUsers.Update(aspNetUser);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAdminstrator(ProfileData model, string email)
        {
            Admin admin = _context.Admins.Where(a => a.Email == email).FirstOrDefault();
            AspNetUser aspNetUser = _context.AspNetUsers.Where(a => a.Email == email).FirstOrDefault();
            List<AdminRegion> adminRegions = _context.AdminRegions.Where(a => a.AdminId == admin.AdminId).ToList();
            foreach (var item in adminRegions)
            {
                _context.AdminRegions.Remove(item);
            }
            AdminRegion adminRegion = new AdminRegion();
            foreach (var item in model.RegionSelected)
            {
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
            await _context.SaveChangesAsync();


        }
        public async Task UpdateBillInfo(BillingData model, string email)
        {
            Admin admin = _context.Admins.Where(a => a.Email == email).FirstOrDefault();
            admin.Address1 = model.address1;
            admin.Address2 = model.address2;
            admin.City = model.city;
            admin.Zip = model.zip;
            admin.AltPhone = model.altphonenumber;
            admin.ModifiedDate = DateTime.Now;
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();


        }

        public void SendLink(SendLinkViewModel model)
        {
            EmailSender.SendEmailAsync("vijay.aniyaliya@etatvasoft.com", "Create request", $" <a href=\"https://localhost:7208/Patient/Submit_request_screen/\">Agreement</a>");
        }

        public async Task SubmitRequest(CreateRequestViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    AspNetUser aspnetuser = await _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefaultAsync();
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
                        user = _context.Users.Where(a => a.Email == model.Email).FirstOrDefault();
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

        public ProviderViewModel PhysicianData()
        {
            List<Physician> data = _context.Physicians.ToList();
            List<PhysicianNotification> notifications = _context.PhysicianNotifications.Where(a => a.IsNotificationStopped == (new BitArray(new[] { true }))).ToList();
            List<PhysicianData> obj = data.Select(a => new PhysicianData() { physicianId = a.PhysicianId, ProviderName = a.FirstName + " " + 
                a.LastName,Status =(int)a.Status, PhysicianNotifications = notifications }).ToList();

            ProviderViewModel model = new ProviderViewModel()
            {
                Physicians = obj,
            };
            return model;
        }

        public void SendMessage(int PhysicianId, string message)
        {
            Physician data = _context.Physicians.Where(a => a.PhysicianId == PhysicianId).FirstOrDefault();
            var email = data.Email;
            EmailSender.SendEmailAsync("vijay.iya@etatvasoft.com", "Message send by admin", $"{message}");

        }

        public void StopNotification(int PhysicianId)
        {
            PhysicianNotification? notification = _context.PhysicianNotifications.Where(a => a.PhysicianId == PhysicianId).FirstOrDefault();
            PhysicianNotification physicianNotification = new PhysicianNotification();

            if (notification.IsNotificationStopped[0] == false)
            {
                notification.IsNotificationStopped[0] = true;
                _context.PhysicianNotifications.Update(notification);
            }
            else
            {
                notification.IsNotificationStopped[0] = false;

                _context.PhysicianNotifications.Update(notification);
            }
            _context.SaveChanges();

        }

        public byte[] DownloadExcle(AdminDashboardViewModel model)
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
                    workbook.Write(stream)
;
                    var content = stream.ToArray();
                    return content;
                }
            }
        }
    }
}
