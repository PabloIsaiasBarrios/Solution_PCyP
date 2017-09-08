using PCyP.Domain.Biz;
using PCyP.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    public class StudentBusiness
    {
        private StudentRepository db;

        #region Singleton


        private static StudentBusiness _instance;

        private StudentBusiness()
        {
            this.db = new StudentRepository();
        }

        public static StudentBusiness Instance
        {
            get
            {

                if (_instance == null)
                    _instance = new StudentBusiness();
                return _instance;
            }

        }


        #endregion


        public  void Add(Student student)
        {
            student.Alias = student.FirstName.Substring(0, 1) + student.LastName;
            student.Id = Guid.NewGuid().ToString();
            student.CreatedOn = DateTime.Now;
            student.CreatedBy = 0;
            student.ChangedOn = DateTime.Now;
            student.ChangedBy = 0;
            db.Add(student);
        }

        public  List<Student> GetStudentList()
        {
            return db.All();
        }

        public Student GetStudentDetails(string id)
        {
            var categoria = db.Find(new Student { Id = id });
            return categoria;
        }

        public void EditStudent(Student student)
        {
            student.Alias = student.FirstName.Substring(0, 1) + student.LastName;
            student.ChangedOn = DateTime.Now;
            student.ChangedBy = 0;
            db.Edit(student);
        }

        public void DeleteStudent(Student model)
        {
            db.Delete(model);
        }
    }
}
