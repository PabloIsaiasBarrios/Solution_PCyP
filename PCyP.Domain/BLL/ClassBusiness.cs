using PCyP.Domain.Biz;
using PCyP.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    class ClassBusiness
    {
        private ClassRepository db;


        #region Singleton

        private static ClassBusiness _instance;

        private ClassBusiness()
        {
            this.db = new ClassRepository();
        }

        public static ClassBusiness Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ClassBusiness();
                return _instance;
            }
        }


        #endregion

        public void Add(Class model)
        {
            model.Id = Guid.NewGuid().ToString();
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = 0;
            model.ChangedOn = DateTime.Now;
            model.ChangedBy = 0;
            db.Add(model);
        }

        public List<Class> GetClassList()
        {
            return this.db.All();
        }

        public Class GetClassDetails(string id)
        {
            var clase = db.Find(new Class { Id = id });
            return clase;
        }

        public void EditClass(Class model)
        {
            model.ChangedOn = DateTime.Now;
            model.ChangedBy = 0;
            db.Edit(model);
        }

        public void DeleteClass(Class model)
        {
            db.Delete(model);
        }
    }
}
