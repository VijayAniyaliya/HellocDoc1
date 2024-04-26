﻿using Common.Enum;
using Common.Helpers;
using Data.Context;
using Data.Entity;
using HalloDoc.Utility;
using HellocDoc1.Services.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Models;
using System;
using System.Collections;
using System.Globalization;
using System.IO.Compression;
using System.Security.Claims;

namespace HellocDoc1.Services
{
    public class PatientServices : IPatientServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor HttpContextAccessor;
        private readonly IHostingEnvironment _environment;

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 6)
                      + Path.GetExtension(fileName);
        }
        public PatientServices(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IHostingEnvironment environment)
        {
            _context = context;
            HttpContextAccessor = httpContextAccessor;
            _environment = environment;

        }
        public async Task<PatientDashboardViewModel> DashboardData(int requestedPage, string email)
        {
            List<Request> requests = await _context.Requests.Include(a => a.RequestWiseFiles).Include(a => a.Physician).Where(a=> a.Email == email).ToListAsync();
            List<DashboardData> obj = requests.Select(a => new DashboardData() { RequestId = a.RequestId, CreatedDate = a.CreatedDate, Status = a.Status, FileCount = a.RequestWiseFiles.Count(), ProviderName = a.Physician?.FirstName + " " + a.Physician?.LastName }).ToList();

            if (requests != null)
            {
                int count = obj!.Count();
                int TotalPage = (int)Math.Ceiling(count / (double)10);
                obj = obj!.Skip((requestedPage - 1) * 10).Take(10).ToList();

                PatientDashboardViewModel model = new PatientDashboardViewModel()
                {
                    dashboardDatas = obj,
                    CurrentPage = requestedPage,
                    TotalPage = TotalPage,
                };
                return model;
            }
            return new PatientDashboardViewModel();
        }

        public async Task<PatientServiceModel> DocumentService(int request_id)
        {
            Request? data = await _context.Requests.Where(x => x.RequestId == request_id).FirstOrDefaultAsync();
            RequestClient requestClient = _context.RequestClients.Where(x => x.RequestId == request_id).FirstOrDefault()!;
            List<RequestWiseFile> requestWiseFile = _context.RequestWiseFiles.Where(x => x.RequestId == request_id).ToList();

            if (data != null && requestClient != null)
            {
                PatientServiceModel patientService = new PatientServiceModel()
                {
                    request = data,
                    requestWiseFile = requestWiseFile,
                    requestClient = requestClient!

                };
                return patientService;
            }
            return new PatientServiceModel();
        }

        public async Task UploadDocument(PatientServiceModel model, int request_id)
        {
            IEnumerable<IFormFile> upload = model.Doc;
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
            await _context.SaveChangesAsync();
        }

        public async Task<byte[]> DownloadFilesForRequest(int request_id)
        {

            var zipName = $"RequestFiles-{request_id}-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

            using (MemoryStream ms = new MemoryStream())
            {
                using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {

                    var filesForRequest = await _context.RequestWiseFiles
                        .Where(file => file.RequestId == request_id)
                        .ToListAsync();

                    var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                    foreach (var file in filesForRequest)
                    {
                        var filepath = Path.Combine(uploads, file.FileName);

                        if (!string.IsNullOrEmpty(filepath) && System.IO.File.Exists(filepath))
                        {
                            var entry = zip.CreateEntry(Path.GetFileName(filepath));

                            using (var entryStream = entry.Open())
                            using (var fileStream = System.IO.File.OpenRead(filepath))
                            {
                                await fileStream.CopyToAsync(entryStream);
                            }
                        }
                    }
                }



                return (ms.ToArray());
            }

        }

        public async Task<ProfileViewModel> ProfileService(string Email)
        {
            User? data = await _context.Users.Where(x => x.Email == Email).FirstOrDefaultAsync();
            if (data != null)
            {
                int month = (int)Enum.Parse(typeof(Month), data.StrMonth!);
                ProfileViewModel model = new ProfileViewModel()
                {
                    UserId = data.UserId,
                    FirstName = data.FirstName,
                    LastName = data.LastName!,
                    phone = data.Mobile!,
                    Email = data.Email,
                    DOB = DateTime.ParseExact($"{data.IntYear}-{month}-{data.IntDate}", "yyyy-M-d", CultureInfo.InvariantCulture),
                    Street = data.Street!,
                    IsMobile = (data.IsMobile == null || data.IsMobile[0] == true) ? 1 : 0,
                    City = data.City!,
                    State = data.State!,
                    ZipCode = data.ZipCode!,
                };
                return model;
            }
            return new ProfileViewModel();
        }

        public async Task Editing(string email, ProfileViewModel model)
        {
            User? userdata = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (userdata != null)
            {
                userdata.FirstName = model.FirstName;
                userdata.LastName = model.LastName;
                userdata.Mobile = model.phone;
                userdata.IsMobile = (model.IsMobile == 1) ? new BitArray(new[] { true }) : (new BitArray(new[] { false }));
                userdata.Street = model.Street;
                userdata.City = model.City;
                userdata.State = model.State;
                userdata.IntDate = model.DOB.Day;
                userdata.IntYear = model.DOB.Year;
                userdata.StrMonth = model.DOB.ToString("MMM");
                userdata.ZipCode = model.ZipCode;
                userdata.ModifiedDate = DateTime.Now;
                _context.Users.Update(userdata);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<PatientRequestModel> SubmitInformationMe(string email)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(a => a.Email == email);

            if (user != null)
            {
                PatientRequestModel model = new PatientRequestModel();
                model.FirstName = user.FirstName;
                model.LastName = user.LastName!;
                model.Email = user.Email;
                model.PhoneNumber = user.Mobile!;
                return model;
            }
            return new PatientRequestModel();
        }

        public async Task SubmitInformationSomeone(SubmitInfoViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    AspNetUser? aspnetuser = await _context.AspNetUsers.Where(x => x.Email == model.Email).FirstOrDefaultAsync();
                    User? user = await _context.Users.Where(a => a.Email == model.Email).FirstOrDefaultAsync();
                    Region? regiondata = await _context.Regions.FirstOrDefaultAsync(a => a.RegionId == model.State);
                    List<Request>? requestcount = await _context.Requests.Where(a => a.CreatedDate.Date == DateTime.Today).ToListAsync();

                    Request request = new Request()
                    {
                        RequestTypeId = (int)Common.Enum.RequestType.FamilyFriend,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserId = user != null ? user.UserId : null,
                        PhoneNumber = model.PhoneNumber,
                        Email = model.Email,
                        RelationName = model.RelationWithPatient,
                        Status = (int)Common.Enum.RequestStatus.Unassigned,
                        IsUrgentEmailSent = new BitArray(1),
                        CreatedDate = DateTime.Now,
                        ConfirmationNumber = regiondata?.Abbreviation?.ToUpper() + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0')
                                         + DateTime.Now.Year.ToString().Substring(2) + model.LastName.Substring(0, 2).ToUpper() + model.FirstName.Substring(0, 2).ToUpper() +
                                         (requestcount.Count() + 1).ToString().PadLeft(4, '0'),
                    };
                    await _context.Requests.AddAsync(request);

                    RequestClient requestclient = new RequestClient()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        IntDate = model.DOB.Day,
                        IntYear = model.DOB.Year,
                        StrMonth = model.DOB.ToString("MMM"),
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Street = model.Street,
                        State = regiondata?.Name,
                        City = model.City,
                        ZipCode = model.ZipCode,
                        Notes = model.Symptoms,
                        RegionId = regiondata?.RegionId,
                    };

                    if (model.Doc != null)
                    {
                        foreach (var item in model.Doc)
                        {
                            var file = item.FileName;
                            var uniqueFileName = GetUniqueFileName(file);
                            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                            var filePath = Path.Combine(uploads, uniqueFileName);
                            item.CopyTo(new FileStream(filePath, FileMode.Create));

                            RequestWiseFile requestWiseFile = new RequestWiseFile()
                            {
                                Request = request,
                                FileName = uniqueFileName,
                                CreatedDate = DateTime.Now,

                            };
                            await _context.RequestWiseFiles.AddAsync(requestWiseFile);

                        }
                    }
                    request.RequestClients.Add(requestclient);
                    await _context.RequestClients.AddAsync(requestclient);
                    await _context.SaveChangesAsync();

                    if (aspnetuser == null)
                    {
                        string requestId = HashingServices.Encrypt(request.RequestId.ToString());
                        await EmailSender.SendGmail("aniyariyavijay441@gmail.com", "Create Your Account", $"<a href=\"https://localhost:7208/Patient/CreatePatientAccount/{requestId}\">Create Account</a>");

                        EmailLog emailLog = new EmailLog()
                        {
                            EmailTemplate = "https://localhost:7208/Patient/CreatePatientAccount/",
                            SubjectName = "Create Your Account",
                            EmailId = requestclient.Email,
                            ConfirmationNumber = request.ConfirmationNumber,
                            RequestId = request.RequestId,
                            CreateDate = DateTime.Now,
                            SentDate = DateTime.Now,
                            SentTries = 1,
                            IsEmailSent = new BitArray(new[] { true }),
                        };
                        _context.EmailLogs.Add(emailLog);
                        await _context.SaveChangesAsync();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }

            }
        }
        public async Task<LoginResponseViewModel> ResetPassword(LoginViewModel model)
        {
            var user = await _context.AspNetUsers.Where(u => u.Email == model.Email).FirstOrDefaultAsync();

            if (user == null)
            {
                return new LoginResponseViewModel() { Status = ResponseStatus.Failed, Message = "User Not Found" };
            }
            else
            {
                string email = HashingServices.Encrypt(model.Email);
                await EmailSender.SendGmail("aniyariyavijay441@gmail.com", "Hello", $"Please <a href=\"https://localhost:7208/Patient/ChangePassword/{email}\">Reset</a>");
                return new LoginResponseViewModel() { Status = ResponseStatus.Success };
            }
        }

        public async Task<User> CheckEmail(string email)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public async Task ChangePassword(string email, ChangePassViewModel model)
        {
            var user = await _context.AspNetUsers.Where(u => u.Email == email).FirstOrDefaultAsync();

            if (user != null)
            {
                user.PasswordHash = HashingServices.Encrypt(model.Password);

                _context.AspNetUsers.Update(user);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<SendAgreementViewModel> ReviewAgreement(string request_id)
        {
            var data = await _context.Requests.Where(a => a.RequestId == int.Parse(request_id)).FirstOrDefaultAsync();

            SendAgreementViewModel model = new SendAgreementViewModel()
            {
                RequestId = int.Parse(request_id),
                PatientName = data.FirstName + " " + data.LastName,
            };

            return model;
        }

        public async Task AcceptAgreement(int request_id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var data = _context.Requests.Where(a => a.RequestId == request_id).FirstOrDefault();
                    data!.Status = (int)RequestStatus.MdEnRoute;

                    RequestStatusLog requestStatusLog = new RequestStatusLog()
                    {
                        RequestId = request_id,
                        Status = (int)RequestStatus.MdEnRoute,
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

        public async Task CancelAgreement(int request_id, string reason)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var data = _context.Requests.FirstOrDefault(a => a.RequestId == request_id);
                    data.Status = (int)RequestStatus.CancelledByPatient;

                    RequestStatusLog requestStatusLog = new RequestStatusLog()
                    {
                        RequestId = request_id,
                        Status = (int)RequestStatus.CancelledByPatient,
                        Notes = reason,
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
    }
}
