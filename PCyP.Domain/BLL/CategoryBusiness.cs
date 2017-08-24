using PCyP.Domain.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    public static class CategoryBusiness
    {

        private static List<Category> _categoryList = new List<Category>();

        /// <summary>
        /// Descripcion del metodo Add
        /// </summary>
        /// <param name="categoria"></param>
        public static void Add(Category categoria)
        {
            _categoryList.Add(categoria);
        }
        /// <summary>
        /// Descripcion del metodo GetCategoryList
        /// </summary>
        /// <returns></returns>
        public static List<Category>  GetCategoryList()
        {
            return _categoryList;
        }
        
    }
}
