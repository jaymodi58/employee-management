using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvcEvaluation.Models
{
    public class TestContextFactory : IDesignTimeDbContextFactory<TestContext>
    {
        public TestContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
            optionsBuilder.UseSqlServer(string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName={0}\MVCCoreEval.mdf;Integrated Security=True;Trusted_Connection=True;", AppDomain.CurrentDomain.GetData("ContentRootPath") + @"\App_Data"));

            return new TestContext(optionsBuilder.Options);
        }
    }
}
