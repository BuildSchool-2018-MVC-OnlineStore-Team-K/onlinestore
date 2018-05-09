using BuildSchool.MVCSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
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
            SqlConnection connection = new SqlConnection("Server=.;Database=myDataBase;Trusted_Connection=True;");

            var sql = "INSERT INTO Orders(@SizeID , Size) Values(@sizeid , @size)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@sizeid", model.SizeID);
            command.Parameters.AddWithValue("@size", model.Size);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }



        public void Update(Sizes model)
        {
            SqlConnection connection = new SqlConnection("Server=.;Database=myDataBase;Trusted_Connection=True;");

            var sql = "UPDATE Orders(@SizeID , Size) SET(SizeID = @sizeid , Size = @size)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@sizeid", model.SizeID);
            command.Parameters.AddWithValue("@size", model.Size);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }


        public void Delete(Sizes model)
        {

            SqlConnection connection = new SqlConnection("Server=.;Database=myDataBase;Trusted_Connection=True;");

            var sql = "UPDATE Orders(@SizeID , Size) SET(SizeID = @sizeid , Size = @size)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@sizeid", model.SizeID);
            command.Parameters.AddWithValue("@size", model.Size);


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
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
