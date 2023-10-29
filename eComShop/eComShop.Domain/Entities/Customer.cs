using eComShop.Domain.Common;
using eComShop.Domain.ValueObjects;
namespace eComShop.Domain.Entities
{
    public class Customer : CommonAttr
    {
        public CustomerId Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Address ShippingAddress { get; set; }
    }
}