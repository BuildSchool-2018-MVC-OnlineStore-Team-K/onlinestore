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
        public void Create(Size model)
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.40.38,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "INSERT INTO Customers VALUES (@SizeID, @Size)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", model.SizeID);
            command.Parameters.AddWithValue("@Size", model._Size);
            

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Size model)
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.40.38,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "UPDATE Customers SET Size=@Size WHERE SizeID = @SizeID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", model.SizeID);
            command.Parameters.AddWithValue("@Size", model._Size);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Size model)
        {
            SqlConnection connection = new SqlConnection(
              "data source = 192.168.40.38,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "DELETE FROM Sizes WHERE SizeID = @SizeID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", model.SizeID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Size FindById(string SizeID)
        {
            SqlConnection connection = new SqlConnection(
              "data source = 192.168.40.38,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "SELECT * FROM Sizes WHERE SizeID = @SizeID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", SizeID);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var size = new Size();

            while (reader.Read())
            {
                size.SizeID = int.Parse(reader.GetValue(reader.GetOrdinal("SizeID")).ToString());
                size._Size = reader.GetValue(reader.GetOrdinal("Size")).ToString();
                
            }

            reader.Close();

            return size;
        }

        public IEnumerable<Size> GetAll() //()內不用給直 因為傳整個表格
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.40.38,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "SELECT * FROM  Size";
            SqlCommand command = new SqlCommand(sql, connection);

           // command.Parameters.AddWithValue("@sizeID", model.SizeID);

            connection.Open();

            var reader =  command.ExecuteReader();
            var list = new List<Size>();
            var sizes = new Size();
            while (reader.Read())
            {
                sizes.SizeID = int.Parse(reader.GetValue(reader.GetOrdinal("SizeID")).ToString());
                sizes._Size = reader.GetValue(reader.GetOrdinal("Size")).ToString();
                list.Add(sizes);
            }
            reader.Close();
            connection.Close();

            return list;
        }

        //擴充套件Dapper
        public IEnumerable<Size> Size_GetAllDapper()
        {
            SqlConnection connection = new SqlConnection(
                "data source = 192.168.40.38,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var result = connection.Query<Size>("SELECT * FROM Size");
            return result;
        }
    }
}
