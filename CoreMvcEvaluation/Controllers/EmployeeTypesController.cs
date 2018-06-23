using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using CoreMvcEvaluation.Models;

namespace CoreMvcEvaluation.Controllers
{
    public class EmployeeTypesController : Controller
    {
        private TestContext db = new TestContext(new DbContextOptionsBuilder<Models.TestContext>().UseSqlServer(string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName={0}\MVCCoreEval.mdf;Integrated Security=True;Trusted_Connection=True;", AppDomain.CurrentDomain.GetData("ContentRootPath") + @"\App_Data")).Options);

        // GET: EmployeeTypes
        public ActionResult Index()
        {
            return View(db.EmployeeTypes.OrderBy(e=>e.SortOrder).ToList());
        }

        // GET: EmployeeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            EmployeeType employeeType = db.EmployeeTypes.Find(id);
            if (employeeType == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            return View(employeeType);
        }

        // GET: EmployeeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(new string[]{"Id,Name,SortOrder"})] EmployeeType employeeType)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeTypes.Add(employeeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeType);
        }

        // GET: EmployeeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            EmployeeType employeeType = db.EmployeeTypes.Find(id);
            if (employeeType == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            return View(employeeType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(new string[] {"Id,Name,SortOrder"})] EmployeeType employeeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeType);
        }

        // GET: EmployeeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            EmployeeType employeeType = db.EmployeeTypes.Find(id);
            if (employeeType == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            return View(employeeType);
        }

        // POST: EmployeeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeType employeeType = db.EmployeeTypes.Find(id);
            db.EmployeeTypes.Remove(employeeType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
