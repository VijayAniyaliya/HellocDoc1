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
    public class PhysicianAccountViewModel
    {
        public int PhysicianId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        public List<int> status { get; set; }
        public string rolename { get; set; }
        public int StatusCode { get; set; }
        public List<Role> Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


        public string MediLiencense { get; set; }
        public string NPI { get; set; }
        public string SynchroEmail { get; set; }
        public List<PhysicianRegion> physicianRegions { get; set; }
        public List<Region> RegionList { get; set; }

        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }

        [RegularExpression(@"^[0-9]{6}|[0-9]{5}(?:[-\s][0-9]{4})?$", ErrorMessage = "ZipCode Format is Invalid")]
        public string zip { get; set; }
        public string altphonenumber { get; set; }

        public string BusinessName { get; set; }

        public string BusinessWeb { get; set; }

        public IEnumerable<IFormFile>? Photo { get; set; }
        public IEnumerable<IFormFile>? Sign { get; set; }

        public string AdminNotes { get; set; }

    }

    public class AccountData
    {
        public string Username { get; set; }
        public int StatusCode { get; set; }
        public int Role { get; set; }

    }

    public class UpdatePhycisianInfo
    {
        public int PhysicianId { get; set; }

        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }

        public string mediliencense { get; set; }

        public string npi { get; set; }

        public string synchroemail { get; set; }
        public int[] RegionSelected { get; set; }
    }
    public class ModifyBillingData
    {
        public int PhysicianId { get; set; }

        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }

        [RegularExpression(@"^[0-9]{6}|[0-9]{5}(?:[-\s][0-9]{4})?$", ErrorMessage = "ZipCode Format is Invalid")]
        public string zip { get; set; }
        public string altphonenumber { get; set; }
    }
    public class ModifyProfileData
    {
        public int PhysicianId { get; set; }

        public string businessname { get; set; }
        public string businessweb { get; set; }
        public string adminnotes { get; set; }
    }
}