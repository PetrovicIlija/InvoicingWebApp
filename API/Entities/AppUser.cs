namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Byte[] PasswordHash { get; set; }
        public Byte[] PasswordSalt { get; set; }
        public List<InvoiceHeader> InvoiceHeaders { get; set; } = new List<InvoiceHeader>();
        public List<Service> Services { get; set; } = new List<Service>();
        public List<Buyer> Buyers { get; set; } = new List<Buyer>();
    }
}