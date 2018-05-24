using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Utilities;
using Dapper;

namespace BuildSchool.MVCSolution.OnlineStore.Repository
{
    public class DiscountRepository
    {
        /// <summary>
        /// Create Discounts
        /// </summary>
        /// <param name="model"></param>
        private string connect = "Server=192.168.40.36,1433;Database=E-Commerce;User ID =smallhandsomehandsome ; Password =123;";
        public void Create(Discounts model)
        {
            SqlConnection connection = new SqlConnection(connect);
            var sql = "INSERT INTO Discounts VALUES (@did, @pid, @discount, @start, @end";

            connection.Open();
            var transaction = connection.BeginTransaction(/*default:readuncommited*/); 

            //excute commands
            try
            {
                transaction.Commit();
            }
            catch (SqlException e)
            {
                transaction.Rollback();
            }

            SqlCommand command = new SqlCommand(sql, connection);
            command = AddWithAllDiscountValue(model);

            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }

        /// <summary>
        /// Update Discount
        /// </summary>
        /// <param name="model"></param>
        public void Update(Discounts model)
        {
            SqlConnection connection = new SqlConnection(connect);
            var sql = "UPDATE Discounts SET Discount = @discount, StartTime = @start, EndTime = @end WHERE DiscountID = @did AND ProductID = @pid";

            SqlCommand command = new SqlCommand(sql, connection);

            command = AddWithAllDiscountValue(model);
            //command.Parameters.AddWithValue("@did", model.DiscountID);
            //command.Parameters.AddWithValue("@pid", model.ProductID);
            //command.Parameters.AddWithValue("@discount", model.Discount);
            //command.Parameters.AddWithValue("@start", model.StartTime);
            //command.Parameters.AddWithValue("@end", model.EndTime);

            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }

        /// <summary>
        /// Add All Discount Column Into Command
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SqlCommand AddWithAllDiscountValue(Discounts model)
        {
            SqlCommand command = new SqlCommand(connect);
            command.Parameters.AddWithValue("@did", model.DiscountID);
            command.Parameters.AddWithValue("@pid", model.ProductID);
            command.Parameters.AddWithValue("@discount", model.Discount);
            command.Parameters.AddWithValue("@start", model.StartTime);
            command.Parameters.AddWithValue("@end", model.EndTime);
            return command;
        }

        /// <summary>
        /// Delete Discount 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(Discounts model)
        {
            SqlConnection connection = new SqlConnection(connect);
            var sql = "DELETE FROM Discounts WHERE DiscountID = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", model.DiscountID);

            connection.Open();
            command.ExecuteReader();
            connection.Close();
        }

        /// <summary>
        /// Find Discount
        /// </summary>
        /// <param name="discountId"></param>
        /// <returns></returns>
        public Discounts FindById(string discountId)
        {
            SqlConnection connection = new SqlConnection(connect);
            var sql = "SELECT * FROM Discounts WHERE DiscountID = @did";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", discountId);

            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var discount = new Discounts();

            while (reader.Read())
            {
                discount.DiscountID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("DiscountID")));
                discount.ProductID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ProductID")));
                discount.Discount = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("Discount")));
                discount.StartTime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("StartTime")));
                discount.EndTime = Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("EndTime")));
            }

            reader.Close();
            connection.Close();
            return discount;
        }

        /// <summary>
        /// Get All Discount
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Discounts> GetAll()
        {
            SqlConnection connection = new SqlConnection(connect);
            var sql = "SELECT * FROM Discounts";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var list = new List<Discounts>();

            while (reader.Read())
            {
                var discount = new Discounts();
                discount = DbReaderModelBinder<Discounts>.Bind(reader);
                list.Add(discount);
            }

            reader.Close();
            connection.Close();
            return list;
        }

        /// <summary>
        /// DapperDiscountGetAll
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Discounts> _GetAll()
        {
            SqlConnection connection = new SqlConnection(connect);
            var result = connection.Query<Discounts>("SELECT * FROM Discounts");
            return result;
        }

        /// <summary>
        /// Find All Product Then Order By Discount
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Discounts> OrderByDiscount()
        {
            //找到所有產品，並用折扣排序
            SqlConnection connection = new SqlConnection(connect);
            var sql = "SELECT p.ProductID, p.Category, p.ProductName, p.UnitPrice FROM Products p INNER JOIN Discounts d ON d.ProductID = p.ProductID WHERE d.ProductID = p.ProductID ORDER BY d.Discount";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var list = new List<Discounts>();

            while (reader.Read())
            {
                var discount = new Discounts();
                discount = DbReaderModelBinder<Discounts>.Bind(reader);
                list.Add(discount);
            }

            reader.Close();
            connection.Close();
            return list;
        }

        public IEnumerable<Discounts> OrderByDiscountDESC()
        {
            //找到所有產品，並用折扣排序
            SqlConnection connection = new SqlConnection(connect);
            var sql = "SELECT p.ProductID, p.Category, p.Name, p.UnitPrice FROM Products p INNER JOIN Discounts d ON d.ProductID = p.ProductID WHERE d.ProductID = p.ProductID ORDER BY d.Discount DESC";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            var list = new List<Discounts>();

            while (reader.Read())
            {
                var discount = new Discounts();
                discount = DbReaderModelBinder<Discounts>.Bind(reader);
                list.Add(discount);
            }

            reader.Close();
            connection.Close();
            return list;
        }
    }
}
//data source, database, user id, password

//ExecuteScalar:取純量值(一筆)
//ExecuteReader:Cursor(一去不復返)
//GetOrdinal:使用欄位來抓值(ExecuteReader)

//單元測試：新增專案
//using陳述式，用來防止忘記關資料庫，用來宣告多個物件
//IDisaposable