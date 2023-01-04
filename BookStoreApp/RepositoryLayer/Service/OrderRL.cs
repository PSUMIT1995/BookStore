using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service
{
    public class OrderRL : IOrderRL
    {
       
        private readonly string connectionString;
        public OrderRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStore");
        }
      
        

        public bool AddOrder(OrderModel orderModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("AddOrder", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", orderModel.CartId);
                    cmd.Parameters.AddWithValue("@AddressId", orderModel.AddressId);
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<GetOrderModel> GetAllOrders(int UserId)
        {
            List<GetOrderModel> OrdersList = new List<GetOrderModel>();
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                using (Connection)
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("GetAllOrders", Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GetOrderModel order = new GetOrderModel();
                            order.OrderId = reader["OrderId"] == DBNull.Value ? default : reader.GetInt32("OrderId");
                            order.UserId = reader["UserId"] == DBNull.Value ? default : reader.GetInt32("UserId");
                            order.BookId = reader["BookId"] == DBNull.Value ? default : reader.GetInt32("BookId");
                            order.AddressId = reader["AddressId"] == DBNull.Value ? default : reader.GetInt32("AddressId");
                            order.BookName = reader["BookName"] == DBNull.Value ? default : reader.GetString("BookName");
                           
                            order.OrderQuantity = reader["OrderQuantity"] == DBNull.Value ? default : reader.GetInt32("OrderQuantity");
                            order.TotalOrderPrice = reader["TotalOrderPrice"] == DBNull.Value ? default : reader.GetDecimal("TotalOrderPrice");
                            order.OrderDate = reader["OrderDate"] == DBNull.Value ? default : reader.GetDateTime("OrderDate");
                            
                            OrdersList.Add(order);
                        }

                        return OrdersList;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool DeleteOrder(int UserId, int OrderId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DeleteOrder", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@OrderId", OrderId);
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
