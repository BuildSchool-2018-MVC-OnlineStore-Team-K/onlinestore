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

namespace BuildSchool.MVCSolution.OnlineStore.Repository
{
    public class ProductsRepository
    {
        private string connect = "Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;";
        //
        public void Create(Products model)
        {
            //using (SqlConnection connection = new SqlConnection(connect))
            //{
            //    var exec = connection.Execute("INSERT INTO Products VALUES (@productid, @category, @productname, @unitprice,@shelftime)");
            //}            
            SqlConnection connection = new SqlConnection(connect);
            var sql = "INSERT INTO Products VALUES (@productid, @category, @productname, @unitprice,@shelftime)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productid", model.ProductID);
            command.Parameters.AddWithValue("@category", model.Category);
            command.Parameters.AddWithValue("@productname", model.ProductName);
            command.Parameters.AddWithValue("@unitprice", model.UnitPrice);
            command.Parameters.AddWithValue("@shelftime", model.ShelfTime);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Products model)
        {
            //using (SqlConnection connection = new SqlConnection(connect))
            //{
            //    var exec = connection.Execute("UPDATE Products SET Category=@category, ProductName=@productname, UnitPrice=@unitprice, ShelfTime=@shelftime WHERE ProductID = @productid");
            //}
            SqlConnection connection = new SqlConnection(connect);
            var sql = "UPDATE Products SET Category=@category, ProductName=@productname, UnitPrice=@unitprice, ShelfTime=@shelftime WHERE ProductID = @productid";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productid", model.ProductID);
            command.Parameters.AddWithValue("@category", model.Category);
            command.Parameters.AddWithValue("@productname", model.ProductName);
            command.Parameters.AddWithValue("@unitprice", model.UnitPrice);
            command.Parameters.AddWithValue("@shelftime", model.ShelfTime);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Products model)
        {
            //using (SqlConnection connection = new SqlConnection(connect))
            //{
            //    var exec = connection.Execute("DELETE FROM Products WHERE ProductID = @productid");
            //}  
            SqlConnection connection = new SqlConnection(connect);
            var sql = "Delete FROM Products WHERE ProductID=@productID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productID", model.ProductID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public IEnumerable<Products> FindById(int ProductID)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                var result = connection.Query<Products>("SELECT * FROM Products Where ProductID = @productid");
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

        public IEnumerable<Products> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                var result = connection.Query<Products>("SELECT * FROM Products");
                return result;
            }            
        }
       
        public IEnumerable<Products> OrderByUnitprice()  //價格排序:低->高
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                var result = connection.Query<Products>("SELECT ProductID, ProductName, UnitPrice FROM Products GROUP BY ProductID, ProductName, UnitPrice ORDER BY UnitPrice");
                return result;
            }            
        }

        public IEnumerable<Products> OrderByUnitpriceDESC()  //價格排序:高->低
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                var result = connection.Query<Products>("SELECT ProductID, ProductName, UnitPrice FROM Products GROUP BY ProductID, ProductName, UnitPrice ORDER BY UnitPrice DESC");
                return result;
            }           
        }

        public IEnumerable<Products> OrderByShelfTimeDESC()  //上架時間排序(前十)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                var result = connection.Query<Products>("SELECT TOP 10 ProductID, ProductName, ShelfTime FROM Products GROUP BY ProductID, ProductName, ShelfTime ORDER BY ShelfTime DESC");
                return result;
            }           
        }


        public string GetProductName(int ProductID)  //查詢訂單、折扣排名(傳入產品ID，傳回產品名稱)
        {
            //using (SqlConnection connection = new SqlConnection(connect))
            //{ 
            //    var result = connection.Query<Products>("SELECT ProductName FROM Products WHERE ProductID=@productid Group By ColorID").ToString();
            SqlConnection connection = new SqlConnection(connect);
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
            SqlConnection connection = new SqlConnection(
                "Server=192.168.40.38,1433;Database=E-Commerce;User ID =smallhandsomehandsome; Password =123;");
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

    }
}
