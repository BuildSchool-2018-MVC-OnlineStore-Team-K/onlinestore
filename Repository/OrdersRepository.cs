using BuildSchool.MVCSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // command.Parameters.AddWithValue("@sizeID", model.SizeID);

            connection.Open();

            var reader = command.ExecuteReader();
            var list = new List<Orders>();
            var orders = new Orders();
            while (reader.Read())
            {
                orders.MemberID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("MemberID")));
                orders.OrderDetailID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("OrderDetailID")));
                orders.OrderID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("OrderID")));
                orders.Pay = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Pay")));
                orders.Payway = reader.GetValue(reader.GetOrdinal("Payway")).ToString();
                orders.ShipPlace = reader.GetValue(reader.GetOrdinal("ShipPlace")).ToString();
                orders.Time = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("Time")));
                orders.Cart = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Cart")));

                list.Add(orders);
            }
            reader.Close();
            connection.Close();

            return list;
        }

    }
}
