using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class ProfileViewModel
    {
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public DateTime DOB { get; set; }

        public int IsMobile { get; set; }
        [Required]

        public string phone { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Street { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string State { get; set; }
        [Required]

        public string ZipCode { get; set; }
    }
}
