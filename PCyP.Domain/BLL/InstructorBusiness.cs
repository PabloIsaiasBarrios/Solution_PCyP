using PCyP.Domain.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    public static class InstructorBusiness
    {
        private static List<Instructor> _InstructorList = new List<Instructor>();

        public static void Add(Instructor instructor)
        {
            _InstructorList.Add(instructor);
        }

        public static List<Instructor> GetInstructorList()
        {
            return _InstructorList;
        }
    }
}
