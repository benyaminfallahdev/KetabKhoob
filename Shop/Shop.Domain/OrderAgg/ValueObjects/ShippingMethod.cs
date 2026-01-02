using Common.Domain;

namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class ShippingMethod : ValueObject
    {
        public string ShippinngType { get; set; }

        public int ShippingCost { get; set; }

        public ShippingMethod(string shippinngType, int shippingCost)
        {
            ShippinngType = shippinngType;
            ShippingCost = shippingCost;
        }
    }
}
