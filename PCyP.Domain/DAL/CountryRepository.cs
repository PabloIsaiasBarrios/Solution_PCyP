using Db4objects.Db4o;
using PCyP.Domain.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.DAL
{
    public class CountryRepository : BaseRepository, ICrud<Country>
    {
        public void Add(Country model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                db.Store(model);
                db.Commit();
                db.Close();
            }
        }

        public List<Country> All()
        {
            var lista = new List<Country>();
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Country());
                while (result != null && result.HasNext()) lista.Add((Country)result.Next());

                db.Close();
            }
            return lista;
        }

        public void Delete(Country model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Country { Id = model.Id });
                var proto = (Country)result[0];
                db.Delete(proto);
                db.Commit();
                db.Close();
            }
        }

        public void Edit(Country model)
        {
            throw new NotImplementedException();
        }

        public Country Find(Country model)
        {
            Country proto;
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(model);
                proto = (Country)result[0];
                db.Close();
            }
            return proto;
        }

        public ParallelQuery<Country> ParallelQuery()
        {
            throw new NotImplementedException();
        }
    }
}
