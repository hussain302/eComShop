using eComShop.Domain.Common;
namespace eComShop.Domain.Dtos
{
    public class CategoryDto : CommonAttr
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}