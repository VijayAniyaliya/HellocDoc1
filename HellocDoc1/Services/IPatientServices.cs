﻿using HellocDoc1.DataModels;
using HellocDoc1.DTO;

namespace HellocDoc1.Services
{
    public interface IPatientServices
    {
        List<Request> DashboardService(string Email);

        PatientServiceModel DocumentService(int Requestid);
    }
}