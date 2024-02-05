using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAddressBusinessLogic
    {
        Task<IEnumerable<Address>> GetAddressesAsync();
        Task<Address> AddAddressAsync(AddAddressRequest addAddressRequest);
    }
}
