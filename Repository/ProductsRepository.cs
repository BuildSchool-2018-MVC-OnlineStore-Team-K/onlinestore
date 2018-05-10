using BuildSchool.MVCSolution.OnlineStore.Models;
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
              "data source = 192.168.40.36,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "INSERT INTO Products VALUES (@productid, @category, @productname, @unitprice)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productid", model.ProductID);
            command.Parameters.AddWithValue("@category", model.Category);
            command.Parameters.AddWithValue("@productname", model.ProductName);
            command.Parameters.AddWithValue("@unitprice", model.UnitPrice);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Products model)
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.40.36,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "UPDATE Products SET Category=@category, ProductName=@productname, UnitPrice=@unitprice WHERE ProductID = @productid";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productid", model.ProductID);
            command.Parameters.AddWithValue("@category", model.Category);
            command.Parameters.AddWithValue("@productname", model.ProductName);
            command.Parameters.AddWithValue("@unitprice", model.UnitPrice);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Products model)
        {
            SqlConnection connection = new SqlConnection(
              "data source = 192.168.40.36,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
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
            var product = new Products();

            while (reader.Read())
            {
                product.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));
                product.Category = reader.GetValue(reader.GetOrdinal("Category")).ToString();
                product.ProductName = reader.GetValue(reader.GetOrdinal("ProductName")).ToString();
                product.UnitPrice = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitPrice")));                
            }

            reader.Close();

            return product;
        }

        public IEnumerable<Products> GetAll()
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.40.36,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "SELECT * FROM Products";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var products = new List<Products>();

            while (reader.Read())
            {
                var product = new Products();
                product.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));  //用欄位名稱取得位址
                product.Category = reader.GetValue(reader.GetOrdinal("Category")).ToString();
                product.ProductName = reader.GetValue(reader.GetOrdinal("ProductName")).ToString();
                product.UnitPrice = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitPrice")));
                products.Add(product);
            }

            reader.Close();

            return products;

        }

        //public void ChangeProductName(int productsid,string productname)
        //{
        //    using (var connection = new SqlConnection(  //using會自動呼叫Dispose()方法，且連線未關會自動關，但連結無法連續使用
        //        "data source=192.168.40.36,1433;user id=smallhandsomehandsome;password=123; database=E-Commerce; integrated security=true"))
        //    {
        //        var command = connection.CreateCommand();
        //        //command.CommandText ="UPDATE SET"
        //        //command.Parameters.AddWithValue("@productid", model.ProductID);           
        //        //command.Parameters.AddWithValue("@productname", model.ProductName);
        //    }
        //}
    }
}

//SQL帶字串不要使用字串連結(ex.UserName="'+username+'")，否則可能被盜，在不知情的狀況下被新增帳號，資料被刪除，windows被刪除....(因為不知道使用者會輸入什麼，若剛好是某些指令可能會出問題)
//最好防禦方式:使用參數物件
//實質型別不可為null
