using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.Biz
{
    public class Enrollment: EntityBase
    {
        public string Reference { get; set; }
        public Student Student { get; set; }
        public Class Class { get; set; }
        public DateTime EnrollDate { get; set; }
        public double PaidAmount { get; set; }
        public string Status { get; set; }
        public double AverageGrade { get; set; }
        public string Title { get; set; }
        public double Fee { get; set; }
        public int NumDays { get; set; }

        public Enrollment()
        {
        }
    }
}
