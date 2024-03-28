using Data.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class CreateAdminViewModel
    {
        public int PhysicianId { get; set; }
        [Required(ErrorMessage = "Username is required")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]

        public string Password { get; set; }
        [Required(ErrorMessage = "role is required")]

        public int role { get; set; }
        public List<Role> Role { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^([A-z][A-Za-z]*\s*[A-Za-z]*)$", ErrorMessage = "Please Enter Valid First Name")]


        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^([A-z][A-Za-z]*\s*[A-Za-z]*)$", ErrorMessage = "Please Enter Valid Last Name")]


        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(17, MinimumLength = 9, ErrorMessage = "Invalid Phonenumber")]
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Phone number should contain only numbers")]

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Medical Liencense is required")]

        public string MediLiencense { get; set; }
        [Required(ErrorMessage = "NPI number is required")]

        public string NPI { get; set; }
        [Required(ErrorMessage = "please select regions")]


        public string[] RegionSelected { get; set; }

        public List<Region> RegionList { get; set; }

        [Required(ErrorMessage = "address1 is required")]

        public string address1 { get; set; }

        public string? address2 { get; set; }
        [Required(ErrorMessage = "city is required")]

        public string city { get; set; }
        [Required(ErrorMessage = "state is required")]

        public int state { get; set; }
        [Required(ErrorMessage = "zipcode is required")]


        [RegularExpression(@"^[0-9]{6}|[0-9]{5}(?:[-\s][0-9]{4})?$", ErrorMessage = "ZipCode Format is Invalid")]
        public string zip { get; set; }

        [StringLength(17, MinimumLength = 9, ErrorMessage = "Invalid Phonenumber")]
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Phone number should contain only numbers")]
        public string? altphonenumber { get; set; }

    }
}
