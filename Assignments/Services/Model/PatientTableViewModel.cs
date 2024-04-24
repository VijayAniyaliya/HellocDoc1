using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Model
{
    public class PatientTableViewModel
    {
        public List<PatientData> patientDatas {  get; set; }
        public string PatientName { get; set; }

        public int CurrentPage { get; set; }
        public int requestedPage { get; set; }

        public int TotalPage { get; set; }

    }

    public class PatientData
    {
        public int PatientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }


        public short Age { get; set; }

        public string PhoneNumber { get; set; }
        public int Gender { get; set; }

        public int Disease { get; set; }

        public string Doctor { get; set; }



    }
}
