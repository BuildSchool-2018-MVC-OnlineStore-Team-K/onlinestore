using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Utilities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BuildSchool.MVCSolution.OnlineStore.Repository
{
    public class MembersRepository
    {
        MyConnectionString source = new MyConnectionString();

        public void Create(Members model)
        {
            SqlConnection connection = new SqlConnection(source.connect);
            var sql = "INSERT INTO Members VALUES " +
                "(@MemberID, " +
                "@Name," +
                " @Address," +
                "@Birthday," +
                "@CreditCard, " +
                "@Phone," +
                " @Email, " +
                "@Account, " +
                "@Password, " +
                "@Block, " +
                "@Career)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);
            command.Parameters.AddWithValue("@Name", model.MemberName);
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
            SqlConnection connection = new SqlConnection(source.connect);
            var sql = "UPDATE OrderDetail SET(MemberID=@MemberID, " +
                 "Name=@Name," +
                 "Address=@Address," +
                 "Birthday = @Birthday," +
                 "CreditCard=@CreditCard, " +
                 "Phone=@Phone," +
                 "Email=@Email, " +
                 "Account=@Account, " +
                 "Password=@Password, " +
                 "Block=@Block, " +
                 "Career=@Career)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);
            command.Parameters.AddWithValue("@Name", model.MemberName);
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
            SqlConnection connection = new SqlConnection(source.connect);
            var sql = "Delete FROM OrderDetail WHERE MemberID=@MemberID";


            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Members FindById(string MemberID)
        {
            SqlConnection connection = new SqlConnection(source.connect);
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
                Member.Block = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Block")));
                Member.Career = reader.GetValue(reader.GetOrdinal("Career")).ToString();
            }

            reader.Close();

            return Member;
        }

        public IEnumerable<Members> All
        {
            get
            {
                SqlConnection connection = new SqlConnection(source.connect);
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
                    mreader.Block = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Block")));
                    mreader.Career = reader.GetValue(reader.GetOrdinal("Career")).ToString();
                    list.Add(mreader);
                }

                reader.Close();

                return list;

            }
        }

        //不要亂命名r
        public void UpdateMemberInformation(int MemberID)
        {
            SqlConnection connection = new SqlConnection(source.connect);
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
            SqlConnection connection = new SqlConnection(source.connect);
            var sql = "UPDATE Members SET(MemberID=@MemberID, " +
                 "Name=@Name," +
                 "Address=@Address," +
                 "Birthday = @Birthday," +
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

        public IEnumerable<Members> GetAll() //NEWPassword
        {
            SqlConnection connection = new SqlConnection(source.connect);
            var sql = "SELECT Password FROM  Members  WHERE MemberID=@MemberID,@Password=Password";
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

        public bool CheckAccountIsExist(string Account)
        {
            SqlConnection connection = new SqlConnection(source.connect);
            var result = connection.Query<Members>("SELECT account From Members where Account = @Account ", new
            {
                Account
            });
            if (result.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }



        public bool CreateAccount(RegisterModel member)
        {
            SqlConnection connection = new SqlConnection(source.connect);
            connection.Execute("INSERT INTO Members([Name], [Address],Birthday,Phone,Email,Account,[Password],Career,[Block]) Values(@Name , @Address , @Birthday ,@Phone , @Email , @Account , @Password , @Career ,0)",
                new
                {
                    member.Name,
                    member.Address,
                    member.Birthday,
                    member.Phone,
                    member.Email,
                    member.Account,
                    member.Password,
                    member.Career
                });
            var result = connection.Query<RegisterModel>("SELECT * FROM Members Where Account = @Account and Name = @Name", new
            {
                member.Account,
                member.Name
            });
            if (result.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string AccountLogin(string Account, string Password)
        {
            SqlConnection connection = new SqlConnection(source.connect);
            var result = connection.Query<LoginViewModel>("SELECT Name FROM Members WHERE Account = @Account AND Password = @Password",new {
                Account,
                Password
            });
            return result.ToList()[0].Name;
        }

        public bool CheckFbIdExist(string id)
        {
            SqlConnection connection = new SqlConnection(source.connect);

            var result = connection.Query("SELECT FbId From Members Where FbId = @id", new
            {
                id
            });
            if (result.Count() > 0)
            {
                return true;//存在
            }
            else
            {
                return false;
            }
        }
    }
}
