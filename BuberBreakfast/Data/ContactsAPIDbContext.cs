using Microsoft.EntityFrameworkCore;
using BuberBreakfast.Models;
namespace BuberBreakfast.Data
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
