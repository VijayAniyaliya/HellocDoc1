using Common.Enum;
using Common.Helpers;
using Data.Context;
using Data.Entity;
using HalloDoc.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Models;
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
        public AdminDashboardViewModel NewState(int CurrentPage, string patientname, int requesttype, int PageSize = 10)
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 1).ToList();

            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = clients;

            if (!string.IsNullOrWhiteSpace(patientname))
            {
                model.requestClients = model.requestClients.Where(a => a.FirstName.ToLower().Contains(patientname.ToLower()) || a.LastName.ToLower().Contains(patientname.ToLower())).ToList();
            }
            if (requesttype == 1 || requesttype == 2 || requesttype == 3 || requesttype == 4)
            {
                model.requestClients = model.requestClients.Where(a => a.Request.RequestTypeId == requesttype).ToList();
            }
            int count = model.requestClients.Count();
            int TotalPage = (int)Math.Ceiling(count / (double)PageSize);
            model.requestClients = model.requestClients.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            model.CurrentPage = CurrentPage;
            model.TotalPage = TotalPage;
            return model;
        }

        public AdminDashboardViewModel PendingState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10)
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 2).ToList();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = clients;

            if (!string.IsNullOrWhiteSpace(patientname))
            {
                model.requestClients = model.requestClients.Where(a => a.FirstName.ToLower().Contains(patientname.ToLower()) || a.LastName.ToLower().Contains(patientname.ToLower())).ToList();
            }
            if (requesttype == 1 || requesttype == 2 || requesttype == 3 || requesttype == 4)
            {
                model.requestClients = model.requestClients.Where(a => a.Request.RequestTypeId == requesttype).ToList();
            }
            int count = model.requestClients.Count();
            int TotalPage = (int)Math.Ceiling(count / (double)PageSize);
            model.requestClients = model.requestClients.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            model.CurrentPage = CurrentPage;
            model.TotalPage = TotalPage;
            return model;
        }

        public AdminDashboardViewModel ActiveState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10)
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 3).ToList();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = clients;

            if (!string.IsNullOrWhiteSpace(patientname))
            {
                model.requestClients = model.requestClients.Where(a => a.FirstName.ToLower().Contains(patientname.ToLower()) || a.LastName.ToLower().Contains(patientname.ToLower())).ToList();
            }
            if (requesttype == 1 || requesttype == 2 || requesttype == 3 || requesttype == 4)
            {
                model.requestClients = model.requestClients.Where(a => a.Request.RequestTypeId == requesttype).ToList();
            }
            int count = model.requestClients.Count();
            int TotalPage = (int)Math.Ceiling(count / (double)PageSize);
            model.requestClients = model.requestClients.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            model.CurrentPage = CurrentPage;
            model.TotalPage = TotalPage;
            return model;
        }

        public AdminDashboardViewModel ConcludeState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10)
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 4).ToList();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = clients;

            if (!string.IsNullOrWhiteSpace(patientname))
            {
                model.requestClients = model.requestClients.Where(a => a.FirstName.ToLower().Contains(patientname.ToLower()) || a.LastName.ToLower().Contains(patientname.ToLower())).ToList();
            }
            if (requesttype == 1 || requesttype == 2 || requesttype == 3 || requesttype == 4)
            {
                model.requestClients = model.requestClients.Where(a => a.Request.RequestTypeId == requesttype).ToList();
            }
            int count = model.requestClients.Count();
            int TotalPage = (int)Math.Ceiling(count / (double)PageSize);
            model.requestClients = model.requestClients.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            model.CurrentPage = CurrentPage;
            model.TotalPage = TotalPage;
            return model;
        }

        public AdminDashboardViewModel ToCloseState(int CurrentPage, string patientname, int requesttype, int PageSize)
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Include(a => a.Region).Where(a => a.Request.Status == 5).ToList();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = clients;

            if (!string.IsNullOrWhiteSpace(patientname))
            {
                model.requestClients = model.requestClients.Where(a => a.FirstName.ToLower().Contains(patientname.ToLower()) || a.LastName.ToLower().Contains(patientname.ToLower())).ToList();
            }
            if (requesttype == 1 || requesttype == 2 || requesttype == 3 || requesttype == 4)
            {
                model.requestClients = model.requestClients.Where(a => a.Request.RequestTypeId == requesttype).ToList();
            }
            int count = model.requestClients.Count();
            int TotalPage = (int)Math.Ceiling(count / (double)PageSize);
            model.requestClients = model.requestClients.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            model.CurrentPage = CurrentPage;
            model.TotalPage = TotalPage;
            return model;
        }

        public AdminDashboardViewModel UnpaidState(int CurrentPage = 1, string patientname = "", int requesttype = 5, int PageSize = 10)
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Where(a => a.Request.Status == 6).ToList();
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = clients;

            if (!string.IsNullOrWhiteSpace(patientname))
            {
                model.requestClients = model.requestClients.Where(a => a.FirstName.ToLower().Contains(patientname.ToLower()) || a.LastName.ToLower().Contains(patientname.ToLower())).ToList();
            }
            if (requesttype == 1 || requesttype == 2 || requesttype == 3 || requesttype == 4)
            {
                model.requestClients = model.requestClients.Where(a => a.Request.RequestTypeId == requesttype).ToList();
            }
            int count = model.requestClients.Count();
            int TotalPage = (int)Math.Ceiling(count / (double)PageSize);
            model.requestClients = model.requestClients.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            model.CurrentPage = CurrentPage;
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

        public void SendAgreement(SendAgreementViewModel model, int request_id)
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

            if(encounter == null)
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
    }
}
