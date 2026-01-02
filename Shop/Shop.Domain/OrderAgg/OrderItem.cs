using Common.Domain;
using Common.Domain.Execptions;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem : BaseEntity
    {
        public long OrderId { get; set; }
        public long InventoryId { get; set; }
        public int TotalPrice => Count * Price;
        public int Price { get; set; }
        public int Count { get; set; }

        public OrderItem(long inventoryId, int price, int count)
        {
            CountGuard(count);
            PriceGuard(price);
            InventoryId = inventoryId;
            Price = price;
            Count = count;

        }

        public void ChangeCount(int newCount)

        {
            CountGuard(newCount);
            Count = newCount;
        }


        public void SetPrice(int newPrice)
        {
            PriceGuard(newPrice);
            this.Price = newPrice;
        }

        public void PriceGuard(int newPrice)
        {
            if (newPrice < 1)
                throw new InvalidDomainDataException("مبلغ کالا کم است")

        }

        public void CountGuard(int newCount)
        {
            if (newCount < 1)
                throw new InvalidDomainDataException("مبلغ کالا کم است")

        }








    }
}
