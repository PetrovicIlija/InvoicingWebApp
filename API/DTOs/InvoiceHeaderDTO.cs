using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class InvoiceHeaderDTO
    {
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime DocumentDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public string PlaceOfIssuance { get; set; }
        public DateTime DateOfIssuance { get; set; }
        public string FiscalNumber { get; set; }
        public BuyerDTO Buyer { get; set; }
        public int NumberOfItems { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCharged { get; set; }
        public int AppUserId { get; set; }
        public UserDTO AppUser { get; set; }
        public List<InvoiceItemDTO> InvoiceItems { get; set; } = new List<InvoiceItemDTO>();

    }
}