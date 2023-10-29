using eComShop.Domain.Aggregates;
using eComShop.Domain.Common;
using eComShop.Domain.ValueObjects;
namespace eComShop.Domain.Entities
{
    public class OrderItem : CommonAttr
    {
        public OrderItemId Id { get; private set; }
        public ProductId ProductId { get; set; }
        public virtual Product Product { get; private set; }
        public int Quantity { get; private set; }
        public Money TotalPrice { get; private set; }
        public OrderId OrderId { get; private set; }
        public virtual Order Order { get; private set; }
    }
}