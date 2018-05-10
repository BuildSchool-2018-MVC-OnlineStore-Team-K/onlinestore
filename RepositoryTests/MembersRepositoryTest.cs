using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.MembersRepositoryTests
{
    [TestClass()]
    public class MembersRepositoryTest
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.MembersRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }
    }
}
