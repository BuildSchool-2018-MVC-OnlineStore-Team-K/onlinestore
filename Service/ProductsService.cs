using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using ViewModels;

namespace Service
{
    public class ProductsService
    {
        public IEnumerable<ProductsViewModel> GetProductDetail(int ProductID)
        {
            var result = new ProductsRepository();
            return result.GetProductDetail(ProductID);
        }
    }
}
