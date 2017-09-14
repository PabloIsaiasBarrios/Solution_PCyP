using Db4objects.Db4o;
using PCyP.Domain.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.DAL
{
    public class CourseRepository : BaseRepository, ICrud<Course>
    {
        public void Add(Course model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                db.Store(model);
                db.Commit();
                db.Close();
            }
        }

        public List<Course> All()
        {
            var lista = new List<Course>();
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Course());
                while (result != null && result.HasNext()) lista.Add((Course)result.Next());

                db.Close();
            }
            return lista;
        }

        public void Delete(Course model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Course { Id = model.Id });
                var proto = (Course)result[0];
                db.Delete(proto);
                db.Commit();
                db.Close();
            }
        }

        public void Edit(Course model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Course { Id = model.Id });
                var proto = (Course)result[0];
                ObjectMapper(model, proto);
                db.Store(proto);
                db.Commit();
                db.Close();
            }
        }

        public Course Find(Course model)
        {
            Course proto;
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(model);
                proto = (Course)result[0];
                db.Close();
            }
            return proto;
        }

        public ParallelQuery<Course> ParallelQuery()
        {
            throw new NotImplementedException();
        }
    }
}
