using Db4objects.Db4o;
using PCyP.Domain.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.DAL
{
    public class StudentRepository : BaseRepository, ICrud<Student>
    {
        public void Add(Student student)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                db.Store(student);
                db.Commit();
                db.Close();
            }
        }

        public List<Student> All()
        {
            var lista = new List<Student>();
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Student());
                while (result != null && result.HasNext()) lista.Add((Student)result.Next());

                db.Close();
            }
            return lista;
        }

        public void Delete(Student model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Student { Id = model.Id });
                var proto = (Student)result[0];
                db.Delete(proto);
                db.Commit();
                db.Close();
            }
        }

        public void Edit(Student model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Student { Id = model.Id });
                var proto = (Student)result[0];
                ObjectMapper(model, proto);
                db.Store(proto);
                db.Commit();
                db.Close();
            }
        }

        public Student Find(Student model)
        {
            Student proto;
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(model);
                proto = (Student)result[0];
                db.Close();
            }
            return proto;
        }

        public ParallelQuery<Student> ParallelQuery()
        {
            throw new NotImplementedException();
        }
    }
}
