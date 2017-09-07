using PCyP.Domain.Biz;
using PCyP.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    public static class CategoryBusiness
    {

        
        /// <summary>
        /// Descripcion del metodo Add
        /// </summary>
        /// <param name="categoria"></param>
        public static void Add(Category categoria)
        {
            var db = new CategoryRepository();
            categoria.Id = Guid.NewGuid().ToString();
            categoria.CreatedOn = DateTime.Now;
            categoria.CreatedBy = 0;
            categoria.ChangedOn = DateTime.Now;
            categoria.ChangedBy = 0;
            db.Add(categoria);
        }
        /// <summary>
        /// Descripcion del metodo GetCategoryList
        /// </summary>
        /// <returns></returns>
        public static List<Category>  GetCategoryList()
        {
            var db = new CategoryRepository();
            return db.All();
        }

        public static Category getCategoryDetails(string id)
        {
            var db = new CategoryRepository();
            var categoria = db.Find(new Category { Id = id });
            return categoria;
        }

        public static void EditCategory(Category model)
        {
            var db = new CategoryRepository();
            db.Edit(model);
        }

        public static void DeleteCategory(Category model)
        {
            var db = new CategoryRepository();
            db.Delete(model);
        }
    }
}
