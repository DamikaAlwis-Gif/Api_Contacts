using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public int? HouseNo { get; set; }
        public string? Road {  get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
    }
}
