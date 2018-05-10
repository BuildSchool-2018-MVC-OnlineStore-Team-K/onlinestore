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
    public class MembersRepository
    {
        public void Create(Members model)
        {
            SqlConnection connection = new SqlConnection("Server=192.168.40.36,1433;Database=E-Commerce;Trusted_Connection=True; User ID = littlehandsomehandsome ; Password = 123;");
            var sql = "INSERT INTO Members VALUES " +
                "(@MemberID, " +
                "@Name," +
                " @Address," +
                " @Age, " +
                "@CerditCard, " +
                "@Phone," +
                " @Email, " +
                "@Account, " +
                "@Password, " +
                "@Block, " +
                "@Caerre)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);
            command.Parameters.AddWithValue("@MemberName", model.MemberName);
            command.Parameters.AddWithValue("@Address", model.Address);
            command.Parameters.AddWithValue("@Age", model.Age);
            command.Parameters.AddWithValue("@CreditCard", model.CerditCard);
            command.Parameters.AddWithValue("@Phone", model.Phone);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@Account", model.Account);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@Block", model.Block);
            command.Parameters.AddWithValue("@Career", model.Caerre);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Members model)
        {
            SqlConnection connection = new SqlConnection(
               "Server= 192.168.40.36,1433 ; database = E-Commerce; user id = smallhandsomehandsome; password = 123");
            var sql = "UPDATE OrderDetail SET(MemberID=@MemberID, " +
                 "Name=@Name," +
                 "Address=@Address," +
                 " Age=@Age, " +
                 "CerditCard=@CerditCard, " +
                 "Phone=@Phone," +
                 " Email=@Email, " +
                 "Account=@Account, " +
                 "Password=@Password, " +
                 "Block=@Block, " +
                 "Caerre=@Caerre)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);
            command.Parameters.AddWithValue("@MemberName", model.MemberName);
            command.Parameters.AddWithValue("@Address", model.Address);
            command.Parameters.AddWithValue("@Age", model.Age);
            command.Parameters.AddWithValue("@CreditCard", model.CerditCard);
            command.Parameters.AddWithValue("@Phone", model.Phone);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@Account", model.Account);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@Block", model.Block);
            command.Parameters.AddWithValue("@Career", model.Caerre);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Members model)
        {
            SqlConnection connection = new SqlConnection(
               "Server = 192.168.40.36,1433 ; database = E-Commerce; user id = smallhandsomehandsome; password = 123");
            var sql = "Delete FROM OrderDetail WHERE MemberID=@MemberID";


            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Members FindById(string MemberID)
        {
            SqlConnection connection = new SqlConnection(
                "Server = 192.168.40.36,1433 ; database = E-Commerce; user id = smallhandsomehandsome; password = 123");
            var sql = "SELECT * FROM Members WHERE MemberID = @MemberID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", MemberID);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var Member = new Members();

            while (reader.Read())
            {
                Member.MemberID = int.Parse(reader.GetValue(reader.GetOrdinal("MemberID")).ToString());
                Member.MemberName = reader.GetValue(reader.GetOrdinal("MemberName")).ToString();
                Member.Address = reader.GetValue(reader.GetOrdinal("Address")).ToString();
                Member.Age = int.Parse(reader.GetValue(reader.GetOrdinal("Age")).ToString());
                Member.CerditCard = int.Parse(reader.GetValue(reader.GetOrdinal("CerditCard")).ToString());
                Member.Phone = int.Parse(reader.GetValue(reader.GetOrdinal("Phone")).ToString());
                Member.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                Member.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                Member.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
                Member.Block = reader.GetValue(reader.GetOrdinal("Block")).ToString();
                Member.Caerre = reader.GetValue(reader.GetOrdinal("Caerre")).ToString();
            }

            reader.Close();

            return Member;
        }

        public IEnumerable<Members> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "data source = 192.168.40.36,1433 ; database = E-Commerce; user id = smallhandsomehandsome; password = 123");
            var sql = "SELECT * FROM Members";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);


            var list = new List<Members>();
            var mreader = new Members();
            while (reader.Read())
            {

                mreader.MemberID = int.Parse(reader.GetValue(reader.GetOrdinal("MemberID")).ToString());
                mreader.MemberName = reader.GetValue(reader.GetOrdinal("Name")).ToString();
                mreader.Address = reader.GetValue(reader.GetOrdinal("Address")).ToString();
                mreader.Age = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Age")));
                mreader.CerditCard = int.Parse(reader.GetValue(reader.GetOrdinal("CerditCard")).ToString());
                mreader.Phone = int.Parse(reader.GetValue(reader.GetOrdinal("Phone")).ToString());
                mreader.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                mreader.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                mreader.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
                mreader.Block = reader.GetValue(reader.GetOrdinal("Block")).ToString();
                mreader.Caerre = reader.GetValue(reader.GetOrdinal("Caerre")).ToString();
                list.Add(mreader);
            }

            reader.Close();

            return list;

        }
    }
}
