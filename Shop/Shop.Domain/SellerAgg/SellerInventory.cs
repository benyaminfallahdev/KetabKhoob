using Common.Domain;
using Common.Domain.Execptions;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory : BaseEntity
    {
        public SellerInventory(long productId, int count, int price)
        {
            if (price < 1 || count < 0)
                throw new InvalidDomainDataException("تعداد یا مبلغ درست نیست");
            ProductId = productId;
            Count = count;
            Price = price;
        }

        public long SellerId { get; set; }

        public long ProductId { get; set; }
        public int Count { get; set; }

        public int Price { get; set; }

    }


}
