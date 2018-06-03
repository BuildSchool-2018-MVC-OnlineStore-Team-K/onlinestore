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
        public IEnumerable<ProductsViewModel> GetProductDetailAll(int ProductID)
        {
            var result = new ProductsRepository();
            return result.GetProductDetail(ProductID);
        }

        public ProductsDetailViewModel GetProductDetail(IEnumerable<ProductsViewModel> list, int ProductID)
        {
            var result = list.FirstOrDefault((x) => x.ProductID == ProductID);
            var productsdetail = new ProductsDetailViewModel()
            {
                ProductID = result.ProductID,
                ProductName = result.ProductName,
                Category = result.Category,
                UnitPrice = result.UnitPrice,
                Picture = result.Picture
            };
            return productsdetail;
        }

        public List<ProductSize> DistinctSize(IEnumerable<ProductsViewModel> list)
        {
            //var result = new ProductsRepository();
            var newlist = new List<ProductSize>();
            foreach(var item in list)
            {
                if (newlist.Any((x)=>x.SizeType == item.SizeType))
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

        public List<ProductColor> DistinctColor(IEnumerable<ProductsViewModel> list, int productid,string sizetype)
        {
            var newlist = new List<ProductColor>();            
            var color = list.Where((x) => x.ProductID == productid && x.SizeType == sizetype);
            foreach(var item in color)
            {
                newlist.Add(new ProductColor { Color = item.Color });
            }
            return newlist;
        }

        public int? ProductColorStock(IEnumerable<ProductsViewModel> list, int productid, string sizetype,string color)
        {
            int? productstock = 0;
            var stock = list.Where((x) => x.ProductID == productid && x.SizeType == sizetype && x.Color == color);
            foreach(var item in stock)
            {
                productstock += item.Stock;
            };
            return productstock;
        }

        public string GetCountyDDL(IEnumerable<ProductsViewModel> list, int productid, string sizetype)
        {
            using (TestDBEntities db = new TestDBEntities())
            {
                var newlist = new List<ProductColor>();
                var color = list.Where((x) => x.ProductID == productid && x.SizeType == sizetype);

                Dictionary<string, string> optionData = new Dictionary<string, string>();
                string keyText = string.Empty;

                foreach (var item in color)
                {
                    keyText = string.Concat(item.POSTAL_CODE.ToString(), " ", item.NAME.Trim());
                    if (optionData.Keys.Where(x => x == keyText).Count().Equals(0))
                    {
                        optionData.Add(keyText, item.POSTAL_CODE.ToString());
                    }
                }

                var pid = productid.ToString();
                if (string.IsNullOrWhiteSpace(pid))
                {
                    pid = "Color";
                }
                string _html = DropDownListHelper.GetDropdownList(pid, pid, optionData, null, sizetype, true, null);
                return _html;
            }
        }
    }
}
