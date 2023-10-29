using eComShop.Domain.Common;
using eComShop.Domain.ValueObjects;
namespace eComShop.Domain.Entities
{
    public class Category : CommonAttr
    {

        public CategoryId Id { get; set; }
        public string Name { get;set; } = string.Empty;
        public string? Description { get;set; } = string.Empty;
        public virtual List<Product> Products { get; set; }
    }
}