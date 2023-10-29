namespace eComShop.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 0,        // The order has been created but not yet processed.
        Processing = 1,     // The order is being prepared for shipment.
        Shipped = 2,        // The order has been shipped.
        Delivered = 3,      // The order has been successfully delivered to the customer.
        Cancelled = 4,      // The order has been canceled by the customer or the system.
        Returned = 5,       // The order has been returned by the customer.
        Refunded = 6        // The customer has been refunded for the order.
    }
}