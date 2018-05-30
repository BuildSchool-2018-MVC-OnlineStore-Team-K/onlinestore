using BuildSchool.MVCSolution.OnlineStore.Models;
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
        public void Create(Products model)
        {
            //using (SqlConnection connection = new SqlConnection(source.connect))
            //{
            //    var exec = connection.Execute("INSERT INTO Products VALUES (@productid, @category, @productname, @unitprice,@shelftime)");
            //}            
            SqlConnection connection = new SqlConnection(source.connect);
            var sql = "INSERT INTO Products VALUES (@productid, @category, @productname, @unitprice,@shelftime,@picture)";
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

        public void Update(Products model)
        {
            //using (SqlConnection connection = new SqlConnection(source.connect))
            //{
            //    var exec = connection.Execute("UPDATE Products SET Category=@category, ProductName=@productname, UnitPrice=@unitprice, ShelfTime=@shelftime WHERE ProductID = @productid");
            //}
            SqlConnection connection = new SqlConnection(source.connect);
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
            //using (SqlConnection connection = new SqlConnection(source.connect))
            //{
            //    var exec = connection.Execute("DELETE FROM Products WHERE ProductID = @productid");
            //}  
            SqlConnection connection = new SqlConnection(source.connect);
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
            using (SqlConnection connection = new SqlConnection(source.connect))
            {
                var result = connection.Query<Products>(query, Parameters);
                return result;
            }
            //"SELECT * FROM Products WHERE ProductID = @productid";

            //SqlCommand command = new SqlCommand(sql, connection);
            //command.Parameters.AddWithValue("@productid", ProductID);

            //connection.Open();

            //var list = new List<Products>();
            //var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //var products = new Products();

            //while (reader.Read())
            //{
            //    products = DbReaderModelBinder<Products>.Bind(reader);
            //    list.Add(products);
            //}

            //reader.Close();
            //connection.Close();
        }

        /// <summary>
        /// Get all products and show on ProductsPage
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Products> GetAll()
        {
            var query = "SELECT p.ProductID, (SELECT Category FROM Products WHERE ProductID = p.ProductID) AS Category,(SELECT ProductName FROM Products WHERE ProductID = p.ProductID) AS ProductName, (SELECT UnitPrice FROM Products WHERE ProductID = p.ProductID) AS UnitPrice,(SELECT ShelfTime FROM Products WHERE ProductID = p.ProductID) AS ShelfTime,(SELECT TOP 1 Discount FROM Discounts WHERE ProductID = p.ProductID AND EndTime >= GETDATE() ORDER BY StartTime DESC) AS Discount FROM Products p LEFT JOIN Discounts d ON d.ProductID = p.ProductID GROUP BY p.ProductID";
            using (SqlConnection connection = new SqlConnection(source.connect))
            {
                var result = connection.Query<Products>(query);
                return result;
            }            
        }

        /// <summary>
        /// 價格排序:低->高
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Products> OrderByUnitprice()
        {
            using (SqlConnection connection = new SqlConnection(source.connect))
            {
                var result = connection.Query<Products>("SELECT ProductID, ProductName, UnitPrice FROM Products GROUP BY ProductID, ProductName, UnitPrice ORDER BY UnitPrice");
                return result;
            }            
        }

        public IEnumerable<Products> OrderByUnitpriceDESC()  //價格排序:高->低
        {
            using (SqlConnection connection = new SqlConnection(source.connect))
            {
                var result = connection.Query<Products>("SELECT ProductID, ProductName, UnitPrice FROM Products GROUP BY ProductID, ProductName, UnitPrice ORDER BY UnitPrice DESC");
                return result;
            }           
        }

        public IEnumerable<Products> OrderByShelfTimeDESC()  //上架時間排序(前十)
        {
            using (SqlConnection connection = new SqlConnection(source.connect))
            {
                var result = connection.Query<Products>("SELECT TOP 8 ProductID, ProductName, ShelfTime FROM Products GROUP BY ProductID, ProductName, ShelfTime ORDER BY ShelfTime DESC");
                return result;
            }           
        }

        public IEnumerable<Products> GetTop8Product()  //上架時間排序(前八)
        {
            using (SqlConnection connection = new SqlConnection(source.connect))
            {
                var result = connection.Query<Products>("SELECT TOP 8 ProductName, UnitPrice, Picture FROM Products GROUP BY ProductName, UnitPrice, Picture,ShelfTime ORDER BY ShelfTime DESC");
                return result;
            }
        }

        public IEnumerable<ProductsViewModel> GetProductDetail(int ProductID)  //產品頁面需要(詳細資料)
        {            
            var query = "SELECT p.ProductID,p.ProductName,p.Category,s.SizeType,cs.Color,cs.Stock FROM Products p INNER JOIN Size s ON p.ProductID = s.ProductID INNER JOIN ColorStock cs ON s.SizeID = cs.SizeID Where ProductID = @ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@productid", ProductID);
            using (SqlConnection connection = new SqlConnection(source.connect))
            {
                return connection.Query<ProductsViewModel>(query, parameters);
            }
        }

        public string GetProductName(int ProductID)  //查詢訂單、折扣排名(傳入產品ID，傳回產品名稱)
        {
            //using (SqlConnection connection = new SqlConnection(source.connect))
            //{ 
            //    var result = connection.Query<Products>("SELECT ProductName FROM Products WHERE ProductID=@productid Group By ColorID").ToString();
            SqlConnection connection = new SqlConnection(source.connect);
            var sql = "SELECT ProductName FROM Products WHERE ProductID=@productid";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@productid", ProductID);
            connection.Open();

            var reader = command.ExecuteReader();
            string result = "";
            //Products products = new Products();

            while (reader.Read())
            {
                result = reader.GetValue(0).ToString();
            }

            reader.Close();
            connection.Close();
            return result;
            //}
        }       

        public IEnumerable<Products> _GetAll()
        {
            SqlConnection connection = new SqlConnection(source.connect);
            var sql = "SELECT * FROM Products";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            var list = new List<Products>();
            //var properties = typeof(Products).GetProperties();
            Products products = new Products();

            while (reader.Read())
            {
                products = DbReaderModelBinder<Products>.Bind(reader);
                list.Add(products);
                //products = new Products();
                //for (var i = 0; i < reader.FieldCount; i++)
                //{
                //    var fieldName = reader.GetName(i);
                //    var property = properties.FirstOrDefault(
                //        p => p.Name == fieldName);

                //    if (property == null)
                //        continue;

                //    if (!reader.IsDBNull(i))
                //        property.SetValue(products,
                //reader.GetValue(i));
                //var product = new Products();
                //product.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));  //用欄位名稱取得位址
                //product.Category = reader.GetValue(reader.GetOrdinal("Category")).ToString();
                //product.ProductName = reader.GetValue(reader.GetOrdinal("ProductName")).ToString();
                //product.UnitPrice = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitPrice")));
                //product.ShelfTime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("ShelfTime")));
                //products.Add(product);
                //}
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
            using(SqlConnection connection = new SqlConnection(source.connect))
            {
                return connection.Query<Products>(query, parameters);
            }
        }

        public IEnumerable<ProductsViewModel> GetAllProductsDetail()
        {
            SqlConnection connection = new SqlConnection(source.connect);
            return connection.Query<ProductsViewModel>("SELECT * FROM Products p INNER JOIN Size s ON p.ProductID = s.ProductID INNER JOIN StockColor sk ON sk.SizeID = s.SizeID ");
        }

        public bool UpdateProductName(int ProductId , string ProductName)
        {
            SqlConnection connection = new SqlConnection(source.connect);
            connection.Execute("Update Products SET ProductName = @productname Where ProductID = @ProductId ", new
            {
                ProductId,
                ProductName
            });
            var result =connection.Query("SELECT ProductName = @ProductName From Products Where ProductID = @ProductId ", new
            {
                ProductName,
                ProductId
            });
            if(result.Count()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

        public bool UpdateProductCategory(string Category , int ProductID)
        {
            SqlConnection connection = new SqlConnection(source.connect);
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

        public bool UpdateProductSizeBySizeID(string SizeType , int SizeID)
        {
            SqlConnection connection = new SqlConnection(source.connect);
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

        public bool UpdateProductColorByColorID(int ColorID , string Color)
        {
            SqlConnection connection = new SqlConnection(source.connect);
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

        public bool UpdateProductStockByColorID(int ColorID, int Stock)
        {
            SqlConnection connection = new SqlConnection(source.connect);
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

    }
}
