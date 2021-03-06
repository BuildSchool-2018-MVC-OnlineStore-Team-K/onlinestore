﻿using BuildSchool.MVCSolution.OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.MVCSolution.OnlineStore.Utilities;
using Dapper;
using ViewModels;
using System.Configuration;

namespace BuildSchool.MVCSolution.OnlineStore.Repository
{
    public class OrdersRepository 
    {
         MyConnectionString source = new MyConnectionString();
        //private string connect = "Server=192.168.40.35,1433;Database=E-Commerce;User ID =smallhandsomehandsome; Password =123;";]
              

        public void Create(Orders model)    
        {

            SqlConnection connection = new SqlConnection(source.connectcloud);
            var sql = "INSERT INTO Orders Values(@MemberID , @OrderID , @Pay , @Payway , @ShipPlace , @Time , @Cart)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);
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
            SqlConnection connection = new SqlConnection(source.connectcloud);

            var sql = "UPDATE Orders SET( MemberID = @MemberID  , OrderDetailID = @OrderDetailID  , OrderID = @OrderID , Pay = @Pay , Payway = @Payway , ShipPlace = @ShipPlace , Time = @Time , Cart = @Cart )";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);
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


        public IEnumerable<Orders> GetByOrderID(int OrderID) //ok
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            var sql = "SELECT * FROM Orders Where OrderID = @OrderID";
            var list = new List<Orders>();
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);
            connection.Open();
            var orders = new Orders();
            var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                orders = DbReaderModelBinder<Orders>.Bind(reader);
                list.Add(orders);
            }
            reader.Close();
            connection.Close();

            return list; //?

        }


        public void Delete(Orders model)
        {

            SqlConnection connection = new SqlConnection(source.connectcloud);
            var sql = "DELETE FROM Orders where OrderID = @OrderID";
            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        public IEnumerable<Orders> GetAll() //ok
                                       //()內不用給直 因為傳整個表格  
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            var sql = "SELECT * FROM  Orders";
            SqlCommand command = new SqlCommand(sql, connection);
            var list = new List<Orders>();
            var orders = new Orders();
            connection.Open();
            var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            
            while (reader.Read())
            {
                orders = DbReaderModelBinder<Orders>.Bind(reader);
                list.Add(orders);
            }
            reader.Close();
            connection.Close();
            return list;
        }


        public IEnumerable<Orders> _GetAll()
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            return connection.Query<Orders>("Select * FROM Orders");
        }

        //0是購物車
        public bool UpdateCartToOrders(int MemberID , int OrderID) 
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            connection.Query("Update Orders SET cart = 1 where MemberID = @MemberID and OrderID = @OrderID",new {
                MemberID,
                OrderID
            });
            var result = connection.Query("Select * from orders where MemberID = @MemberID and OrderID = @OrderID and Cart = 1 ",new {
                MemberID,
                OrderID
            });
            if(result.Count()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int GetCartOrderID(int MemberID)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            var sql = "SELECT OrderID FROM Orders  WHERE MemberID = @MemberID and Cart = 0";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            var orders = new Orders();
            connection.Open();
            //查詢是否有購物車存在 cart=0
            var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                orders = DbReaderModelBinder<Orders>.Bind(reader);
            }
            reader.Close();
            
            //如果有購物車存在,回傳OrderID
            if (orders.OrderID >0)
            {
                connection.Close();
                return orders.OrderID;
            }
            //如果沒有購物車存在 新增一筆
            else
            {
                //var now = DateTime.Now.ToString("MM-dd-yyyy");
                var sql2 = "INSERT INTO Orders( MemberID , Cart ) Values(@MemberID ,  @Cart)";
                SqlCommand command2 = new SqlCommand(sql2, connection);
                connection.Open();
                command2.Parameters.AddWithValue("@MemberID", MemberID);
                //command.Parameters.AddWithValue("@Time", now);
                command2.Parameters.AddWithValue("@Cart", 0);
                var q = command2.ExecuteNonQuery();
                //檢查是否有成功新增購物車 , 如果有 回傳OrderID
                if(q>0)
                {
                    var reader2 = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader2.Read())
                    {
                        orders = DbReaderModelBinder<Orders>.Bind(reader2);
                    }
                    reader2.Close();
                    connection.Close();
                    return orders.OrderID;
                }
                else
                {
                    connection.Close();
                    throw new Exception("新增購物車失敗,請聯絡客服.");
                }
            }
            
        }


        public IEnumerable<CartViewModel> GetCartProductsInformation(string Account)
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            //取得該會員得購物車 詳細資訊 購買了ooxx的oo尺寸oo個oo顏色ooxx

            return  connection.Query<CartViewModel>("SELECT  p.ProductName, od.UnitPrice , Quantity, sc.Color, sz.SizeType, od.Discount FROM Members m INNER JOIN Orders o ON o.MemberID = m.MemberID INNER JOIN OrderDetail od ON o.OrderID = od.OrderID INNER JOIN Products p ON p.ProductID = od.ProductID INNER JOIN Size sz ON p.ProductID = sz.ProductID INNER JOIN StockColor sc ON sc.SizeID = sz.SizeID WHERE m.Account = @Account and Cart = 0", new {
                Account
            });

        }

        public IEnumerable<Orders> GetOrdersStatus()
        {
            SqlConnection connection = new SqlConnection(source.connectcloud);
            var result = connection.Query<Orders>("SELECT * FROM Orders");
            return result;
        }


    }
}
