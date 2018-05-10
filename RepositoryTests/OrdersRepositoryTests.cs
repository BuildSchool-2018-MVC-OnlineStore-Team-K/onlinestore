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
        public void GetAllTest_Repository_new()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.OrdersRepository();
            var orders = repository.GetAll();
            Assert.IsTrue(orders.Count() > 0);
        }
    }
}

