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
    public class SizeRepository
    {
        private string connect = "Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;";
        public void Create(Size model)
        {
            SqlConnection connection = new SqlConnection(connect);

            var sql = "INSERT INTO Size VALUES (@SizeID, @ProductID, @SizeType)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", model.SizeID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@SizeType", model.SizeType);


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Size model)
        {
            SqlConnection connection = new SqlConnection(connect);

            var sql = "UPDATE Size SET SizeType= @SizeType WHERE SizeID = @SizeID AND ProductID = @ProductID ";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", model.SizeID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@SizeType", model.SizeType);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Size model)
        {
            SqlConnection connection = new SqlConnection(connect);

            var sql = "DELETE FROM Size WHERE SizeID = @SizeID AND ProductID = @ProductID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", model.SizeID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Size FindById(string SizeID, string ProductID)
        {
            SqlConnection connection = new SqlConnection(connect);

            var sql = "SELECT * FROM Size WHERE SizeID = @SizeID AND ProductID = @ProductID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", SizeID);
            command.Parameters.AddWithValue("@ProductID", ProductID);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var ps = new Size();

            while (reader.Read())
            {
                ps.SizeID = int.Parse(reader.GetValue(reader.GetOrdinal("SizeID")).ToString());
                ps.ProductID = int.Parse(reader.GetValue(reader.GetOrdinal("ProductID")).ToString());
                ps.SizeType = reader.GetValue(reader.GetOrdinal("SizeType")).ToString();

            }

            reader.Close();

            return ps;
        }

        public IEnumerable<Size> GetAll() //()內不用給直 因為傳整個表格
        {
            SqlConnection connection = new SqlConnection(connect);

            var sql = "SELECT * FROM  Size";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            var reader = command.ExecuteReader();
            var list = new List<Size>();
            var ps = new Size();
            while (reader.Read())
            {
                ps.SizeID = int.Parse(reader.GetValue(reader.GetOrdinal("SizeID")).ToString());
                ps.ProductID = int.Parse(reader.GetValue(reader.GetOrdinal("ProductID")).ToString());
                ps.SizeType = reader.GetValue(reader.GetOrdinal("SizeType")).ToString();
                list.Add(ps);
            }
            reader.Close();
            connection.Close();

            return list;
        }

        //擴充套件Dapper
        public IEnumerable<Size> PS_GetAllDapper()
        {
            SqlConnection connection = new SqlConnection(connect);
            var result = connection.Query<Size>("SELECT * FROM Size");
            return result;
        }
    }
}