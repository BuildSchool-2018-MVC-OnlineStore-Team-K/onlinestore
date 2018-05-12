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
    public class OrdersRepositoryTests
    {
        [TestMethod()]
        public void OrdersRepository_GetByOrderIDTest()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.OrdersRepository();
            var OrderID = 2;
            var orders = repository.GetByOrderID(OrderID);
            Assert.IsTrue(orders.Count() == 1);

        }
    }
}

namespace BuildSchool.MVCSolution.OnlineStore.OrdersRepositoryTests
{
    [TestClass()]
    public class OrdersRepositoryTests
    {
        [TestMethod()]
        public void OrdersRepository_GetAll()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.OrdersRepository();
            var orders = repository.GetAll();
            Assert.IsTrue(orders.Count() > 0);
        }
    }
}

