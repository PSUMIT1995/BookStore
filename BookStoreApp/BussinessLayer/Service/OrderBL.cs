using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class OrderBL : IOrderBL
    {
        private IOrderRL orderRL;

        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }
        public bool AddOrder(OrderModel orderModel)
        {
            try
            {
                return orderRL.AddOrder(orderModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<GetOrderModel> GetAllOrders(int UserId)
        {
            try
            {
                return orderRL.GetAllOrders(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public bool DeleteOrder(int UserId, int OrderId)
        {
            try
            {
                return orderRL.DeleteOrder(UserId, OrderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
