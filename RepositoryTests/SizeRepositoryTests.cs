using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MVCSolution.OnlineStore.Models;
using System.Linq;

namespace BuildSchool.MVCSolution.OnlineStore.SizeRepositoryTest
{
    [TestClass]
    public class SizeRepositoryTests
    {
        [TestMethod]
        public void GetAll()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.SizeRepository.SizeRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }
    }
}
