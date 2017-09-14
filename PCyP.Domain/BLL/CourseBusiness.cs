using PCyP.Domain.Biz;
using PCyP.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    public class CourseBusiness
    {
        private CourseRepository db;


        #region Singleton

        private static CourseBusiness _instance;

        private CourseBusiness()
        {
            this.db = new CourseRepository();
        }

        public static CourseBusiness Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CourseBusiness();
                return _instance;
            }
        }


        #endregion

        public void Add(Course course)
        {
            course.Id = Guid.NewGuid().ToString();
            course.CreatedOn = DateTime.Now;
            course.CreatedBy = 0;
            course.ChangedOn = DateTime.Now;
            course.ChangedBy = 0;
            course.IsDeleted = false;
            db.Add(course);
        }

        public List<Course> GetCourseList()
        {
            return this.db.All();
        }

        public Course GetCourseDetails(string id)
        {
            var course = db.Find(new Course { Id = id });
            return course;
        }

        public void EditCourse(Course course)
        {
            course.ChangedOn = DateTime.Now;
            course.ChangedBy = 0;
            db.Edit(course);
        }

        public void DeleteCourse(Course model)
        {
            //model.IsDeleted = true;
            //model.DeletedOn = DateTime.Now;
            //model.DeletedBy = 0;

            db.Delete(model);
        }
    }
}
