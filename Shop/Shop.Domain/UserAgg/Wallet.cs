using Common.Domain;
using Common.Domain.Execptions;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Domain.UserAgg
{
    public class Wallet : BaseEntity
    {
        public long UserId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool IsFinally { get; set; } = false;
        public DateTime? FinallyDate { get; set; }

        public WalletType Type { get; set; }

        public Wallet(int price, string description, bool isFinally, DateTime? finallyDate, WalletType type)
        {
            if (price < 500)
                throw new InvalidDomainDataException();
            Price = price;
            Description = description;
            IsFinally = isFinally;
            FinallyDate = finallyDate;
            Type = type;
        }

        public void Finally(string refcode)
        {
            FinallyDate = DateTime.Now;
            IsFinally = true;

            Description += $"کد پیگیری :{refcode}"

        }

        public void Finally()
        {
            FinallyDate = DateTime.Now;
            IsFinally = true;

        }

    }
}
