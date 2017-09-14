using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.Biz
{
    public class Quiz: EntityBase
    {
        public string Reference { get; set; }
        public Enrollment Enrollment{ get; set; }
        public DateTime QuizDate { get; set; }
        public double Grade { get; set; }

        public Quiz()
        {
        }
    }
}
