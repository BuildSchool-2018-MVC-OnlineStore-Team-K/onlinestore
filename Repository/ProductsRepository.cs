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
        public void Create(Products model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;");
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
            SqlConnection connection = new SqlConnection(
                "Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;");
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
            SqlConnection connection = new SqlConnection(
                "Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;");
            var sql = "DELETE FROM Products WHERE ProductID = @productid";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productid", model.ProductID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public Products FindById(int ProductID)
        {
            SqlConnection connection = new SqlConnection(
                "data source = 192.168.40.36,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "SELECT * FROM Products WHERE ProductID = @productid";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@productid", ProductID);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var products = new Products();

            while (reader.Read())
            {
                products.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));
                products.Category = reader.GetValue(reader.GetOrdinal("Category")).ToString();
                products.ProductName = reader.GetValue(reader.GetOrdinal("ProductName")).ToString();
                products.UnitPrice = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitPrice")));
                products.ShelfTime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("ShelfTime")));
            }

            reader.Close();
            connection.Close();
            return products;
        }

        public IEnumerable<Products> _GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome; Password =123;");
            var result = connection.Query<Products>("SELECT * FROM Products");
            return result;
        }

        public IEnumerable<Products> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=.;Database=E-Commerce;integrated security=true");
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
                //            reader.GetValue(i));
                //    //var product = new Products();
                //    //product.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));  //用欄位名稱取得位址
                //    //product.Category = reader.GetValue(reader.GetOrdinal("Category")).ToString();
                //    //product.ProductName = reader.GetValue(reader.GetOrdinal("ProductName")).ToString();
                //    //product.UnitPrice = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitPrice")));
                //    //product.ShelfTime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("ShelfTime")));
                //    //products.Add(product);
                //}
            }
            
            reader.Close();
            connection.Close();
            return list;

        } 
        
        public IEnumerable<Products> OrderByUnitprice()  //價格排序:低->高
        {
            SqlConnection connection = new SqlConnection(
                "Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome; Password =123;");
            var sql = "SELECT ProductID, ProductName, UnitPrice FROM Products GROUP BY ProductID, ProductName, UnitPrice ORDER BY UnitPrice";

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

        public IEnumerable<Products> OrderByUnitpriceDESC()  //價格排序:高->低
        {
            SqlConnection connection = new SqlConnection(
                "Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome; Password =123;");
            var sql = "SELECT ProductID, ProductName, UnitPrice FROM Products GROUP BY ProductID, ProductName, UnitPrice ORDER BY UnitPrice DESC";

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
            }

            reader.Close();
            connection.Close();
            return list;
        }

        public IEnumerable<Products> OrderByShelfTimeDESC()  //上架時間排序(前十)
        {
            SqlConnection connection = new SqlConnection(
                "Server=.;Database=E-Commerce;integrated security=true");
            var sql = "SELECT TOP 10 ProductID, ProductName, ShelfTime FROM Products GROUP BY ProductID, ProductName, ShelfTime ORDER BY ShelfTime DESC";

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

        public string GetProductName(int ProductID)  //查詢訂單、折扣排名(傳入產品ID，傳回產品名稱)
        {
            SqlConnection connection = new SqlConnection(
                "Server=.;Database=E-Commerce;integrated security=true");
            var sql = "SELECT ProductName FROM Products WHERE ProductID=@productid";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@productid", ProductID);
            connection.Open();

            var reader = command.ExecuteReader();
            string result = "";
            //Products products = new Products();

            while (reader.Read())
            {
                result=reader.GetValue(0).ToString();                
            }

            reader.Close();
            connection.Close();
            return result;
        }

        //public IEnumerable<Products> OrderByQuantityDESC(int ProductID,int TotalQuantiy)  //價格排序:高->低
        //{
        //    SqlConnection connection = new SqlConnection(
        //        "Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome; Password =123;");
        //    var sql = "SELECT ProductID, ProductName FROM Products GROUP BY ProductID, ProductName ORDER BY UnitPrice DESC";

        //    SqlCommand command = new SqlCommand(sql, connection);
        //    command.Parameters.AddWithValue("@productid", ProductID);
        //    connection.Open();

        //    var reader = command.ExecuteReader();
        //    var list = new List<Products>();
        //    //var properties = typeof(Products).GetProperties();
        //    Products products = new Products();

        //    while (reader.Read())
        //    {
        //        products = DbReaderModelBinder<Products>.Bind(reader);
        //        list.Add(products);
        //    }

        //    reader.Close();
        //    connection.Close();
        //    return list;
        //}
    }
}
