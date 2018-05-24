using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using ViewModels;

namespace Service
{
    public class HomeService
    {
        public IEnumerable<Products> DisplayPicNamePrice()
        {
            var db = new ProductsRepository();
            var result = db.GetTop8Product();
            return result;
        }
    }
}
