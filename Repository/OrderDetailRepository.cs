using BuildSchool.MVCSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.MVCSolution.OnlineStore.Utilities;
using ViewModels;
using Dapper;
using BuildSchool.MVCSolution.OnlineStore.Repository;

namespace BuildSchool.MVCSolution.OnlineStore.OrderDetailRepository
{
    public class OrderDetailRepository
    {
        MyConnectionString source = new MyConnectionString();

        public void AddToCartOrderDetail(AddToCartViewModel viewmodel, int orderid)
        {
            var sql = "INSERT INTO OrderDetail(OrderID, ProductID, UnitPrice, Quantity, SizeType, Color) VALUES(@OrderID, @ProductID, @Quantity , @UnitPrice, @SizeType, @Color)";

            var parameters = new DynamicParameters();
            parameters.Add("@OrderID", orderid);
            parameters.Add("@ProductID", viewmodel.ProductID);
            parameters.Add("@UnitPrice", viewmodel.UnitPrice);
            parameters.Add("@Quantity", viewmodel.Quantity);
            parameters.Add("@SizeType", viewmodel.Size);
            parameters.Add("@Color", viewmodel.Color);
            using(var connection = new SqlConnection(source.connect))
            {
                connection.Query<AddToCartViewModel>(sql, parameters);
            }
        }

        public void Create(OrderDetail model)
        {
            SqlConnection connection = new SqlConnection(source.connect);

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
            SqlConnection connection = new SqlConnection(source.connect);

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

            SqlConnection connection = new SqlConnection(source.connect);

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
            SqlConnection connection = new SqlConnection(source.connect);

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
            SqlConnection connection = new SqlConnection(source.connect);

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
            SqlConnection connection = new SqlConnection(source.connect);

            var sql = "SELECT SUM(UnitPrice * Quantity * (1-Discount)) FROM OrderDetail WHERE OrderID = @OrderID GROUP BY OrderID";
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

        public IEnumerable<OrdersViewModel> GetMemberOrderDetail(int MemberID)
        {
            SqlConnection connection = new SqlConnection(source.connect);
            return connection.Query<OrdersViewModel>("SELECT o.Time,o.OrderID,o.Payway,od.UnitPrice,od.Quantity,od.Discount ,p.ProductID FROM Members m INNER JOIN Orders o ON o.MemberID = m.MemberID INNER JOIN OrderDetail od ON od.OrderID = o.OrderID INNER JOIN Products p ON p.ProductID = od.ProductID WHERE m.MemberID = 1 AND o.Cart = 0", new
            {
                MemberID
            });
        }

        public IEnumerable<OrderDetailsViewModel> GetOrdersOrderDetails(int OrderID)
        {
            SqlConnection connection = new SqlConnection(source.connect);
            return connection.Query<OrderDetailsViewModel>("SELECT p.ProductID,p.ProductName,sc.Color,s.SizeType,od.Quantity,od.UnitPrice FROM OrderDetail od INNER JOIN Products p ON p.ProductID = od.ProductID INNER JOIN Size s ON s.ProductID = p.ProductID INNER JOIN StockColor sc ON sc.SizeID = s.SizeID WHERE od.OrderID = @OrderID", new
            {
                OrderID
            });
        }
    }
}
