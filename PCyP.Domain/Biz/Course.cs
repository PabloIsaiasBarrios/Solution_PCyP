using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.Biz
{
    public class Course: EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Categoria { get; set; }
        public Instructor Instructor { get; set; }
        public int NumDays { get; set; }
        public double Fee { get; set; }
        public int TotalClasses { get; set; }
        public DateTime DeletedOn { get; set; }
        public int DeletedBy { get; set; }
        public Boolean IsDeleted { get; set; }

        public Course()
        {

        }

    }
}
