using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IAddressBL
    {
        public bool AddAddress(AddressModel address, int UserId);

        public bool UpdateAddress(AddressModel address, int UserId);

        public IEnumerable<AddressModel> GetAllAddress(int UserId);
    }
}
