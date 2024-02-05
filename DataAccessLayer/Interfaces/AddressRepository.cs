using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class AddressRepository : IAddressRepository
    {
        public AddressRepository(AddressDbContext addressDb) { 
        this.addressDb = addressDb;
        }
        private readonly AddressDbContext addressDb;
        public async Task<IEnumerable<Address>> GetAddressesAsync()
        {
            var Addresses = await addressDb.Addresses.ToListAsync();
            return Addresses;
        }

        public async Task<Address> AddAddressAsync(AddAddressRequest addAddressRequest)
        {
            var Address = new Address()
            {
                Id = Guid.NewGuid(),
                HouseNo = addAddressRequest.HouseNo,
                City = addAddressRequest.City,  
                District = addAddressRequest.District,
                Road = addAddressRequest.Road
            };
            await addressDb.Addresses.AddAsync(Address);
            await addressDb.SaveChangesAsync();
            return Address;
            
        }
    }
}
