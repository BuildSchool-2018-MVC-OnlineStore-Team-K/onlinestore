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
        ProductsRepository repo = new ProductsRepository();
        [TestMethod()]
        public void ProductGetAll()
        {
            var list = repo.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void OrderByUnitpriceTest()
        {
            var list = repo.OrderByUnitprice();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void OrderByUnitpriceDESCTest()
        {
            var list = repo.OrderByUnitpriceDESC();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void GetTop8ProductTest()
        {
            var list = repo.GetTop8Product();
            Assert.IsTrue(list.Count() > 0);
        }



        [TestMethod()]
        public void OrderByShelfTimeDESCTest()
        {
            var list = repo.OrderByShelfTimeDESC();
            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void GetProductNameTest()
        {
            var result = repo.GetProductName(2);
            Assert.AreEqual(result, "短袖牛仔褲");
        }

        [TestMethod()]
        public void ProductFindById()
        {
            var result = repo.FindById(1);
            Assert.IsTrue(result.Count() == 1);
        }
    }
}