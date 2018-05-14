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
        public void GetProductNameTest()
        {
            var repository = new ProductsRepository();
            var list = repository.GetProductName(2);
            Assert.Equals("短褲",list);
        }
    }
}