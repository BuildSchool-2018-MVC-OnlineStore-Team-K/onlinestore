using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MVCSolution.OnlineStore.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.CustomerRepository.Tests
{
    [TestClass()]
    public class SizeRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.CustomerRepository.SizeRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }
    }
}