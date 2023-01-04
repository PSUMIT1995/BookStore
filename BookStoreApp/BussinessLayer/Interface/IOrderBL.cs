using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IOrderBL
    {
        public bool AddOrder(OrderModel orderModel);

        public List<GetOrderModel> GetAllOrders(int UserId);

        public bool DeleteOrder(int UserId, int OrderId);
    }
}
