using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class AdminDashboardViewModel
    {

        public List<RequestClient> requestClients {  get; set; }

        public int requestCount { get; set; }


    }
}
