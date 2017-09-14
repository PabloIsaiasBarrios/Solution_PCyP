using PCyP.Domain.Biz;
using PCyP.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    public class EnrollmentBusiness
    {
        private EnrollmentRepository db;


        #region Singleton

        private static EnrollmentBusiness _instance;

        private EnrollmentBusiness()
        {
            this.db = new EnrollmentRepository();
        }

        public static EnrollmentBusiness Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EnrollmentBusiness();
                return _instance;
            }
        }


        #endregion

        public void Add(Enrollment model)
        {
            model.Id = Guid.NewGuid().ToString();
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = 0;
            model.ChangedOn = DateTime.Now;
            model.ChangedBy = 0;
            db.Add(model);
        }

        public List<Enrollment> GetEnrollmentList()
        {
            return this.db.All();
        }

        public Enrollment GetEnrollmentDetails(string id)
        {
            var model = db.Find(new Enrollment { Id = id });
            return model;
        }

        public void EditEnrollment(Enrollment model)
        {
            model.ChangedOn = DateTime.Now;
            model.ChangedBy = 0;
            db.Edit(model);
        }

        public void DeleteEnrollment(Enrollment model)
        {
            db.Delete(model);
        }
    }
}
