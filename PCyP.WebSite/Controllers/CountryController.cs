using PCyP.Domain.Biz;
using PCyP.Domain.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCyP.WebSite.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            return View(CountryBusiness.Instance.GetCountryList());
        }

        // GET: Country/Details/5
        public ActionResult Details(string id)
        {
            return View(CountryBusiness.Instance.GetCountryDetails(id));
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(Country country)
        {
            try
            {
                // TODO: Add insert logic here
                CountryBusiness.Instance.Add(country);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(string id)
        {
            return View(CountryBusiness.Instance.GetCountryDetails(id));
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(Country model)
        {
            try
            {
                // TODO: Add delete logic here
                CountryBusiness.Instance.Delete(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
