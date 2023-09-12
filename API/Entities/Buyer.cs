using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string IdentificationNumber { get; set; }
        public string TaxNumber { get; set; }
        public string BankAccount1 { get; set; }
        public string BankAccount2 { get; set; }
        public string BankAccount3 { get; set; }
        public string Swift { get; set; }
        public bool IsDomestic { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}