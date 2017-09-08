using PCyP.Domain.Biz;
using PCyP.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    public class InstructorBusiness
    {
        private InstructorRepository db;


        #region Singleton

        private static InstructorBusiness _instance;

        private InstructorBusiness()
        {
            this.db = new InstructorRepository();
        }

        public static InstructorBusiness Instance
        {
           get
           {
                if (_instance == null)
                    _instance = new InstructorBusiness();
                return _instance;
            }
        }


        #endregion

        public void Add(Instructor instructor)
        {
            instructor.Alias = instructor.FirstName.Substring(0, 1)+ instructor.MiddleName.Substring(0,1) + instructor.LastName;
            instructor.HireDate = DateTime.Now;
            instructor.Id = Guid.NewGuid().ToString();
            instructor.CreatedOn = DateTime.Now;
            instructor.CreatedBy = 0;
            instructor.ChangedOn = DateTime.Now;
            instructor.ChangedBy = 0;
            instructor.IsDeleted = false;
            instructor.IsFulltime = false;
            db.Add(instructor);
        }

        public List<Instructor> GetInstructorList()
        {
            return this.db.All();
        }

        public Instructor GetInstructorDetails(string id)
        {
            var instructor = db.Find(new Instructor { Id = id });
            return instructor;
        }

        public void EditInstructor(Instructor instructor)
        {
            instructor.Alias = instructor.FirstName.Substring(0, 1) + instructor.MiddleName.Substring(0, 1) + instructor.LastName;
            instructor.HireDate = instructor.HireDate;
            instructor.ChangedOn = DateTime.Now;
            instructor.ChangedBy = 0;
            db.Edit(instructor);
        }

        public void DeleteInstructor(Instructor model)
        {
            //model.IsDeleted = true;
            //model.DeletedOn = DateTime.Now;
            //model.DeletedBy = 0;

            db.Delete(model);
        }
    }
}
