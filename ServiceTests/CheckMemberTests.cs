using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
    [TestClass()]
    public class CheckMemberTests
    {
        [TestMethod()]
        public void CheckFbRegisteredTest()
        {
            string id = "1255852617878731";
            var service = new CheckMember();
            var result = service.CheckFbRegistered(id);
            Assert.IsTrue(result);
        }
    }
}