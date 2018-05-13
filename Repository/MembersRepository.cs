using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Utilities;
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
              "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "INSERT INTO Members VALUES " +
                "(@MemberID, " +
                "@Name," +
                " @Address," +
                "@Birthday" +
                "@CreditCard, " +
                "@Phone," +
                " @Email, " +
                "@Account, " +
                "@Password, " +
                "@Block, " +
                "@Career)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);
            command.Parameters.AddWithValue("@MemberName", model.MemberName);
            command.Parameters.AddWithValue("@Address", model.Address);
            command.Parameters.AddWithValue("@Birthday", model.Birthday);
            command.Parameters.AddWithValue("@CreditCard", model.CreditCard);
            command.Parameters.AddWithValue("@Phone", model.Phone);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@Account", model.Account);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@Block", model.Block);
            command.Parameters.AddWithValue("@Career", model.Career);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Members model)
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "UPDATE OrderDetail SET(MemberID=@MemberID, " +
                 "Name=@Name," +
                 "Address=@Address," +
                 "Birthday = @Birthday" +
                 "CreditCard=@CreditCard, " +
                 "Phone=@Phone," +
                 " Email=@Email, " +
                 "Account=@Account, " +
                 "Password=@Password, " +
                 "Block=@Block, " +
                 "Career=@Career)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);
            command.Parameters.AddWithValue("@MemberName", model.MemberName);
            command.Parameters.AddWithValue("@Address", model.Address);
            command.Parameters.AddWithValue("@Birthday", model.Birthday);
            command.Parameters.AddWithValue("@CreditCard", model.CreditCard);
            command.Parameters.AddWithValue("@Phone", model.Phone);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@Account", model.Account);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@Block", model.Block);
            command.Parameters.AddWithValue("@Career", model.Career);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Members model)
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
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
               "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
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
                Member.Birthday = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Birthday")));
                Member.CreditCard = int.Parse(reader.GetValue(reader.GetOrdinal("CreditCard")).ToString());
                Member.Phone = int.Parse(reader.GetValue(reader.GetOrdinal("Phone")).ToString());
                Member.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                Member.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                Member.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
                Member.Block = reader.GetValue(reader.GetOrdinal("Block")).ToString();
                Member.Career = reader.GetValue(reader.GetOrdinal("Career")).ToString();
            }

            reader.Close();

            return Member;
        }

        public IEnumerable<Members> All
        {
            get
            {
                SqlConnection connection = new SqlConnection(
                  "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
                var sql = "SELECT * FROM Members";

                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();

                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);


                var list = new List<Members>();
                var mreader = new Members();
                while (reader.Read())
                {

                    mreader.MemberID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("MemberID")));
                    mreader.MemberName = reader.GetValue(reader.GetOrdinal("Name")).ToString();
                    mreader.Address = reader.GetValue(reader.GetOrdinal("Address")).ToString();
                    mreader.Birthday = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Birthday")));
                    mreader.CreditCard = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CreditCard")));
                    mreader.Phone = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Phone")));
                    mreader.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                    mreader.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                    mreader.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
                    mreader.Block = reader.GetValue(reader.GetOrdinal("Block")).ToString();
                    mreader.Career = reader.GetValue(reader.GetOrdinal("Career")).ToString();
                    list.Add(mreader);
                }

                reader.Close();

                return list;

            }
        }

        public Boolean AccountLogin(string Account, string Password)
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "SELECT Account,Password FROM Members WHERE @Account=Account,@Password=Password ";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var list = new List<Members>();
            //var mreader = new Members();
            Boolean YN;
            if (!reader.Read())
            {
                YN = false;
            }
            else
            {
                YN = true;
            }
            //while (reader.Read())
            //{
            //    mreader.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
            //    mreader.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
            //     list.Add(mreader);
            //command.Parameters.AddWithValue("@Account", Account);
            // command.Parameters.AddWithValue("@Password", Password);
            //}
            reader.Close();
            return YN;
            //return Convert.ToInt32(list);
        }

        //不要亂命名r
        public void UpdateMemberInformation(int MemberID)
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "SELECT MemberID FROM Members WHERE @MemberID=MemberID";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var list = new List<Members>();
            var mreader = new Members();
            while (reader.Read())
            {
                mreader.MemberID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("MemberID")));
                list.Add(mreader);
            }
            reader.Close();
            connection.Close();

        }
        public void UpdateAccountAndPassword(Members model)
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "UPDATE Members SET(MemberID=@MemberID, " +
                 "Name=@Name," +
                 "Address=@Address," +
                 "Birthday = @Birthday" +
                 "CreditCard=@CreditCard, " +
                 "Phone=@Phone," +
                 " Email=@Email, " +
                 "Account=@Account, " +
                 "Password=@Password)";
            SqlCommand command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var list = new List<Members>();
            var mreader = new Members();
            while (reader.Read())
            {

                mreader.MemberID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("MemberID")));
                mreader.MemberName = reader.GetValue(reader.GetOrdinal("Name")).ToString();
                mreader.Address = reader.GetValue(reader.GetOrdinal("Address")).ToString();
                mreader.Birthday = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Birthday")));
                mreader.CreditCard = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("CreditCard")));
                mreader.Phone = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Phone")));
                mreader.Email = reader.GetValue(reader.GetOrdinal("Email")).ToString();
                mreader.Account = reader.GetValue(reader.GetOrdinal("Account")).ToString();
                mreader.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();

                list.Add(mreader);
            }
            reader.Close();
            connection.Close();
        }
      
        public IEnumerable <Members> GetAll() //NEWPassword
        {
            SqlConnection connection = new SqlConnection(
              "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");
            var sql = "SELECT Password FROM  Members  WHERE MemberID=@MemberID,@Password=Password"";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var list = new List<Members>();
            var mreader = new Members();
                while (reader.Read())
            {
                mreader.Password = reader.GetValue(reader.GetOrdinal("Password")).ToString();
                list.Add(mreader);
            }
            reader.Close();
            connection.Close();

            return list;
        }

    }
    }
