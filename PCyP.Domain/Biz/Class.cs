using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.Biz
{
    public class Class : EntityBase
    {
        public string Reference { get; set; }
        public Course Course { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxEnrollments { get; set; }
        public int TotalEnrollments { get; set; }

        public Class()
        {
            
        }
    }
}
