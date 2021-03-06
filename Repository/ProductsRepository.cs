﻿using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Utilities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BuildSchool.MVCSolution.OnlineStore.Repository
{
    public class ProductsRepository
    {
        MyConnectionString source = new MyConnectionString();
        //Create已改成CreateProductDetail

        public IEnumerable<Products> GetProductsByCategory(string category)
        {
            var sql = "SELECT * FROM Products WHERE Category = @Category";
            var parameters = new DynamicParameters();
            parameters.Add("Category", category);
            using (var connection = new SqlConnection(source.connectcloud))
            {
                return connection.Query<Products>(sql, parameters);
            }
        }
        public void Update(Products model)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            var sql = "UPDATE Products SET Category=@category, ProductName=@productname, UnitPrice=@unitprice, ShelfTime=@shelftime,Picture=@picture WHERE ProductID = @productid";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productid", model.ProductID);
            command.Parameters.AddWithValue("@category", model.Category);
            command.Parameters.AddWithValue("@productname", model.ProductName);
            command.Parameters.AddWithValue("@unitprice", model.UnitPrice);
            command.Parameters.AddWithValue("@shelftime", model.ShelfTime);
            command.Parameters.AddWithValue("@picture", model.Picture);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Products model)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            var sql = "Delete FROM Products WHERE ProductID=@productID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productID", model.ProductID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<Products> FindById(int ProductID)
        {
            var query = "SELECT * FROM Products Where ProductID = @ProductID";
            var Parameters = new DynamicParameters();
            Parameters.Add("ProductID", ProductID);
            using (SqlConnection connection = new SqlConnection(source.connectcloud))
            {
                var result = connection.Query<Products>(query, Parameters);
                return result;
            }

        }

        public IEnumerable<Products> GetAll()
        {
            var query = "SELECT p.ProductID, (SELECT Category FROM Products WHERE ProductID = p.ProductID) AS Category,(SELECT ProductName FROM Products WHERE ProductID = p.ProductID) AS ProductName, (SELECT UnitPrice FROM Products WHERE ProductID = p.ProductID) AS UnitPrice,(SELECT ShelfTime FROM Products WHERE ProductID = p.ProductID) AS ShelfTime,(SELECT TOP 1 Discount FROM Discounts WHERE ProductID = p.ProductID AND EndTime >= GETDATE() ORDER BY StartTime DESC) AS Discount FROM Products p LEFT JOIN Discounts d ON d.ProductID = p.ProductID GROUP BY p.ProductID";
            using (SqlConnection connection = new SqlConnection(source.connectcloud))
            {
                var result = connection.Query<Products>(query);
                return result;
            }
        }

        public IEnumerable<ProductDetailViewModel> GetAllDetail()
        {
            var query = "SELECT p.productid , p.category , p.productname , sizetype , color , stock  from products p INNER JOIN size s ON s.productid = p.productid INNER JOIN stockcolor sc ON sc.sizeid = s.sizeid ";
            using (SqlConnection connection = new SqlConnection(source.connectcloud))
            {
                return connection.Query<ProductDetailViewModel>(query);
            }
        }

        public IEnumerable<ProductHomeViewModel> GetTop5Products()
        {
            var query = "SELECT TOP 5 o.ProductID, p.ProductName,p.UnitPrice, SUM(Quantity) AS Sum " +
                "FROM OrderDetail o " +
                "INNER JOIN Products p ON p.ProductID = o.ProductID " +
                "GROUP BY o.ProductID, p.ProductName, p.UnitPrice ";
            using (SqlConnection connection = new SqlConnection(source.connectcloud))
            {
                var result = connection.Query<ProductHomeViewModel>(query);
                return result;
            }
        }

        public IEnumerable<Products> OrderByUnitprice()
        {
            using (SqlConnection connection = new SqlConnection(source.connectcloud))
            {
                var result = connection.Query<Products>("SELECT ProductID, ProductName, UnitPrice FROM Products  GROUP BY ProductID, ProductName, UnitPrice ORDER BY UnitPrice");
                return result;
            }
        }

        public IEnumerable<Products> OrderByUnitpriceDESC()  //價格排序:高->低
        {
            using (SqlConnection connection = new SqlConnection(source.connectcloud))
            {
                var result = connection.Query<Products>("SELECT ProductID, ProductName, UnitPrice FROM Products GROUP BY ProductID, ProductName, UnitPrice ORDER BY UnitPrice DESC");
                return result;
            }
        }

        public IEnumerable<Products> OrderByShelfTimeDESC()  //上架時間排序(前十)
        {
            using (SqlConnection connection = new SqlConnection(source.connectcloud))
            {
                var result = connection.Query<Products>("SELECT TOP 8 ProductID, ProductName, ShelfTime FROM Products GROUP BY ProductID, ProductName, ShelfTime ORDER BY ShelfTime DESC");
                return result;
            }
        }

        public IEnumerable<Products> GetTop8Product()  //上架時間排序(前八)
        {
            using (SqlConnection connection = new SqlConnection(source.connectcloud))
            {
                var result = connection.Query<Products>("SELECT TOP 8 ProductName, UnitPrice, Picture FROM Products GROUP BY ProductName, UnitPrice, Picture,ShelfTime ORDER BY ShelfTime DESC");
                return result;
            }
        }

        public string GetProductName(int ProductID)  //查詢訂單、折扣排名(傳入產品ID，傳回產品名稱)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            var sql = "SELECT ProductName FROM Products WHERE ProductID=@productid";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@productid", ProductID);
            connection.Open();

            var reader = command.ExecuteReader();
            string result = "";

            while (reader.Read())
            {
                result = reader.GetValue(0).ToString();
            }

            reader.Close();
            connection.Close();
            return result;
        }

        public IEnumerable<Products> _GetAll()
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            var sql = "SELECT * FROM Products";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            var list = new List<Products>();
            Products products = new Products();

            while (reader.Read())
            {
                products = DbReaderModelBinder<Products>.Bind(reader);
                list.Add(products);
            }

            reader.Close();
            connection.Close();
            return list;

        }

        /// <summary>
        /// 搜尋產品功能
        /// </summary>
        /// <param name="name"></param>
        public IEnumerable<Products> SearchProductsByName(string name)
        {
            var query = "SELECT p.ProductID, (SELECT Category FROM Products WHERE ProductID = p.ProductID) AS Category,(SELECT ProductName FROM Products WHERE ProductID = p.ProductID AND ProductName LIKE '%@ProductName%') AS ProductName, (SELECT UnitPrice FROM Products WHERE ProductID = p.ProductID) AS UnitPrice,(SELECT ShelfTime FROM Products WHERE ProductID = p.ProductID) AS ShelfTime,(SELECT TOP 1 Discount FROM Discounts WHERE ProductID = p.ProductID AND EndTime >= GETDATE() ORDER BY StartTime DESC) AS Discount FROM Products p LEFT JOIN Discounts d ON d.ProductID = p.ProductID GROUP BY p.ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductName", name);
            using (SqlConnection connection = new SqlConnection(source.connectcloud))
            {
                return connection.Query<Products>(query, parameters);
            }
        }

        public IEnumerable<ProductsViewModel> GetAllProductsDetail()
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            return connection.Query<ProductsViewModel>("SELECT * FROM Products p INNER JOIN Size s ON p.ProductID = s.ProductID INNER JOIN StockColor sk ON sk.SizeID = s.SizeID ");
        }

        //更改產品名稱
        public bool UpdateProductName(int ProductId, string ProductName)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            connection.Execute("Update Products SET ProductName = @productname Where ProductID = @ProductId ", new
            {
                ProductId,
                ProductName
            });
            var result = connection.Query("SELECT ProductName = @ProductName From Products Where ProductID = @ProductId ", new
            {
                ProductName,
                ProductId
            });
            if (result.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //更改產品種類
        public bool UpdateProductCategory(string Category, int ProductID)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            connection.Execute("Update Products SET Category = @Category Where ProductID = @ProductId ", new
            {
                Category,
                ProductID
            });
            var result = connection.Query("SELECT ProductName = @ Category From Products Where ProductID = @ProductId ", new
            {
                Category,
                ProductID
            });
            if (result.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //更改產品Size
        public bool UpdateProductSizeBySizeID(string SizeType, int SizeID)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            connection.Execute("Update Size Set SizeType = @SizeType Where SizeID = @SizeID ", new
            {
                SizeID,
                SizeType
            });

            var result = connection.Query("SELECT SizeType = @ SizeType From Size Where SizeID = @SizeID ", new
            {
                SizeID,
                SizeType
            });
            if (result.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //更改產品顏色
        public bool UpdateProductColorByColorID(int ColorID, string Color)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            connection.Execute("Update StockColor Set Color = @Color Where ColorID = @ColorID ", new
            {
                ColorID,
                Color
            });
            var result = connection.Query("SELECT Color = @Color From StockColor Where ColorID = @ColorID ", new
            {
                ColorID,
                Color
            });
            if (result.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //更改產品庫存
        public bool UpdateProductStockByColorID(int ColorID, int Stock)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            connection.Execute("Update StockColor Set Stock = @Stock Where ColorID = @ColorID ", new
            {
                ColorID,
                Stock
            });

            var result = connection.Query("SELECT Stock = @Stock From StockColor Where ColorID = @ColorID ", new
            {
                ColorID,
                Stock
            });
            if (result.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //新增產品 , 回傳產品ID
        public int CreateProductDetail(Products model)
        {
            var ShelfTime = DateTime.Now.ToShortDateString();
            SqlConnection connection = new SqlConnection(source.connectcloud);
            connection.Execute("Insert Into Products(Category , ProductName , UnitPrice , ShelfTime , Picture) Values (@Category,@ProductName,@UnitPrice,@ShelfTime,@Picture)", new
            {
                model.Category,
                model.ProductName,
                model.UnitPrice,
                ShelfTime,
                model.Picture
            });

            var result = connection.Query<int>("SELECT ProductID From Products Where ProductName = @ProductName and ShelfTime = @ShelfTime", new
            {
                model.ProductName,
                ShelfTime
            });



            foreach (var item in result)
            {
                return item;
            }

            var no = 0;
            return no;
        }

        //新增Size , 回傳 sizeID
        public int CreateProductSize(Size model)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            connection.Execute("INSERT INTO Size(ProductID , SizeType) Values(@ProductID , @SizeType)", new
            {
                model.ProductID,
                model.SizeType
            });
            var result = connection.Query<int>("SELECT SizeID From Size Where ProductID = @ProductID  and SizeType = @SizeType", new
            {
                model.ProductID,
                model.SizeType
            });

            foreach (var item in result)
            {
                return (int)item;
            }

            var no = 0;
            return no;
        }

        //新增顏色、存貨
        public bool CreateStockColor(StockColor model)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            connection.Execute("INSERT INTO StockColor(SizeID , Color , Stock) Values(@SizeID , @Color , @Stock)", new {
                model.SizeID,
                model.Color,
                model.Stock
            });

            var result = connection.Query("SELECT SizeID ,Color ,Stock From StockColor Where SizeID = @SizeID  and Color = @Color and Stock = @Stock ", new
            {
                model.SizeID,
                model.Color,
                model.Stock
            });
            if (result.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Products> GetProductsTable()
        {
            var sql = "SELECT * FROM Products";
            using (SqlConnection connection = new SqlConnection(source.connectcloud))
            {
                return connection.Query<Products>(sql);
            }
        }



        public IEnumerable<ProductDetailViewModel> GetProductDetailByProdycuID(int ProductID)
        {
            using (SqlConnection connection = new SqlConnection(source.connectcloud))
            {
                return connection.Query<ProductDetailViewModel>("select sc.ColorID , s.SizeID ,UnitPrice , productName , category ,SizeType , Stock , Color from products p INNER JOIN size s ON p.productID = s.PRoductID INNER JOIN StockColor sc on s.sizeID = sc.sizeID where p.ProductID = @ProductID", new
                {
                    ProductID
                });
            }

        }

        public void UpdateProductInfoByProductID_SizeID_ColorID(List<ProductDetailViewModel> model)
        {
            using (SqlConnection connection = new SqlConnection(source.connectcloud))
            {
                //更新產品資料表Products
                connection.Query<ProductDetailViewModel>("Update Products SET Category = @Category , ProductName = @ProductName , UnitPrice = @UnitPrice Where ProductID = @ProductID", new
                {
                    model[0].Category,
                    model[0].ProductName,
                    model[0].UnitPrice,
                    model[0].ProductID
                });
                foreach (var item in model)
                {
                    //更新Size資料表
                    connection.Query<ProductDetailViewModel>("Update Size SET SizeType = @SizeType  where SizeID = @SizeID", new
                    {
                        item.SizeType,
                        item.SizeID
                    });
                    //更新StockColor資料表
                    connection.Query<ProductDetailViewModel>("Update StockColor SET Color = @Color , Stock = @Stock  where ColorID = @ColorID ", new
                    {
                        item.Color , 
                        item.Stock ,
                        item.ColorID
                    });

                }

            }
        }

        public void UploadImageUrlToDatabase(string url)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            connection.Execute("INSERT INTO picture(picture , colorID) Values(@picture , @colorID)", new
            {

            });
        }
            

    }
}
