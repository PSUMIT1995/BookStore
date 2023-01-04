using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Security.Claims;

namespace BookStoreApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL orderBL;
        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }



        [HttpPost("AddOrder")]
        public IActionResult AddOrder(OrderModel postModel)
        {
            try
            {
                var result = orderBL.AddOrder(postModel);
                if (result == false)
                {
                    return this.BadRequest(new { success = false, Message = $"Check if Book is availbale in cart OR Check enough Books are in stock !! OR Check AddressId Exists!!" });
                }

                return this.Ok(new { success = true, Message = $"Order placed Sucessfully..." });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = identity.Claims;
                var userId = claims.Where(p => p.Type == @"UserId").FirstOrDefault()?.Value;
                int UserId = Convert.ToInt32(userId);
                List<GetOrderModel> result = orderBL.GetAllOrders(UserId);
                if (result.Count == 0)
                {
                    return this.BadRequest(new { success = false, Message = $"No Addresses available For UserId : {UserId}!!" });
                }

                return this.Ok(new { success = true, Message = $"Order List of UserId : {UserId} fetched Sucessfully...", data = result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete("DeleteOrder/{OrderId}")]
        public IActionResult DeleteOrder(int OrderId)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claims = identity.Claims;
                var userId = claims.Where(p => p.Type == @"UserId").FirstOrDefault()?.Value;
                int UserId = Convert.ToInt32(userId);
                bool result = orderBL.DeleteOrder(UserId, OrderId);
                if (result == false)
                {
                    return this.BadRequest(new { success = false, Message = $"No Addresses available For UserId : {UserId}!!" });
                }

                return this.Ok(new { success = true, Message = $"Order List of UserId : {UserId} fetched Sucessfully..." });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
