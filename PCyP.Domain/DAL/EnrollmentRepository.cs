using Db4objects.Db4o;
using PCyP.Domain.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.DAL
{
    public class EnrollmentRepository: BaseRepository, ICrud<Enrollment>
    {
        public void Add(Enrollment model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                db.Store(model);
                db.Commit();
                db.Close();
            }
        }

        public List<Enrollment> All()
        {
            var lista = new List<Enrollment>();
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Enrollment());
                while (result != null && result.HasNext()) lista.Add((Enrollment)result.Next());

                db.Close();
            }
            return lista;
        }

        public void Delete(Enrollment model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Enrollment { Id = model.Id });
                var proto = (Enrollment)result[0];
                db.Delete(proto);
                db.Commit();
                db.Close();
            }
        }

        public void Edit(Enrollment model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Enrollment { Id = model.Id });
                var proto = (Enrollment)result[0];
                ObjectMapper(model, proto);
                db.Store(proto);
                db.Commit();
                db.Close();
            }
        }

        public Enrollment Find(Enrollment model)
        {
            Enrollment proto;
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(model);
                proto = (Enrollment)result[0];
                db.Close();
            }
            return proto;
        }

        public ParallelQuery<Enrollment> ParallelQuery()
        {
            throw new NotImplementedException();
        }
    }
}
