using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using BuildSchool.MVCSolution.OnlineStore.Models;
using System.Linq;

namespace BuildSchool.MVCSolution.OnlineStore.DicountsRepositoryTests
{
    [TestClass]
    public class DiscountsRepositoryTests
    {
        [TestMethod]
        public void Discounts_GetAllTest()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.DiscountRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod]
        public void Discounts_UpdateTest()
        {
            var repository = new DiscountRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod]
        public void Discounts_OrderByDiscountTest()
        {
            var repository = new DiscountRepository();
            var list = repository.OrderByDiscount();
            Assert.IsTrue(list.Count() > 0);
        }
    }
}
