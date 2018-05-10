using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.OrdersRepositoryTests
{
    [TestClass()]
    public class OrdersRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.OrdersRepository();
            var result = repository.GetAll();
            Assert.IsTrue(result.Count() > 0);
        }
    }
}