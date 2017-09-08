using PCyP.Domain.Biz;
using PCyP.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    public class CategoryBusiness
    {
        private CategoryRepository db;


        #region Singleton


        private static CategoryBusiness _instance;

        private CategoryBusiness()
        {
            this.db = new CategoryRepository();
        }

        public static CategoryBusiness Instance
        {
            get
            {

                if (_instance == null)
                    _instance = new CategoryBusiness();
                return _instance;
            }

        } 


        #endregion
        
        
        /// <summary>
        /// Descripcion del metodo Add
        /// </summary>
        /// <param name="categoria"></param>
        public void Add(Category categoria)
        {
            categoria.Id = Guid.NewGuid().ToString();
            categoria.CreatedOn = DateTime.Now;
            categoria.CreatedBy = 0; // Environment.UserName // Obtener usuario
            categoria.ChangedOn = DateTime.Now;
            categoria.ChangedBy = 0;
            db.Add(categoria);
        }
        /// <summary>
        /// Descripcion del metodo GetCategoryList
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategoryList()
        {
            return db.All();
        }

        public Category GetCategoryDetails(string id)
        {
            var categoria = db.Find(new Category { Id = id });
            return categoria;
        }

        public void EditCategory(Category model)
        {
            model.ChangedOn = DateTime.Now;
            model.ChangedBy = 0;
            db.Edit(model);
        }

        public void DeleteCategory(Category model)
        {
            db.Delete(model);
        }
    }
}
