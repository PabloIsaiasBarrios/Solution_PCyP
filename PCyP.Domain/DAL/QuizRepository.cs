using Db4objects.Db4o;
using PCyP.Domain.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.DAL
{
    public class QuizRepository : BaseRepository, ICrud<Quiz>
    {
        public void Add(Quiz model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                db.Store(model);
                db.Commit();
                db.Close();
            }
        }

        public List<Quiz> All()
        {
            var lista = new List<Quiz>();
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Quiz());
                while (result != null && result.HasNext()) lista.Add((Quiz)result.Next());

                db.Close();
            }
            return lista;
        }

        public void Delete(Quiz model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Quiz { Id = model.Id });
                var proto = (Quiz)result[0];
                db.Delete(proto);
                db.Commit();
                db.Close();
            }
        }

        public void Edit(Quiz model)
        {
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(new Quiz { Id = model.Id });
                var proto = (Quiz)result[0];
                ObjectMapper(model, proto);
                db.Store(proto);
                db.Commit();
                db.Close();
            }
        }

        public Quiz Find(Quiz model)
        {
            Quiz proto;
            using (var db = Db4oFactory.OpenFile(Path))
            {
                var result = db.QueryByExample(model);
                proto = (Quiz)result[0];
                db.Close();
            }
            return proto;
        }

        public ParallelQuery<Quiz> ParallelQuery()
        {
            throw new NotImplementedException();
        }
    }
}
