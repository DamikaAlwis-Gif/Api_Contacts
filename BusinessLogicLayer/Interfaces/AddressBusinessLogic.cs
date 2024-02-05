using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public class AddressBusinessLogic : IAddressBusinessLogic
    {
        private readonly IAddressRepository addressRepository;
        public AddressBusinessLogic(IAddressRepository addressRepository) { this.addressRepository = addressRepository; }

        public async Task<Address> AddAddressAsync(AddAddressRequest addAddressRequest)
        {
            return await addressRepository.AddAddressAsync(addAddressRequest);
           
        }

        public async Task<IEnumerable<Address>> GetAddressesAsync()
        {
            return await addressRepository.GetAddressesAsync();
            
        }
        
    }
}
