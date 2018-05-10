using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BuildSchool.MVCSolution.OnlineStore.Models;

namespace BuildSchool.MVCSolution.OnlineStore.Repository
{
    public class DiscountRepository
    {
        public void Create(Discounts model)
        {
            SqlConnection connection = new SqlConnection(
                "data source = 192.168.40.36,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "INSERT INTO Discounts VALUES (@did, @pid, @discount, @start, @end";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@did", model.DiscountID);
            command.Parameters.AddWithValue("@pid", model.ProductID);
            command.Parameters.AddWithValue("@discount", model.Discount);
            command.Parameters.AddWithValue("@start", model.StartTime);
            command.Parameters.AddWithValue("@end", model.EndTime);

            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }

        public void Update(Discounts model)
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.40.36,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "UPDATE Discounts SET Discount = @discount, StartTime = @start, EndTime = @end WHERE DiscountID = @did";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@did", model.DiscountID);
            //command.Parameters.AddWithValue("@pid", model.ProductID);
            command.Parameters.AddWithValue("@discount", model.Discount);
            command.Parameters.AddWithValue("@start", model.StartTime);
            command.Parameters.AddWithValue("@end", model.EndTime);

            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }

        public void Delete(Discounts model)
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.40.36,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "DELETE FROM Discounts WHERE DiscountID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", model.DiscountID);

            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }

        public Discounts FindById(string discountId)
        {
            SqlConnection connection = new SqlConnection(
                "data source = 192.168.40.36,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "SELECT * FROM Discounts WHERE DiscountID = @did";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", discountId);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var discount = new Discounts();

            while (reader.Read())
            {
                discount.DiscountID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("DiscountID")));
                discount.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));
                discount.Discount = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("Discount")));
                discount.StartTime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("StartTime")));
                discount.EndTime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("EndTime")));
            }

            reader.Close();

            return discount;
        }

        public IEnumerable<Discounts> GetAll()
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.40.36,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "SELECT * FROM Discounts";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var discounts = new List<Discounts>();

            while (reader.Read())
            {
                var discount = new Discounts();
                discount.DiscountID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("DiscountID")));
                discount.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));
                discount.Discount = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("Discount")));
                discount.StartTime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("StartTime")));
                discount.EndTime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("EndTime")));
                discounts.Add(discount);
            }

            reader.Close();

            return discounts;
        }
    }
}
//data source, database, user id, password

//ExecuteScalar:取純量值(一筆)
//ExecuteReader:Cursor(一去不復返)
//GetOrdinal:使用欄位來抓值(ExecuteReader)

//單元測試：新增專案
//using陳述式，用來防止忘記關資料庫，用來宣告多個物件
//IDisaposable