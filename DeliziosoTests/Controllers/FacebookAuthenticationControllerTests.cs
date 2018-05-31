using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;

namespace WebApplication1.Controllers.Tests
{
    [TestClass()]
    public class FacebookAuthenticationControllerTests
    {
        [TestMethod()]
        public void FacebookTest()
        {
            var id = "1255852617878731";
           var service = new CheckMember();
           var result =  service.CheckFbRegistered(id);
            Assert.IsTrue(result);
        }
    }
}