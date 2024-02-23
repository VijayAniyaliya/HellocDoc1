using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Entity;
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

            AdminDashboardViewModel model = new AdminDashboardViewModel();
            var requestCount = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 1).Count();
            model.requestCount = requestCount;
            return model;

        }
        public AdminDashboardViewModel NewState()
        {
            List<RequestClient> clients = _context.RequestClients.Include(a => a.Request).Where(a => a.Request.Status == 1).ToList();
            
            AdminDashboardViewModel model = new AdminDashboardViewModel();
            model.requestClients = clients;
            return model;

        }
    }
}
