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
        MyConnectionString source = new MyConnectionString();

        public IEnumerable<StockColor> GetStockColorTable(int ProductID)
        {
            var sql = "SELECT * FROM StockColor WHERE SizeID = (SELECT SizeID FROM Size WHERE ProductID = @ProductID)";
            var parameters = new DynamicParameters();
            parameters.Add("ProductID", ProductID);
            using(SqlConnection connection = new SqlConnection(source.connect))
            {
                return connection.Query<StockColor>(sql, parameters);
            }
        }
        
        public void Create(StockColor model)
        {
            SqlConnection connection = new SqlConnection(source.connect);
            var sql = "INSERT INTO StockColor VALUES (@colorid, @sizeid,@color,@stock)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@colorid", model.ColorID);
            command.Parameters.AddWithValue("@sizeid", model.SizeID);
            command.Parameters.AddWithValue("@color", model.Color);
            command.Parameters.AddWithValue("@stock", model.Stock);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();            
        }

        public void Update(StockColor model)
        {           
            SqlConnection connection = new SqlConnection(source.connect);
            var sql = "UPDATE StockColor SET ColorID = @colorid, SizeID=@sizeid, Color=@color,Stock=@stock";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@colorid", model.ColorID);
            command.Parameters.AddWithValue("@sizeid", model.SizeID);
            command.Parameters.AddWithValue("@color", model.Color);
            command.Parameters.AddWithValue("@stock", model.Stock);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(StockColor model)
        {
            SqlConnection connection = new SqlConnection(source.connect);
            var sql = "Delete FROM Products WHERE ColorID = @colorid";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@colorid", model.ColorID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<StockColor> FindById(int ProductID)
        {
            using (SqlConnection connection = new SqlConnection(source.connect))
            {
                var result = connection.Query<StockColor>("SELECT * FROM StockColor WHERE ColorID = @colorid");
                return result;
            }
            
        }

        public IEnumerable<StockColor> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(source.connect))
            {
                var result = connection.Query<StockColor>("SELECT * FROM StockColor");
                return result;
            }
        }

        public int GetSizeColorStock(int ColorID)  //依產品尺寸、顏色查詢庫存
        {            
                SqlConnection connection = new SqlConnection(source.connect);
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
