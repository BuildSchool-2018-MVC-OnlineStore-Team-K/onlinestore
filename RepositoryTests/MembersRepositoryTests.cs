using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.Repository.Tests
{
    [TestClass()]
    public class MembersRepositoryTests
    {
        [TestMethod()]
        public void CheckAccountIsNotExistTest()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.MembersRepository();
            var booool = repository.CheckAccountIsExist("1233");
            Assert.IsTrue(booool);

        }

        [TestMethod()]
        public void CheckFbIdExistTest()
        {
            string id = "1255852617878731";
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.MembersRepository();
            var result =  repository.CheckFbIdExist(id);
            Assert.IsTrue(result);
        }
    }
}