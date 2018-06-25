using CoreMvcEvaluation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreMvcEvaluation.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CheckDisplayNameLengthLessThan30WithFirstNameFirst()
        {
            User user = new User
            {
                Id = 1,
                FirstName = "Jay",
                LastName = "Modi",
                Email = "jay@modi.com",
                PhoneNumber = "321-231-1223"
            };

            Assert.AreEqual("Jay Modi", user.getDisplayName());
        }

        [TestMethod]
        public void CheckDisplayNameLengthMoreThan30WithFirstNameFirst()
        {
            User user = new User
            {
                Id = 1,
                FirstName = "JayJAyewrewrwerwerwerwerwerwerwerwer",
                LastName = "Modi",
                Email = "jay@modi.com",
                PhoneNumber = "321-231-1223"
            };

            Assert.AreEqual("JayJAyewrewrwerwerwerwerwer...", user.getDisplayName());
        }

        [TestMethod]
        public void CheckDisplayNameLengthLessThan30WithLastNameFirst()
        {
            User user = new User
            {
                Id = 1,
                FirstName = "Jay",
                LastName = "Modi",
                Email = "jay@modi.com",
                PhoneNumber = "321-231-1223"
            };

            Assert.AreEqual("Modi, Jay", user.getDisplayNameLastFirst());
        }

        [TestMethod]
        public void CheckDisplayNameLengthMoreThan30WithLastNameFirst()
        {
            User user = new User
            {
                Id = 1,
                FirstName = "JayJAyewrewrwerwerwerwerwerwerwerwer",
                LastName = "Modi",
                Email = "jay@modi.com",
                PhoneNumber = "321-231-1223"
            };

            Assert.AreEqual("Modi, JayJAyewrewrwerwerwer...", user.getDisplayNameLastFirst());
        }

    }
}
