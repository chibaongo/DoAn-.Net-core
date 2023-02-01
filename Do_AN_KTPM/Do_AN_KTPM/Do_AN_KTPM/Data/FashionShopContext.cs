using Microsoft.EntityFrameworkCore;
using Do_AN_KTPM.Models;


namespace Do_AN_KTPM.Data
{
    public class FashionShopContext:DbContext
    {
        public FashionShopContext(DbContextOptions<FashionShopContext> options)
            :base(options)
        { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
