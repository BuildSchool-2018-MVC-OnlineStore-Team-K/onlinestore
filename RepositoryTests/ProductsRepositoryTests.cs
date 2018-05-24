using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.MVCSolution.OnlineStore.Repository;

namespace BuildSchool.MVCSolution.OnlineStore.ProductsRepositoryTests
{
    [TestClass()]
    public class ProductsRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var repository = new ProductsRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void OrderByUnitpriceTest()
        {
            var repository = new ProductsRepository();
            var list = repository.OrderByUnitprice();
            Assert.IsTrue(list.Count()>0);
        }

        [TestMethod()]
        public void OrderByUnitpriceDESCTest()
        {
            var repository = new ProductsRepository();
            var list = repository.OrderByUnitpriceDESC();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void GetTop8Product()
        {
            var repository = new ProductsRepository();
            var list = repository.GetTop8Product();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void OrderByShelfTimeDESCTest()
        {
            var repository = new ProductsRepository();
            var list = repository.OrderByShelfTimeDESC();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void GetProductNameTest()
        {
            var repository = new ProductsRepository();
            var result = repository.GetProductName(2);
            Assert.AreEqual(result, "短袖牛仔褲");
        }
    }
}