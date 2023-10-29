using eComShop.Domain.Aggregates;
using eComShop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eComShop.Domain.Services
{
    namespace ECommerce.Domain.Services
    {
        internal class DiscountService
        {
            public Money CalculateDiscount(Order order)
            {
                decimal discountAmount = 0;

                if (order.TotalBill.Amount > 100)
                {
                    discountAmount = order.TotalBill.Amount * 0.10m;
                }

                Money discount = new Money(discountAmount, order.TotalBill.Currency);

                return discount;
            }
        }
    }

}
