
using Common.Domain;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class OrderDiscount : ValueObject
    {
        public string DiscountTitle { get; set; }

        public int DiscountAmmount { get; set; }

        public OrderDiscount(string discountTitle, int discountAmmount)
        {
            DiscountTitle = discountTitle;
            DiscountAmmount = discountAmmount;
        }
    }
}
