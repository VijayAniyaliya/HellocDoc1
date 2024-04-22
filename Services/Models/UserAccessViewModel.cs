using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{   
    public class UserAccessViewModel
    {

        public List<UserAccess> userAccessDatas { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPage { get; set; }

    }
    public class UserAccess
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public int accType { get; set; }
        public string phone { get; set; }
        public short status { get; set; }
        public int openReq { get; set; }
        public int PhysicianId { get; set; }



    }
}
