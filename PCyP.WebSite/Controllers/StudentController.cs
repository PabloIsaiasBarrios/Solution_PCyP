using PCyP.Domain.Biz;
using PCyP.Domain.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCyP.WebSite.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View(StudentBusiness.Instance.GetStudentList());
        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            return View(StudentBusiness.Instance.GetStudentDetails(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here
                StudentBusiness.Instance.Add(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            return View(StudentBusiness.Instance.GetStudentDetails(id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                // TODO: Add update logic here
                StudentBusiness.Instance.EditStudent(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            return View(StudentBusiness.Instance.GetStudentDetails(id));
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            try
            {
                // TODO: Add delete logic here
                StudentBusiness.Instance.DeleteStudent(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
