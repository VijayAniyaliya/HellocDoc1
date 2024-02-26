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

        public int newCount { get; set; }

        public int pendingCount { get; set; }

        public int activeCount { get; set; }

        public int concludeCount { get; set; }

        public int tocloseCount { get; set; }

        public int unpaidCount { get; set; }


    }
}
