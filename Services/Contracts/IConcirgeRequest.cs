﻿using HellocDoc1.Services.Models;

namespace Services.Contracts
{
    public interface IConcirgeRequest
    {
        Task Concierge_request(ConciergeRequestModel model);
    }
}