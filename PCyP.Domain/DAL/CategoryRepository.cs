using Db4objects.Db4o;
using PCyP.Domain.Biz;
using PCyP.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.DAL
{
    public class CategoryRepository : BaseRepository, ICrud<Category>
    {
        public void Add(Category categoria)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                db.Store(categoria);
                db.Commit();
                db.Close();
            }
        }

        public List<Category> All()
        {
            var lista = new List<Category>();
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Category());
                while (result != null && result.HasNext()) lista.Add((Category)result.Next());

                db.Close();
            }
            return lista;
        }

        public void Delete(Category model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Category { Id = model.Id });
                var proto = (Category)result[0];
                db.Delete(proto);
                db.Commit();
                db.Close();
            }
        }

        public void Edit(Category model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Category { Id = model.Id });
                var proto = (Category)result[0];
                ObjectMapper(model, proto);
                db.Store(proto);
                db.Commit();
                db.Close();
            }
        }

        public Category Find(Category model)
        {
            Category proto;
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(model);
                proto = (Category)result[0];
                db.Close();
            }
            return proto;
        }

        public ParallelQuery<Category> ParallelQuery()
        {
            throw new NotImplementedException();
        }
    }
}
