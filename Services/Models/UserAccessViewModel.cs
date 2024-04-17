using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{   
    public class UserAccessViewModel
    {

        public List<UserAccessData> userAccessDatas { get; set; }

    }
    public class UserAccessData
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public int accType { get; set; }
        public string phone { get; set; }
        public short status { get; set; }
        public int openReq { get; set; }

    }
}
