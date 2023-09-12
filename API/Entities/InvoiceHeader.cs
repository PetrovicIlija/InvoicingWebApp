using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class InvoiceHeader
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
    public Buyer Buyer { get; set; }
    public int NumberOfItems { get; set; }
    public decimal TotalPrice => InvoiceItems.Sum(x => x.TotalPrice);
    public bool IsCharged { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    }
}