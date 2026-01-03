using Common.Domain;
using Common.Domain.Execptions;
using Shop.Domain.SellerAgg.Enums;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        public Seller(long userId, string shopName, string nationalCode, SellerStatus status)
        {
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Status = status;
            Inventories = new List<SellerInventory>();
        }

        public long UserId { get; set; }
        public string ShopName { get; set; }
        public string NationalCode { get; set; }
        public SellerStatus Status { get; private set; }
        public DateTime? LastUpdate { get; internal set; }
        public List<SellerInventory> Inventories { get; set; }

        public void AddInventory(SellerInventory inventory)
        {
            if (Inventories.Any(s => s.ProductId == inventory.ProductId && s.SellerId == inventory.SellerId))
                throw new InvalidDomainDataException("امکان درج محصول تکراری وجودد ندارد");

            Inventories.Add(inventory);
        }
        public void AddInventory(SellerInventory inventory)
        {
            var oldInventory = Inventories.FirstOrDefault(s => s.Id = inventory.Id)

            if (oldInventory == null)
                throw new InvalidDomainDataException("وجود ندارد");
            Inventories.Remove(oldInventory);
            Inventories.Add(inventory);
        }

        public void DeleteInventory(long InventoryId)
        {
            var oldInventory = Inventories.FirstOrDefault(s => s.Id = InventoryId)

            if (oldInventory == null)
                throw new InvalidDomainDataException("وجود ندارد");
            Inventories.Remove(oldInventory);

        }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Edit(string name, string nationalcode)
        {
            Guard(shopName: name, nationalcode: nationalcode);
            this.ShopName = name;
            this.NationalCode = nationalcode;
        }

        public void Guard(string shopName, string nationalcode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalcode, nameof(nationalcode));

            if (IranianNationalIdChecker.IsValid(nationalcode) == false)
                throw new InvalidDomainDataException("کدملی اشتباه است");

        }

    }


}
