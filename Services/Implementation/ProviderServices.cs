using Common.Enum;
using Data.Context;
using Data.Entity;
using HalloDoc.Utility;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Models;
using System.Collections;

namespace Services.Implementation
{   
    public class ProviderServices : IProviderServices
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
        public ProviderServices(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _environment = hostEnvironment;

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
            List<RequestClient> clients = await _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Include(a => a.Request.RequestStatusLogs).Include(a => a.Request.EncounterForms).Where(a => a.Request.Status == 4 || a.Request.Status == 5).ToListAsync();
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
            List<RequestClient> clients = await _context.RequestClients.Include(a => a.Request).Include(x => x.Request.Physician).Include(a => a.Request.EncounterForms).Where(a => a.Request.Status == 6).ToListAsync();
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
                await EmailSender.SendGmail("aniyariyavijay441@gmail.com", "Agreement Video", $"Watch Aggreement Video");
            }
            await _context.SaveChangesAsync();
        }

        public async Task AddNotes(AddNotesViewModel model, int request_id, string email)
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
                data.ModifiedDate = DateTime.Now;
                RequestStatusLog requestStatusLog = new RequestStatusLog()
                {
                    RequestId = request_id,
                    Status = (int)RequestStatus.Unassigned,
                    Notes = reason,
                    PhysicianId = physician!.PhysicianId,
                    CreatedDate = DateTime.Now,
                    TransToAdmin = new BitArray(1, true),
                };
                _context.Requests.Update(data);
                await _context.RequestStatusLogs.AddAsync(requestStatusLog);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Consult(int request_id)
        {
            Request? request = await _context.Requests.FirstOrDefaultAsync(a => a.RequestId == request_id);
            if (request != null)
            {
                request.Status = (int)RequestStatus.Concluded;
                request.ModifiedDate = DateTime.Now;
                RequestStatusLog requestStatusLog = new RequestStatusLog()
                {
                    RequestId = request_id,
                    Status = (int)RequestStatus.Concluded,
                    CreatedDate = DateTime.Now,
                };
                _context.Requests.Update(request);
                _context.RequestStatusLogs.Add(requestStatusLog);
                await _context.SaveChangesAsync();
            }
        }

        public async Task HouseCall(int request_id)
        {
            Request? request = await _context.Requests.FirstOrDefaultAsync(a => a.RequestId == request_id);
            if (request != null)
            {
                request.Status = (int)RequestStatus.MdOnSite;
                request.ModifiedDate = DateTime.Now;
                RequestStatusLog requestStatusLog = new RequestStatusLog()
                {
                    RequestId = request_id,
                    Status = (int)RequestStatus.MdOnSite,
                    CreatedDate = DateTime.Now,
                };
                _context.Requests.Update(request);
                _context.RequestStatusLogs.Add(requestStatusLog);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Housecalling(int request_id)
        {
            Request? request = await _context.Requests.FirstOrDefaultAsync(a => a.RequestId == request_id);
            if (request != null)
            {
                request.Status = (int)RequestStatus.Concluded;
                request.ModifiedDate = DateTime.Now;
                RequestStatusLog requestStatusLog = new RequestStatusLog()
                {
                    RequestId = request_id,
                    Status = (int)RequestStatus.Concluded,
                    CreatedDate = DateTime.Now,
                };
                _context.Requests.Update(request);
                _context.RequestStatusLogs.Add(requestStatusLog);
                await _context.SaveChangesAsync();
            }
        }

        public async Task finalize(int request_id)
        {
            EncounterForm? encounterForm = await _context.EncounterForms.FirstOrDefaultAsync(a => a.RequestId == request_id);

            if (encounterForm != null)
            {
                encounterForm.IsFinalize = true;
                _context.EncounterForms.Update(encounterForm);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IActionResult> DownloadEncounter(int request_id)
        {
            var request = await _context.RequestClients.Include(u => u.Request).FirstOrDefaultAsync(U => U.RequestId == request_id);
            var encounter = await _context.EncounterForms.FirstOrDefaultAsync(x => x.RequestId == request!.RequestId);
            EncounterFormViewModel model = new EncounterFormViewModel();
            if (request != null)
            {
                model.RequestId = request.RequestId;
                model.FirstName = request.FirstName;
                model.LastName = request.LastName;
            }
            model.Dateofbirth = request.StrMonth + " " + request.IntDate + " " + request.IntYear;
            model.PhoneNumber = request.PhoneNumber;
            model.Email = request.Email;
            model.Location = request.Address;

            if (encounter != null)
            {
                model.HistoryOfPatient = encounter.HistoryOfPresentIllnessOrInjury;
                model.MedicalHistory = encounter.MedicalHistory;
                model.Medications = encounter.Medications;
                model.Allergies = encounter.Allergies;
                model.Temp = encounter.Temp;
                model.HeartRate = encounter.Hr;
                model.RespiratoryRate = encounter.Rr;
                model.BloodPressure = encounter.BloodPressureSystolic;
                model.BloodPressure1 = encounter.BloodPressureDiastolic;
                model.O2 = encounter.O2;
                model.Pain = encounter.Pain;
                model.Heent = encounter.Heent;
                model.CV = encounter.Cv;
                model.Chest = encounter.Chest;
                model.ABD = encounter.Abd;
                model.Extr = encounter.Extremeties;
                model.Skin = encounter.Skin;
                model.Neuro = encounter.Neuro;
                model.Other = encounter.Other;
                model.Disgnosis = encounter.Diagnosis;
                model.TreatmentPlan = encounter.TreatmentPlan;
                model.MedicationDispnsed = encounter.MedicationsDispensed;
                model.Procedure = encounter.Procedures;
                model.FollowUp = encounter.FollowUp;
                model.IsFinalize = encounter.IsFinalize;
            }
            var pdf = new iTextSharp.text.Document();
            using (var memoryStream = new MemoryStream())
            {
                var writer = PdfWriter.GetInstance(pdf, memoryStream);
                pdf.Open();

                // Add content to the PDF here. For example:
                pdf.Add(new Paragraph($"First Name: {model.FirstName}"));
                pdf.Add(new Paragraph($"Last Name: {model.LastName}"));
                pdf.Add(new Paragraph($"DOB: {model.Dateofbirth}"));
                pdf.Add(new Paragraph($"Mobile: {model.PhoneNumber}"));
                pdf.Add(new Paragraph($"Email: {model.Email}"));
                pdf.Add(new Paragraph($"Location: {model.Location}"));
                pdf.Add(new Paragraph($"History Of Illness: {model.HistoryOfPatient}"));
                pdf.Add(new Paragraph($"Medical History: {model.MedicalHistory}"));
                pdf.Add(new Paragraph($"Medication: {model.Medications}"));
                pdf.Add(new Paragraph($"Allergies: {model.Allergies}"));
                pdf.Add(new Paragraph($"Temp: {model.Temp}"));
                pdf.Add(new Paragraph($"HR: {model.HeartRate}"));
                pdf.Add(new Paragraph($"RR: {model.RespiratoryRate}"));
                pdf.Add(new Paragraph($"BPs: {model.BloodPressure}"));
                pdf.Add(new Paragraph($"BPd: {model.BloodPressure1}"));
                pdf.Add(new Paragraph($"O2: {model.O2}"));
                pdf.Add(new Paragraph($"Pain: {model.Pain}"));
                pdf.Add(new Paragraph($"Heent: {model.Heent}"));
                pdf.Add(new Paragraph($"CV: {model.CV}"));
                pdf.Add(new Paragraph($"Chest: {model.Chest}"));
                pdf.Add(new Paragraph($"ABD: {model.ABD}"));
                pdf.Add(new Paragraph($"Extr: {model.Extr}"));
                pdf.Add(new Paragraph($"Skin: {model.Skin}"));
                pdf.Add(new Paragraph($"Neuro: {model.Neuro}"));
                pdf.Add(new Paragraph($"Other: {model.Other}"));
                pdf.Add(new Paragraph($"Diagnosis: {model.Disgnosis}"));
                pdf.Add(new Paragraph($"Treatment Plan: {model.TreatmentPlan}"));
                pdf.Add(new Paragraph($"Medications Dispended: {model.MedicationDispnsed}"));
                pdf.Add(new Paragraph($"Procedure: {model.Procedure}"));
                pdf.Add(new Paragraph($"Followup: {model.FollowUp}"));
                pdf.Add(new Paragraph($"Is Finaled: {model.IsFinalize}"));

                pdf.Close();
                writer.Close();

                var bytes = memoryStream.ToArray();
                var result = new FileContentResult(bytes, "application/pdf");
                result.FileDownloadName = "Encounter_" + model.FirstName + " " + model.LastName + ".pdf";
                return result;
            }
        }

        public async Task<ConcludeCareViewModel> ConcludeCare(int request_id)
        {
            RequestClient? data = await _context.RequestClients.Include(a => a.Request).Include(a => a.Request.RequestWiseFiles).Where(a => a.RequestId == request_id).FirstOrDefaultAsync();
            EncounterForm? encounterForm = await _context.EncounterForms.FirstOrDefaultAsync(a => a.RequestId == request_id);

            if (data != null)
            {
                data!.Request.RequestWiseFiles = data.Request.RequestWiseFiles.Where(x => x.IsDeleted == null || x.IsDeleted[0] == false).ToList();

                ConcludeCareViewModel model = new ConcludeCareViewModel()
                {
                    RequestId = request_id,
                    PatientName = data.FirstName + " " + data.LastName,
                };
                if (encounterForm != null && encounterForm.IsFinalize == true)
                {
                    model.IsFinalize = 1;
                }
                else
                {
                    model.IsFinalize = 0;
                }
                foreach (var item in data.Request.RequestWiseFiles)
                {
                    model.Documents.Add(item.FileName);
                }
                return model;
            }
            return new ConcludeCareViewModel();
        }

        public async Task UploadDocuments(ConcludeCareViewModel model, int request_id)
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

        public async Task ConcludeCase(ConcludeCareViewModel model, string email)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var obj = await _context.Requests.Where(a => a.RequestId == model.RequestId).FirstOrDefaultAsync();
                    var data = await _context.RequestNotes.Where(a => a.RequestId == model.RequestId).FirstOrDefaultAsync();
                    var physician = await _context.Physicians.FirstOrDefaultAsync(a => a.Email == email);

                    if (data != null)
                    {
                        data!.PhysicianNotes = model.ProviderNotes;
                        data.ModifiedBy = physician!.AspNetUserId;
                        data.ModifiedDate = DateTime.Now;
                        _context.RequestNotes.Update(data);
                    }
                    else
                    {
                        RequestNote requestNote = new RequestNote()
                        {
                            RequestId = model.RequestId,
                            AdminNotes = model.ProviderNotes,
                            CreatedBy = physician!.AspNetUserId!,
                            CreatedDate = DateTime.Now,
                        };
                        _context.RequestNotes.Add(requestNote);
                    }

                    if (obj != null && physician != null)
                    {
                        obj.Status = (int)RequestStatus.Closed;
                        RequestStatusLog requestStatusLog = new RequestStatusLog()
                        {
                            RequestId = model.RequestId,
                            Notes = model.ProviderNotes,
                            Status = (int)RequestStatus.Closed,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.RequestStatusLogs.AddAsync(requestStatusLog);
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

        public async Task<SchedullingViewModel> MonthWiseMySchedule(DateTime date, string email)
        {
            Physician? physician = await _context.Physicians.FirstOrDefaultAsync(a => a.Email == email);
            List<ShiftDetail> shiftDetails = await _context.ShiftDetails.Include(a => a.Shift).Include(a => a.Shift.Physician)
                .Where(x => x.ShiftDate.Month == date.Month).Where(a => a.Shift.PhysicianId == physician!.PhysicianId).ToListAsync();
            SchedullingViewModel model = new SchedullingViewModel();

            if (shiftDetails != null)
            {
                shiftDetails = shiftDetails.Where(x => x.IsDeleted == null || x.IsDeleted[0] == false).ToList();
                model.ShiftDetailList = shiftDetails;
                model.ShiftDate = date;
            }
            return model;
        }

        public async Task<CreateNewShift> CreateMyShift(string email)
        {
            List<Region> regions = await _context.Regions.ToListAsync();
            Physician? physician = await _context.Physicians.FirstOrDefaultAsync(a => a.Email == email);

            if (regions != null)
            {
                CreateNewShift model = new CreateNewShift()
                {
                    RegionList = regions,
                    PhysicianId = physician!.PhysicianId,
                };
                return model;
            }
            return new CreateNewShift();
        }

        public async Task<PhysicianAccountViewModel> EditPhysician(string email)
        {
            Physician? physician = await _context.Physicians.Include(x => x.Role).FirstOrDefaultAsync(a => a.Email == email);
            AspNetUser? aspNetUser = await _context.AspNetUsers.Where(a => a.Id == physician.AspNetUserId).FirstOrDefaultAsync();
            List<Role> role = await _context.Roles.ToListAsync();
            List<Region> regions = await _context.Regions.ToListAsync();
            List<PhysicianRegion> physicianRegions = await _context.PhysicianRegions.Where(a => a.PhysicianId == physician.PhysicianId).ToListAsync();

            if (physician != null && regions != null)
            {
                PhysicianAccountViewModel model = new PhysicianAccountViewModel()
                {
                    PhysicianId = physician.PhysicianId,
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

        public async Task RequestToAdmin(int PhysicianId, string message)
        {
            if (PhysicianId != 0)
            {
                await EmailSender.SendGmail("aniyariyavijay441@gmail.com", $"Edit My Profile {PhysicianId}", $"{message}");
            }
        }
    }
}
