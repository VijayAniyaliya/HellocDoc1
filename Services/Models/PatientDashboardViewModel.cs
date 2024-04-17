using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class PatientDashboardViewModel
    {
        public List<DashboardData> dashboardDatas {  get; set; }

        public int CurrentPage { get; set; }

        public int TotalPage { get; set; }
    }

    public class DashboardData
    {
        public int RequestId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Status { get; set; }

        public int FileCount { get; set; }

        public string? ProviderName { get; set; }
    }
}
