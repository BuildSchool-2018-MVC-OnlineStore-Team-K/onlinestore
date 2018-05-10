using BuildSchool.MVCSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BuildSchool.MVCSolution.OnlineStore.Repository
{
    public class OrdersRepository
    {

        public void Create(Orders model)
        {
            SqlConnection connection = new SqlConnection("Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;Trusted_Connection=True;");

            var sql = "INSERT INTO Orders Values(@MemberID , @OrderDetailID  , @OrderID , @Pay , @Payway , @ShipPlace , @Time , @Cart)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);
            command.Parameters.AddWithValue("@OrderDetailID", model.OrderDetailID);
            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@Pay", model.Pay);
            command.Parameters.AddWithValue("@Payway", model.Payway);
            command.Parameters.AddWithValue("@ShipPlace", model.ShipPlace);
            command.Parameters.AddWithValue("@Time", model.Time);
            command.Parameters.AddWithValue("@Cart", model.Cart);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }



        public void Update(Orders model)
        {
            SqlConnection connection = new SqlConnection("Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;Trusted_Connection=True;");

            var sql = "UPDATE Orders SET( MemberID = @MemberID  , OrderDetailID = @OrderDetailID  , OrderID = @OrderID , Pay = @Pay , Payway = @Payway , ShipPlace = @ShipPlace , Time = @Time , Cart = @Cart )";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);
            command.Parameters.AddWithValue("@OrderDetailID", model.OrderDetailID);
            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@Pay", model.Pay);
            command.Parameters.AddWithValue("@Payway", model.Payway);
            command.Parameters.AddWithValue("@ShipPlace", model.ShipPlace);
            command.Parameters.AddWithValue("@Time", model.Time);
            command.Parameters.AddWithValue("@Cart", model.Cart);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }


        public void Delete(Orders model)
        {

            SqlConnection connection = new SqlConnection("Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;Trusted_Connection=True;");

            var sql = "DELETE FROM Orders where OrderID = 1";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        public IEnumerable<Orders> GetAll() //()內不用給直 因為傳整個表格
        {
            //SqlConnection connection = new SqlConnection("Server=.;Database=E-Commerce;Trusted_Connection=True;");
            SqlConnection connection = new SqlConnection("Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;");

            var sql = "SELECT * FROM  Orders";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            //var reader = command.ExecuteReader();
            var list = new List<Orders>();
            var orders = new Orders();
            //var properties = typeof(Orders).GetProperties();
            var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            //Orders orders = null;
            while (reader.Read())
            {
                orders = DbReaderModelBinder<Orders>.Bind(reader);
                list.Add(orders);
            }
            reader.Close();
            connection.Close();
            return list;
        }

    }
}
