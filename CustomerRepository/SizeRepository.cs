using BuildSchool.MVCSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.CustomerRepository
{
    public class SizeRepository
    {
        public void Create(Sizes model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=northwind; integrated security=true");
            var sql = "INSERT INTO Customers VALUES (@SizeID, @Size)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", model.SizeID);
            command.Parameters.AddWithValue("@Size", model.Size);
            

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Sizes model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=northwind; integrated security=true");
            var sql = "UPDATE Customers SET Size=@Size WHERE SizeID = @SizeID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", model.SizeID);
            command.Parameters.AddWithValue("@Size", model.Size);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Sizes model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=northwind; integrated security=true");
            var sql = "DELETE FROM Sizes WHERE SizeID = @SizeID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", model.SizeID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Sizes FindById(string SizeID)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=northwind; integrated security=true");
            var sql = "SELECT * FROM Sizes WHERE SizeID = @SizeID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SizeID", SizeID);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var size = new Sizes();

            while (reader.Read())
            {
                size.SizeID = int.Parse(reader.GetValue(reader.GetOrdinal("SizeID")).ToString());
                size.Size = reader.GetValue(reader.GetOrdinal("Size")).ToString();
                
            }

            reader.Close();

            return size;
        }

        public IEnumerable<Sizes> GetAll() //()內不用給直 因為傳整個表格
        {
            SqlConnection connection = new SqlConnection("Server=.;Database=mytest;Trusted_Connection=True;");

            var sql = "SELECT * FROM  Sizes";
            SqlCommand command = new SqlCommand(sql, connection);

           // command.Parameters.AddWithValue("@sizeID", model.SizeID);

            connection.Open();

            var reader =  command.ExecuteReader();
            var list = new List<Sizes>();
            var sizes = new Sizes();
            while (reader.Read())
            {
                sizes.SizeID = int.Parse(reader.GetValue(reader.GetOrdinal("sizeID")).ToString());
                sizes.Size = reader.GetValue(reader.GetOrdinal("size")).ToString();
                list.Add(sizes);
            }
            reader.Close();
            connection.Close();

            return list;
        }
    }
}
