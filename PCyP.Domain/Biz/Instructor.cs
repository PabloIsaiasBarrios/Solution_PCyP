using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.Biz
{
    public class Instructor: EntityBase
    {
        public String Alias { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public DateTime HireDate { get; set; }
        public Boolean IsFulltime { get; set; }
        public Double Salary { get; set; }
        public int TotalCourses { get; set; }
        public String ExternalId { get; set; }
        public DateTime DeletedOn { get; set; }
        public int DeletedBy { get; set; }
        public Boolean IsDeleted { get; set; }

        public Instructor()
        {
            this.IsFulltime = false;
            this.TotalCourses = 0;
            this.IsDeleted = false;
        }

    }
}
