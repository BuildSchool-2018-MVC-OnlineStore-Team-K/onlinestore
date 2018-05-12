using BuildSchool.MVCSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.MVCSolution.OnlineStore.Utilities;


namespace BuildSchool.MVCSolution.OnlineStore.OrderDetailRepository
{
    public class OrderDetailRepository
    {
        public void Create(OrderDetail model)
        {
            SqlConnection connection = new SqlConnection(
              "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "INSERT INTO OrderDetail Values(@OrderID , @ProductID, @UnitPrice, @Quantity , @Discount)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);
            command.Parameters.AddWithValue("@Discount", model.Discount);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }



        public void Update(OrderDetail model)
        {
            SqlConnection connection = new SqlConnection(
              "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "UPDATE OrderDetail SET(OrderID=@OrderID,ProductID=@ProductID,UnitPrice=@UnitPrice,Quantity=@Quantity,Discount=@Discount)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);
            command.Parameters.AddWithValue("@UnitPrice", model.UnitPrice);
            command.Parameters.AddWithValue("@Quantity", model.Quantity);
            command.Parameters.AddWithValue("@Discount", model.Discount);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }


        public void Delete(OrderDetail model)
        {

            SqlConnection connection = new SqlConnection(
              "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "Delete FROM OrderDetail WHERE OrderID=@OrderID AND ProductID=@ProductID";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@OrderID", model.OrderID);
            command.Parameters.AddWithValue("@ProductID", model.ProductID);


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<OrderDetail> GetAll() //()內不用給直 因為傳整個表格
        {
            SqlConnection connection = new SqlConnection(
               "data source = 192.168.0.105,1433 ; database = E-Commerce ; user id = smallhandsomehandsome; password = 123");

            var sql = "SELECT * FROM  OrderDetail";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            var reader = command.ExecuteReader();
            var list = new List<OrderDetail>();
            var orderDetail = new OrderDetail();
            
            while (reader.Read())
            {
                orderDetail = DbReaderModelBinder<OrderDetail>.Bind(reader);
                list.Add(orderDetail);
                
            }
            reader.Close();
            connection.Close();

            return list;
        }

        public int GetTotalQuantiyByProductID(int ProductID)
        {
            SqlConnection connection = new SqlConnection(
                "data source = 192.168.0.105,1433; database = E-Commerce; user id = smallhandsomehandsome; password = 123");

            var sql = "SELECT SUM(Quantity) FROM OrderDetail WHERE ProductID = @ProductID GROUP BY ProductID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ProductID", ProductID);
            connection.Open();
            var reader = command.ExecuteReader();
            int result = 0;
            while(reader.Read())
            {
                result = Convert.ToInt16(reader.GetValue(0));
            }
            reader.Close();
            connection.Close();
            return result;
        }

        public decimal GetTotalPriceByOrderID(int OrderID)
        {
            SqlConnection connection = new SqlConnection(
                "data source = 192.168.0.105,1433; database = E-Commerce; user id = smallhandsomehandsome; password = 123");

            var sql = "SELECT SUM(UnityPrice * Quantity * (1-Discount)) FROM OrderDetail WHERE OrderID = @OrderID GROUP BY OrderID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);
            connection.Open();
            var reader = command.ExecuteReader();
            decimal result = 0;
            while(reader.Read())
            {
                result = Convert.ToDecimal(reader.GetValue(0));
            }
            reader.Close();
            connection.Close();
            return result;
        }

    }
}
