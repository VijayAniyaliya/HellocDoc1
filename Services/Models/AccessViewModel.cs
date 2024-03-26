using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class AccessViewModel
    {
        public List<RoleData> roleData {  get; set; }
    }

    public class RoleData
    {
        public int RoleId { get; set; }

        public string Name { get; set; }
        public int AccountType { get; set; }
    }

    public class CreateAccessViewModel
    {
        public List<int> menus { get; set; }

        public string RoleName { get; set; }

        public int AccountType { get; set; }

        public int[] MenuData { get; set; }
        public List<Menu> Menu { get; set; }
    }  
    
    public class FilterByAccountViewModel
    {
    }
}
