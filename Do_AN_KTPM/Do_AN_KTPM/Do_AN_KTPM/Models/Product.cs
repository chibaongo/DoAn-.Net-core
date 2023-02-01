using System.ComponentModel.DataAnnotations.Schema;

namespace Do_AN_KTPM.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int ProductTypeId { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public bool Status { get; set; }
        public ProductType ProductType { get; set; }
    }
}
