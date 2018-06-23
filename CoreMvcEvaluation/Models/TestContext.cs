using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreMvcEvaluation.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options) { }

        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName={0}\MVCCoreEval.mdf;Integrated Security=True;Trusted_Connection=True;", AppDomain.CurrentDomain.GetData("ContentRootPath") + @"\App_Data"));
            }
        }
    }
}
