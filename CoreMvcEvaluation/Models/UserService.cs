using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreMvcEvaluation.Models
{
    public class UserService
    {
        private DbContextOptions<TestContext> options { get; set; }

        public UserService()
        {
            options = new DbContextOptionsBuilder<TestContext>().UseSqlServer(string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName={0}\MVCCoreEval.mdf;Integrated Security=True;Trusted_Connection=True;", AppDomain.CurrentDomain.GetData("ContentRootPath") + @"\App_Data")).Options;
        }

        public User getUser(int Id)
        {
            TestContext db = new TestContext(options);
            return db.Users.Include(u => u.EmpType).Single(u => u.Id == Id);
        }
        public User getUser(string Email) {
            User user = new User();
            TestContext db = new TestContext(options);
            user = db.Users.Include(u => u.EmpType).Where(u => u.Email.ToUpper() == Email.ToUpper()).FirstOrDefault();
            return user;
        }

        public int getUserIdByEmail(string Email)
        {
            User user = new User();
            TestContext db = new TestContext(options);
            user = db.Users.Include(u => u.EmpType).Where(u => u.Email.ToUpper() == Email.ToUpper()).FirstOrDefault();
            return user.Id;
        }

        /*
        public bool emailExists(string Email)
        {
            User user = new User();
            TestContext db = new TestContext(options);
            user = db.Users.Include(u => u.EmpType).Where(u => u.Email.ToUpper() == Email.ToUpper()).FirstOrDefault();
            if (user == null) return false;
            return true;
        }
        */

        public bool emailExists(int Id, string Email)
        {
            User user = new User();
            TestContext db = new TestContext(options);
            user = db.Users.Include(u => u.EmpType).Where(u => u.Email.ToUpper() == Email.ToUpper() &&  u.Id != Id).FirstOrDefault();
            if (user == null)
                return false;
            return true;
        }

        public bool canUserLogin(User u)
        {
            bool canLogin = false;
            if (u.IsActive)
            {
                canLogin = true;
            } else
            {
                canLogin = false;
            }
            return canLogin;
        }

        public IEnumerable<SelectListItem> getEmployeeTypeList()
        {
            TestContext db = new TestContext(options);
            return db.EmployeeTypes.OrderBy(e => e.SortOrder).Select(e => new SelectListItem { Text = e.Name, Value = e.Id.ToString() }).ToList();
        }
    }
}