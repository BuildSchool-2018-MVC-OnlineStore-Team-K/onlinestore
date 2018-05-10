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
            SqlConnection connection = new SqlConnection(
                "data source=.; database=northwind; integrated security=true");
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
                "@Black, " +
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
            command.Parameters.AddWithValue("@Black", model.Black);
            command.Parameters.AddWithValue("@Career", model.Caerre);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Members model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=northwind; integrated security=true");
            var sql = "UPDATE Customers SET CompanyName=@name, ContactName=@cname, ContactTitle=@ctitle, Address=@address, City=@city, Region=@region, PostalCode=@postalcode, Country=@country, Phone=@phone, Fax=@fax WHERE CustomerID = @id";

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
            command.Parameters.AddWithValue("@Black", model.Black);
            command.Parameters.AddWithValue("@Career", model.Caerre);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Members model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=northwind; integrated security=true");
            var sql = "DELETE FROM Customers WHERE CustomerID = @MemberID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Members FindById(string MemberID)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=northwind; integrated security=true");
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
                Member.Black = reader.GetValue(reader.GetOrdinal("Black")).ToString();
                Member.Caerre = reader.GetValue(reader.GetOrdinal("Caerre")).ToString();
            }

            reader.Close();

            return Member;
        }

        public IEnumerable<Members> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=northwind; integrated security=true");
            var sql = "SELECT * FROM Members";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var member = new List<Members>();

            while (reader.Read())
            {

                var Member = new Members();
                Member.MemberID = int.Parse(reader.GetValue(reader.GetOrdinal("MemberID")).ToString());
                Member.MemberName = reader.GetValue(reader.GetOrdinal("Name")).ToString();
                Member.Address = reader.GetValue(reader.GetOrdinal("Address")).ToString();
                Member.Age = int.Parse(reader.GetValue(reader.GetOrdinal("Age")).ToString());
                Member.CerditCard = int.Parse(reader.GetValue(reader.GetOrdinal("CerditCard")).ToString());
                Member.Phone = int.Parse(reader.GetValue(reader.GetOrdinal("Phone")).ToString());
                Member.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                Member.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                Member.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
                Member.Black = reader.GetValue(reader.GetOrdinal("Black")).ToString();
                Member.Caerre = reader.GetValue(reader.GetOrdinal("Caerre")).ToString();
                member.Add(Member);
            }

            reader.Close();

            return member;

        }
    }
}
