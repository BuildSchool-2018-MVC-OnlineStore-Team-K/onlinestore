<<<<<<< HEAD
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
=======
﻿using System;
>>>>>>> e8a299becf2cdce0fe6a46f19e880e9e58d677fd
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildSchool.MVCSolution.OnlineStore.Models;
using System.Linq;

<<<<<<< HEAD
namespace BuildSchool.MVCSolution.OnlineStore.SizeRepositoryTests
=======
namespace BuildSchool.MVCSolution.OnlineStore.SizeRepositoryTest
>>>>>>> e8a299becf2cdce0fe6a46f19e880e9e58d677fd
{
    [TestClass]
    public class SizeRepositoryTests
    {
        [TestMethod]
        public void GetAll()
        {
<<<<<<< HEAD
            var repository = new BuildSchool.MVCSolution.OnlineStore.Repository.SizeRepository();
=======
            var repository = new BuildSchool.MVCSolution.OnlineStore.SizeRepository.SizeRepository();
>>>>>>> e8a299becf2cdce0fe6a46f19e880e9e58d677fd
            var list = repository.GetAll();
            Assert.IsTrue(list.Count() > 0);
        }
    }
}
