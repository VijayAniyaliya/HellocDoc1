using System.ComponentModel.DataAnnotations;

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

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid First Name")]
        [Required(ErrorMessage = "First name is required")] 

        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Last Name")]
        [Required(ErrorMessage = "Last name is required")]

        public string LastName { get; set; }
        [Required]

        public DateTime DOB { get; set; }

        public int IsMobile { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Phone number should contain only numbers")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits")]

        public string phone { get; set; }
        [Required]

        public string Email { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid Street")]
        [Required(ErrorMessage = "Street is required")]

        public string Street { get; set; }
        [Required(ErrorMessage = " City name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Valid City")]

        public string City { get; set; }
        [Required]

        public string State { get; set; }
        [Required(ErrorMessage = "ZipCode is required")]
        [RegularExpression(@"^[0-9]{6}|[0-9]{5}(?:[-\s][0-9]{4})?$", ErrorMessage = "ZipCode Format is Invalid")]

        public string ZipCode { get; set; }
    }
}
