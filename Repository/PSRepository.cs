using BuildSchool.MVCSolution.OnlineStore.Models;
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
    public class PSRepository
    {
        public void Create(PS model)
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.40.38,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "INSERT INTO PS VALUES (@SizeID, @ProductID, @Quantity)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", model.SizeID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(PS model)
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.40.38,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "UPDATE PS SET Quantity= @Quantity WHERE SizeID = @SizeID AND ProductID = @ProductID ";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", model.SizeID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(PS model)
        {
            SqlConnection connection = new SqlConnection(
              "data source = 192.168.40.38,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "DELETE FROM PS WHERE SizeID = @SizeID AND ProductID = @ProductID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", model.SizeID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public PS FindById(string SizeID, string ProductID)
        {
            SqlConnection connection = new SqlConnection(
                 "data source = 192.168.40.38,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "SELECT * FROM PS WHERE SizeID = @SizeID AND ProductID = @ProductID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", SizeID);
            command.Parameters.AddWithValue("@ProductID", ProductID);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var ps = new PS();

            while (reader.Read())
            {
                ps.SizeID = int.Parse(reader.GetValue(reader.GetOrdinal("SizeID")).ToString());
                ps.ProductID = int.Parse(reader.GetValue(reader.GetOrdinal("ProductID")).ToString());
                ps.Quantity = int.Parse(reader.GetValue(reader.GetOrdinal("Quantity")).ToString());

            }

            reader.Close();

            return ps;
        }

        public IEnumerable<PS> GetAll() //()內不用給直 因為傳整個表格
        {
            SqlConnection connection = new SqlConnection(
              "data source = 192.168.40.38,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "SELECT * FROM  PS";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            var reader = command.ExecuteReader();
            var list = new List<PS>();
            var ps = new PS();
            while (reader.Read())
            {
                ps.SizeID = int.Parse(reader.GetValue(reader.GetOrdinal("SizeID")).ToString());
                ps.ProductID = int.Parse(reader.GetValue(reader.GetOrdinal("ProductID")).ToString());
                ps.Quantity = int.Parse(reader.GetValue(reader.GetOrdinal("Quantity")).ToString());
                list.Add(ps);
            }
            reader.Close();
            connection.Close();

            return list;
        }

        //擴充套件Dapper
        public IEnumerable<PS> PS_GetAllDapper()
        {
            SqlConnection connection = new SqlConnection(
                "data source = 192.168.40.38,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var result = connection.Query<PS>("SELECT * FROM PS");
            return result;
        }
    }
}