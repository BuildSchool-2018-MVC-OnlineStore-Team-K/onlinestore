﻿using BuildSchool.MVCSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuildSchool.MVCSolution.OnlineStore.OrderDetailRepository
{
    public class OrderDetailRepository
    {
        public void Create(OrderDetail model)
        {
            SqlConnection connection = new SqlConnection("Server=192.168.40.36,1433;Database=E-Commerce;Trusted_Connection=True; User ID = littlehandsomehandsome ; Password = 123;");

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
            SqlConnection connection = new SqlConnection("Server=192.168.40.36,1433;Database=E-Commerce;Trusted_Connection=True; User ID = littlehandsomehandsome ; Password=123;");

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

            SqlConnection connection = new SqlConnection("Server=192.168.40.36,1433;Database=E-Commerce;Trusted_Connection=True; User ID =smallhandsomehandsome; Password = 123;");

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
            SqlConnection connection = new SqlConnection("Server=192.168.40.36,1433;Database=E-Commerce;  User ID=smallhandsomehandsome ; Password=123;");

            var sql = "SELECT * FROM  OrderDetail";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            var reader = command.ExecuteReader();
            var list = new List<OrderDetail>();
            var orderDetail = new OrderDetail();
            while (reader.Read())
            {
                orderDetail.OrderID = int.Parse(reader.GetValue(reader.GetOrdinal("OrderID")).ToString());
                orderDetail.ProductID = int.Parse(reader.GetValue(reader.GetOrdinal("ProductID")).ToString());
                orderDetail.UnitPrice =  int.Parse(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString());
                orderDetail.Quantity = int.Parse(reader.GetValue(reader.GetOrdinal("Quantity")).ToString());
                orderDetail.Discount = int.Parse(reader.GetValue(reader.GetOrdinal("Discount")).ToString());
                list.Add(orderDetail);
            }
            reader.Close();
            connection.Close();

            return list;
        }

    }
}