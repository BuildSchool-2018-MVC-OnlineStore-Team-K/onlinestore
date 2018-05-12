﻿using BuildSchool.MVCSolution.OnlineStore.Models;
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
    public class ProductsRepository
    {
        public void Create(Products model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=192.168.0.105,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;");
            var sql = "INSERT INTO Products VALUES (@productid, @category, @productname, @unitprice,@shelfTime)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productid", model.ProductID);
            command.Parameters.AddWithValue("@category", model.Category);
            command.Parameters.AddWithValue("@productname", model.ProductName);
            command.Parameters.AddWithValue("@unitprice", model.UnitPrice);
            command.Parameters.AddWithValue("@shelfTime", model.ShelfTime);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Products model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=192.168.0.105,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;");
            var sql = "UPDATE Products SET Category=@category, ProductName=@productname, UnitPrice=@unitprice, ShelfTime=@shelfTime WHERE ProductID = @productid";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productid", model.ProductID);
            command.Parameters.AddWithValue("@category", model.Category);
            command.Parameters.AddWithValue("@productname", model.ProductName);
            command.Parameters.AddWithValue("@unitprice", model.UnitPrice);
            command.Parameters.AddWithValue("@shelfTime", model.ShelfTime);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Products model)
        {
            SqlConnection connection = new SqlConnection(
                "Server=192.168.0.105,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;");
            var sql = "DELETE FROM Products WHERE ProductID = @productid";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@productid", model.ProductID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<Products> GetAll()
        {
            SqlConnection connection = new SqlConnection(
                "Server=192.168.0.105,1433;Database=E-Commerce;User ID =smallhandsomehandsome; Password =123;");
            var sql = "SELECT * FROM Products";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader();
            var list = new List<Products>();
            //var properties = typeof(Products).GetProperties();
            Products products = new Products();

            while (reader.Read())
            {
                products = DbReaderModelBinder<Products>.Bind(reader);
                list.Add(products);
                //products = new Products();
                //for (var i = 0; i < reader.FieldCount; i++)
                //{
                //    var fieldName = reader.GetName(i);
                //    var property = properties.FirstOrDefault(
                //        p => p.Name == fieldName);

                //    if (property == null)
                //        continue;

                //    if (!reader.IsDBNull(i))
                //        property.SetValue(products,
                //            reader.GetValue(i));
                //    //var product = new Products();
                //    //product.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));  //用欄位名稱取得位址
                //    //product.Category = reader.GetValue(reader.GetOrdinal("Category")).ToString();
                //    //product.ProductName = reader.GetValue(reader.GetOrdinal("ProductName")).ToString();
                //    //product.UnitPrice = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("UnitPrice")));
                //    //product.ShelfTime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("ShelfTime")));
                //    //products.Add(product);
                //}
            }
            
            reader.Close();
            connection.Close();
            return list;

        }        
    }
}
