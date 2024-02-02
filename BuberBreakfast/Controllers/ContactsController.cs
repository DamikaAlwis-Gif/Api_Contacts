using BuberBreakfast.Data;
using BuberBreakfast.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Controllers
{
    [Route("api/[controller]")] //api/contacts
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsAPIDbContext dbContext;

        public ContactsController(ContactsAPIDbContext dbContext) { 
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return  Ok(await dbContext.Contacts.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> GetContactById(Guid id)
        {
            var contact = await dbContext.Contacts.SingleOrDefaultAsync(x => x.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                Phone = addContactRequest.Phone,
                FullName = addContactRequest.FullName
            };
            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);

        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<ActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.Email = updateContactRequest.Email;
                contact.Phone = updateContactRequest.Phone;
                contact.FullName = updateContactRequest.FullName;
                contact.Address = updateContactRequest.Address;

                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();

        }
        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<ActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            dbContext.Contacts.Remove(contact);
            await dbContext.SaveChangesAsync();
            return Ok("Success");// we can send a message 
            //we can send Ok(Contact)

        }
    }

}
