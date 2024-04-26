using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class EncounterFormViewModel
    {
        public int RequestId { get; set; }

        public int AdminID { get; set; }

        [Required(ErrorMessage = "First name is required")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Location is required")]

        public string Location { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]

        public DateTime DOB { get; set; }

        public string Dateofbirth { get; set; }

        [Required(ErrorMessage = "Date of Services is required")]

        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[+]?[0-9]*$", ErrorMessage = "Phone number should contain only numbers")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits")]

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]

        public string Email { get; set; }
        public string? HistoryOfPatient { get; set; }
        public string? MedicalHistory { get; set; }
        public string? Medications { get; set; }
        public string? Allergies { get; set; }
        public string? Temp { get; set; }
        public string? HeartRate { get; set; }
        public string? RespiratoryRate { get; set; }
        public string? BloodPressure { get; set; }
        public string? BloodPressure1 { get; set; }
        public string? O2 { get; set; }
        public string? Pain { get; set; }
        public string? Heent { get; set; }
        public string? CV { get; set; }
        public string? Chest { get; set; }
        public string? ABD { get; set; }
        public string? Extr { get; set; }
        public string? Skin { get; set; }
        public string? Neuro { get; set; }
        public string? Other { get; set; }
        public string? Disgnosis { get; set; }

        [Required]
        public string TreatmentPlan { get; set; }
        [Required]

        public string MedicationDispnsed { get; set; }
        [Required]

        public string Procedure { get; set; }
        [Required]

        public string FollowUp { get; set; }
        public bool? IsFinalize { get; set; }
        public int IsEncounter { get; set; }    
    }
}
