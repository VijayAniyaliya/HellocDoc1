using Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class AddBusinessViewModel
    {
        public List<HealthProfessionalType>? professionalTypes { get; set; }

        [Required(ErrorMessage = "Profession is required")]
        public int ProfessionId { get; set; }
        public int VendorId { get; set; }

        [Required(ErrorMessage = "Vendor Name is required")]
        public string VendorName { get; set; }

        public string Profession { get; set; }

        [Required(ErrorMessage = "FaxNumber is required")]
        public string FaxNumber { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string? BusinessContact { get; set; }
        public string? Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        public string? ZipCode { get; set; }
    }
}