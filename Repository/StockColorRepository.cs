using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.MVCSolution.OnlineStore.Models;
using Dapper;

namespace BuildSchool.MVCSolution.OnlineStore.Repository
{
    public class StockColorRepository
    {
        private string connect = "Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;";
        //
        public void Create(StockColor model)
        {
            SqlConnection connection = new SqlConnection(connect);
            var sql = "INSERT INTO StockColor VALUES (@colorid, @sizeid,@color,@stock)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productid", model.ColorID);
            command.Parameters.AddWithValue("@category", model.SizeID);
            command.Parameters.AddWithValue("@productname", model.Color);
            command.Parameters.AddWithValue("@unitprice", model.Stock);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();            
        }

        public void Update(StockColor model)
        {           
            SqlConnection connection = new SqlConnection(connect);
            var sql = "UPDATE StockColor SET ColorID = @colorid, SizeID=@sizeid, Color=@color,Stock=@stock";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productid", model.ColorID);
            command.Parameters.AddWithValue("@category", model.SizeID);
            command.Parameters.AddWithValue("@productname", model.Color);
            command.Parameters.AddWithValue("@unitprice", model.Stock);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(StockColor model)
        {
            SqlConnection connection = new SqlConnection(connect);
            var sql = "Delete FROM Products WHERE StockColorID=@stockColorID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@stockColorID", model.ColorID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<StockColor> FindById(int ProductID)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                var result = connection.Query<StockColor>("SELECT * FROM StockColor WHERE ColorID = @colorid");
                return result;
            }
            
        }

        public IEnumerable<StockColor> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                var result = connection.Query<StockColor>("SELECT * FROM StockColor");
                return result;
            }
        }

        public int GetSizeColorStock(int ColorID)  //依產品尺寸、顏色查詢庫存
        {            
                SqlConnection connection = new SqlConnection(connect);
                var sql = "SELECT Stock FROM StockColor WHERE ColorID = @colorid";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@colorid", ColorID);
                connection.Open();

                var reader = command.ExecuteReader();
                int result = 0;
                //Products products = new Products();

                while (reader.Read())
                {
                    result = Convert.ToInt32(reader.GetValue(0));
                }

                reader.Close();
                connection.Close();
                return result;            
        }
    }
}
