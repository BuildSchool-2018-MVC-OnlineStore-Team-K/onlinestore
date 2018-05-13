﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.MembersRepositoryTests
{
    [TestClass()]
    public class MembersRepositoryTest
    {
        [TestMethod()]
        public void MemberGetAllTest()
        {
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.MembersRepository();
            var result = repository.All;
            Assert.IsTrue(result.Count() > 0);
        }
    }
}
