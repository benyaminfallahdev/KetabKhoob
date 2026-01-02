using Common.Domain;
using Common.Domain.Execptions;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Domain.OrderAgg
{
    public class Order : BaseEntity
    {
        public long UserId { get; set; }

        private Order()
        {

        }

        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }

        public OrderStatus Status { get; set; }
        public OrderDiscount? Discount { get; set; }
        public OrderAddress? Address { get; set; }
        public DateTime? LastUpdate { get; set; }
        public ShippingMethod? ShippingMethod { get; set; }
        public List<OrderItem> Items { get; set; }
        //public int TotalPrice => Items.Sum(s => s.TotalPrice);
        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(s => s.TotalPrice);

                if (ShippingMethod != null)
                    totalPrice += ShippingMethod.ShippingCost;

                if (Discount != null)
                    totalPrice -= Discount.DiscountAmmount;
            }
        }
        public int ItemCount => Items.Count;

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(long itemid)
        {
            var currentItem = this.Items.FirstOrDefault(x => x.Id == itemid);
            if (currentItem != null)
                Items.Remove(currentItem);
        }
        public void ChangeCountItem(long itemid, int newCount)
        {
            var currentItem = this.Items.FirstOrDefault(x => x.Id == itemid);
            if (currentItem == null)
                throw new InvalidDomainDataException("سفارش مورد نظر یافت نشد");

            currentItem.ChangeCount(newCount);
        }

        public void ChangeStatus(OrderStatus status)
        {
            this.Status = status;
            this.LastUpdate = DateTime.Now;
        }

        //برای زمانی که قراره سفارش کامل بشه
        //باید همه چی دوباره بررسی بشه که توی دیتابیس تغییر نکرده باشه
        public void Checkout(OrderAddress orderAddress)
        {
            this.Address = orderAddress;

        }

    }
}

