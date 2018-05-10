﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.SizeRepositoryTests
{
    [TestClass()]
    public class SizeRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.SizeRepository();
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }
    }
}