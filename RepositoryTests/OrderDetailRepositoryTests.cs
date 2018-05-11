using BuildSchool.MVCSolution.OnlineStore.OrderDetailRepository;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MVCSolution.OnlineStore.Models;
using System.Linq;

namespace BuildSchool.MVCSolution.OnlineStore.OrderDetailRepository.Tests
{
    [TestClass()]
    public class OrderDetailRepositoryTests
    {
        [TestMethod()]
        public void GetTotalQuantiyByProductIDTest()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.OrderDetailRepository.OrderDetailRepository();
            var result = repository.GetTotalQuantiyByProductID(1);
            Assert.AreEqual(result, 2);
        }
    }
}

namespace BuildSchool.MVCSolution.OnlineStore.OrderDetailRepositoryTest
{
    [TestClass]
    public class OrderDetailRepositoryTests
    {
        [TestMethod]
        public void GetAll()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.OrderDetailRepository.OrderDetailRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }
    }
}
