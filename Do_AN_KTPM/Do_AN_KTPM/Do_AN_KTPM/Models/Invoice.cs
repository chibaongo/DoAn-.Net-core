using System.Reflection.PortableExecutable;

namespace Do_AN_KTPM.Models
{ 
    public class Invoice
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int AccountId { get; set; }
        public DateTime IssuedDate { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingPhone { get; set; }
        public int Total { get; set; }
        public bool Status { get; set; }

        public Account Account { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
