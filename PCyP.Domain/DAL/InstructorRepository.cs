using Db4objects.Db4o;
using PCyP.Domain.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.DAL
{
    public class InstructorRepository : BaseRepository, ICrud<Instructor>
    {
        public void Add(Instructor model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                db.Store(model);
                db.Commit();
                db.Close();
            }
        }

        public List<Instructor> All()
        {
            var lista = new List<Instructor>();
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Instructor());
                while (result != null && result.HasNext()) lista.Add((Instructor)result.Next());

                db.Close();
            }
            return lista;
        }

        public void Delete(Instructor model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Instructor { Id = model.Id });
                var proto = (Instructor)result[0];
                db.Delete(proto);
                db.Commit();
                db.Close();
            }
        }

        public void Edit(Instructor model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Instructor { Id = model.Id });
                var proto = (Instructor)result[0];
                ObjectMapper(model, proto);
                db.Store(proto);
                db.Commit();
                db.Close();
            }
        }

        public Instructor Find(Instructor model)
        {
            Instructor proto;
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(model);
                proto = (Instructor)result[0];
                db.Close();
            }
            return proto;
        }

        public ParallelQuery<Instructor> ParallelQuery()
        {
            throw new NotImplementedException();
        }
    }
}
