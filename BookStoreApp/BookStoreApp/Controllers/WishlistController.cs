using BussinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace BookStoreApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private IWishlistBL wishlistBL;

        public WishlistController(IWishlistBL wishlistBL)
        {
            this.wishlistBL = wishlistBL;
        }

        [HttpPost("AddtoWishlist")]
        public IActionResult AddtoWishlist(int bookId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = wishlistBL.AddtoWishlist(bookId, userId);
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Added to wishlist", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Wishlist unsuccessful", Data = result });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }



        [HttpDelete("RemovefromWishlist")]
        public IActionResult DeletefromWishlist(int WishlistId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = wishlistBL.DeletefromWishlist(WishlistId);
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Removed from wishlist" });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Failed to Delete" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("GetWishlist")]
        public IActionResult GetWishlist(int UserId)
        {
            try
            {
                int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value);
                var result = wishlistBL.GetWishlist(UserId);
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Wishlist Retrieved", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Retrieve Unsuccessful" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

}
