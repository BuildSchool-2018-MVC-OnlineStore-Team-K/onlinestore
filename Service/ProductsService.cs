using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.OrderDetailRepository;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using ViewModels;

namespace Service
{
    public class ProductsService
    {
        ProductsRepository repo = new ProductsRepository();

        public void AddToCart(AddToCartViewModel viewmodel)
        {
            var orderrepo = new OrdersRepository();
            var orderdetailrepo = new OrderDetailRepository();

            //加入判斷cart ==0
            orderrepo.AddToCartOrders(viewmodel);
            orderdetailrepo.AddToCartOrderDetail(viewmodel, orderrepo.AddToCartOrders(viewmodel));
        }

        public IEnumerable<Products> GetProductsTable()
        {
            return repo.GetProductsTable();
        }

        public IEnumerable<Products> GetProductsByCategory(string category)
        {
            return repo.GetProductsByCategory(category);
        }

        public List<ProductSize> DistinctSize(IEnumerable<ProductsViewModel> list)
        {
            //var result = new ProductsRepository();
            var newlist = new List<ProductSize>();
            foreach (var item in list)
            {
                if (newlist.Any((x) => x.SizeType == item.SizeType))
                {
                    continue;
                }
                else
                {
                    newlist.Add(new ProductSize { SizeType = item.SizeType });
                }
            }
            return newlist;
        }

        public List<ProductColor> DistinctColor(IEnumerable<ProductsViewModel> list, int productid, string sizetype)
        {
            var newlist = new List<ProductColor>();
            var color = list.Where((x) => x.ProductID == productid && x.SizeType == sizetype);
            foreach (var item in color)
            {
                newlist.Add(new ProductColor { Color = item.Color });
            }
            return newlist;
        }

        public int? ProductColorStock(IEnumerable<ProductsViewModel> list, int productid, string sizetype, string color)
        {
            int? productstock = 0;
            var stock = list.Where((x) => x.ProductID == productid && x.SizeType == sizetype && x.Color == color);
            foreach (var item in stock)
            {
                productstock += item.Stock;
            };
            return productstock;
        }

        public IEnumerable<ProductHomeViewModel> ProductHome()
        {
            var repo = new ProductsRepository();
            return repo.GetTop5Products();
        }
    }
}
