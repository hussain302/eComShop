using eComShop.Domain.Common;
using eComShop.Domain.ValueObjects;

namespace eComShop.Domain.Entities
{
    public class Product : CommonAttr
    {
        public ProductId Id { get; private set; } 
        public Money Price { get; set; }
        
        public CategoryId CategoryId { get; set; }
        public virtual Category Category { get; private set; }
        public  string? ProductImageUrl { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int StockQuantity { get; private set; }
        public string? Manufacturer { get; private set; } = string.Empty;
        public bool? IsFeatured { get; private set; }
        public bool? IsDeleted { get; private set; }
    }
}