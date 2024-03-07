using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class PaginationViewModel<T>
    {
        public List<T> Data { get; set; }
        public string CurrentPage { get; set; }

        public int TotalPage { get; set; }
    }
}
