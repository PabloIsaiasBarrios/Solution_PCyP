using PCyP.Domain.Biz;
using PCyP.Domain.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCyP.WebSite.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Index()
        {
            return View(InstructorBusiness.Instance.GetInstructorList());
        }

        // GET: Instructor/Details/5
        public ActionResult Details(string id)
        {
            return View(InstructorBusiness.Instance.GetInstructorDetails(id));
        }

        // GET: Instructor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instructor/Create
        [HttpPost]
        public ActionResult Create(Instructor instructor)
        {
            try
            {
                // TODO: Add insert logic here
                InstructorBusiness.Instance.Add(instructor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instructor/Edit/5
        public ActionResult Edit(string id)
        {
            return View(InstructorBusiness.Instance.GetInstructorDetails(id));
        }

        // POST: Instructor/Edit/5
        [HttpPost]
        public ActionResult Edit(Instructor instructor)
        {
            try
            {
                // TODO: Add update logic here
                InstructorBusiness.Instance.EditInstructor(instructor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instructor/Delete/5
        public ActionResult Delete(string id)
        {
            return View(InstructorBusiness.Instance.GetInstructorDetails(id));
        }

        // POST: Instructor/Delete/5
        [HttpPost]
        public ActionResult Delete(Instructor instructor)
        {
            try
            {
                // TODO: Add delete logic here
                InstructorBusiness.Instance.DeleteInstructor(instructor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
