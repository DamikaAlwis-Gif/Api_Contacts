using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AddressServiceEndPoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private IAddressBusinessLogic AddressBusinessLogic;
        public AddressesController(IAddressBusinessLogic addressBusinessLogic) {
            this.AddressBusinessLogic = addressBusinessLogic;
        }
        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {

            var  Addresses = await AddressBusinessLogic.GetAddressesAsync();
            return Ok(Addresses);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(AddAddressRequest addAddressRequest)
        {
            var Addresss = await AddressBusinessLogic.AddAddressAsync(addAddressRequest);
            return Ok(Addresss);
        }
        
    }
}
