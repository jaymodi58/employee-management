using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore;
using CoreMvcEvaluation.Models;
using CoreMvcEvaluation.ViewModels;

namespace CoreMvcEvaluation.Controllers
{
    public class UsersController : Controller
    {
        private TestContext db = new TestContext(new DbContextOptionsBuilder<Models.TestContext>().UseSqlServer(string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName={0}\MVCCoreEval.mdf;Integrated Security=True;Trusted_Connection=True;", AppDomain.CurrentDomain.GetData("ContentRootPath") + @"\App_Data")).Options);
        private UserService svcUser = new UserService();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.Include(u => u.EmpType).ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            UserViewModel vm = new UserViewModel(user);
            return PartialView("Details",vm);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            UserViewModel vm = new UserViewModel();
            vm.IsActive = true;
            return View(vm);
        }

        // GET: Users/Details/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            UserViewModel vm = new UserViewModel(user);
            return View("Create", vm);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            if (svcUser.emailExists(vm.Email))
            {
                ModelState["Email"].Errors.Add("A user with this email address already exists");
                return View(vm);
            }
            User u= new Models.User();
            u.Email = vm.Email;
            u.FirstName = vm.FirstName;
            u.LastName = vm.LastName;
            u.PhoneNumber = vm.PhoneNumber;
            u.EmpType = db.EmployeeTypes.Find(int.Parse(vm.EmpTypeSelected));
            u.CompanyName = vm.CompanyName;
            u.IsActive = vm.IsActive;
            u.CreatedBy = -1;
            u.CreatedDate = DateTime.UtcNow;
            
            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
