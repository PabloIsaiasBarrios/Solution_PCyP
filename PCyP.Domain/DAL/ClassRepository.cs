using Db4objects.Db4o;
using PCyP.Domain.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.DAL
{
    public class ClassRepository : BaseRepository, ICrud<Class>
    {
        public void Add(Class model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                db.Store(model);
                db.Commit();
                db.Close();
            }
        }

        public List<Class> All()
        {
            var lista = new List<Class>();
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Instructor());
                while (result != null && result.HasNext()) lista.Add((Class)result.Next());

                db.Close();
            }
            return lista;
        }

        public void Delete(Class model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Class { Id = model.Id });
                var proto = (Class)result[0];
                db.Delete(proto);
                db.Commit();
                db.Close();
            }
        }

        public void Edit(Class model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Class { Id = model.Id });
                var proto = (Class)result[0];
                ObjectMapper(model, proto);
                db.Store(proto);
                db.Commit();
                db.Close();
            }
        }

        public Class Find(Class model)
        {
            Class proto;
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(model);
                proto = (Class)result[0];
                db.Close();
            }
            return proto;
        }

        public ParallelQuery<Class> ParallelQuery()
        {
            throw new NotImplementedException();
        }
    }
}
