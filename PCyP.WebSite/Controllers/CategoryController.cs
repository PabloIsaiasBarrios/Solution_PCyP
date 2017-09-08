using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCyP.Domain.DAL;
using PCyP.Domain.Biz;
using System.Web.Mvc;
using PCyP.Domain.BLL;

namespace PCyP.WebSite.Controllers
{
    public class CategoryController : Controller
    {

        // GET: Category
        public ActionResult Index()
        {
            return View(CategoryBusiness.Instance.GetCategoryList());
        }

        // GET: Category/Details/5
        public ActionResult Details(string id)
        {
            return View(CategoryBusiness.Instance.GetCategoryDetails(id));
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {

                CategoryBusiness.Instance.Add(model);
                return Redirect("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(string id)
        {
            return View(CategoryBusiness.Instance.GetCategoryDetails(id));
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            try
            {
                CategoryBusiness.Instance.EditCategory(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(string id)
        {
            return View(CategoryBusiness.Instance.GetCategoryDetails(id));
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Category model)
        {
            try
            {
                // TODO: Add delete logic here
                CategoryBusiness.Instance.DeleteCategory(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
