using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using BuildSchool.MVCSolution.OnlineStore.Models;
using System.Linq;

namespace BuildSchool.MVCSolution.OnlineStore.PSRepositoryTests 
{
    [TestClass]
    public class StockColorRepositoryTests
    {
        [TestMethod]
        public void GetAll()
        {
            var repository = new StockColorRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod]
        public void GetSizeColorStock()
        {
            var repository = new StockColorRepository();
            var result = repository.GetSizeColorStock(5);
            Assert.AreEqual(5, result);
        }
    }
}
