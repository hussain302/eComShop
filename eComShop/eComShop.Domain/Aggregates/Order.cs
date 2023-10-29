using eComShop.Domain.Common;
using eComShop.Domain.Entities;
using eComShop.Domain.Enums;
using eComShop.Domain.ValueObjects;

namespace eComShop.Domain.Aggregates
{
    public class Order : CommonAttr
    {
        public OrderId Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatus OrderStatus { get; private set; } 
        public string PaymentMethod { get; private set; } = string.Empty;
        public DateTime ExpectedDeliveryDate { get; private set; } 
        public string OrderNotes { get; private set; } = string.Empty;
        public string TrackingNumber { get; private set; } = string.Empty;
        public bool IsPaid { get; private set; }
        public virtual List<OrderItem> OrderItems { get; private set; }
        public Address ShippingAddress { get; private set; }
        public Money TotalBill { get; private set; }
        public CustomerId CustomerId { get; set; }
        public virtual Customer Customer { get; private set; }
    }
}
