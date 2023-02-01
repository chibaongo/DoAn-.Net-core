namespace Do_AN_KTPM.Models
{
    public class Cart
    {
        public int  Id { get; set; }
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Account Account { get; set; }
        public Product Product { get; set; }
    }
}
