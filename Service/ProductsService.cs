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
        public IEnumerable<ProductsViewModel> GetProductDetailById(int ProductID)
        {
            var repository = new ProductsRepository();
            return repository.GetProductDetail(ProductID);
        }

        public IEnumerable<ProductsViewModel> GetAllProductDetail()
        {
            var repository = new ProductsRepository();
            return repository.GetAllProductsDetail();
        }

        public bool UpdateProductInfo(int ProductId)
        {
            var repository = new ProductsRepository();
            return true;
        }
    }
}
