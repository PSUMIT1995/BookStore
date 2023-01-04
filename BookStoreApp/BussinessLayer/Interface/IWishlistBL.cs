using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IWishlistBL
    {
        public bool AddtoWishlist(int BookId, int UserId);

        public bool DeletefromWishlist(int WishlistId);
        public IEnumerable<WishlistModel> GetWishlist(int UserId);
    }
}
