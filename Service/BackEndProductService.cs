using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Service
{
    public class BackEndProductService
    {
        //單純以商品名稱排序
        public IEnumerable<CreateProductsModel> OrderByProducts(IEnumerable<CreateProductsModel> list)
        {
            IEnumerable<CreateProductsModel> query = list.OrderBy(x => x.ProductName);
            return query;
        }
        //待處理: 輸入一模一樣資料 , 輸入除了庫存以外其他都一樣的資料
        //待處理: 輸入與資料庫一模一樣資料的話 庫存增加就好


        public List<string> GetDifferentProductName(IEnumerable<CreateProductsModel> list)
        {
            var newlist = new List<string>();
            foreach (var item in list) {
                if (!newlist.Any((x) => x == item.ProductName))
                {
                    newlist.Add(item.ProductName);

                }
            }
            return newlist;
        }

        public void InsertIntoDataBase(IEnumerable<CreateProductsModel> list)
        {
            var repository = new ProductsRepository();
            foreach(var item in list)
            {
                var productlist = new Products();
                productlist.Category = item.Category;
                productlist.ProductName = item.ProductName;
                productlist.UnitPrice = item.Price;
                var _productID = repository.CreateProductDetail(productlist);


                var sizelist = new Size(); //productID
                sizelist.SizeType = item.Size;
                sizelist.ProductID = _productID;
                var _sizeID =  repository.CreateProductSize(sizelist);


                var StockColor = new StockColor();
                StockColor.Color = item.Color;
                StockColor.Stock = item.Stock;
                StockColor.SizeID = _sizeID;
                repository.CreateStockColor(StockColor);

            }

            
        }

    }
}
