using PCyP.Domain.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    public class StudentBusiness
    {
        private static List<Student> _StudentList = new List<Student>();

        public static void Add(Student student)
        {
            _StudentList.Add(student);
        }

        public static List<Student> GetStudentList()
        {
            return _StudentList;
        }
    }
}
