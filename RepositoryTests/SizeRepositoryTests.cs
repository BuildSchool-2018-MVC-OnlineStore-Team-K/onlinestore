using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using BuildSchool.MVCSolution.OnlineStore.Models;
using System.Linq;

namespace BuildSchool.MVCSolution.OnlineStore.SizeRepositoryTests
{ 
    [TestClass]
    public class SizeRepositoryTests
    {
        [TestMethod]
        public void GetAll()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.SizeRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }
    }
}
