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

        [TestMethod()]
        public void OrdersRepository_UpdateCartToOrdersTest()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.OrdersRepository();
            var OrderID = 1;
            var MemberID = 1;
            var orders = repository.UpdateCartToOrders(OrderID, MemberID);
            Assert.IsTrue(orders.Equals(1));
        }

        [TestMethod()]
        public void OrdersRepository_GetCartOrderID()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.OrdersRepository();
            var MemberID = 1;
            var orders = repository.GetCartOrderID(MemberID);
            Assert.IsTrue(orders > 0);

        }

        [TestMethod()]
        public void _GetAllTest()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.OrdersRepository();

            var orders = repository._GetAll();
            Assert.IsTrue(orders.Count() > 0);
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

