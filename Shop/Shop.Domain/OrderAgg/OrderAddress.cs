using Common.Domain;

namespace Shop.Domain.OrderAgg
{
    public class OrderAddress : BaseEntity
    {
        public long OrderId { get; set; }
        public string Shire { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PostalAddress { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public Order Order { get; set; }

        public OrderAddress(long orderId, string shire, string city, string postalCode,
            string postalAddress, string name, string family, string nationalCode)
        {
            OrderId = orderId;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }
    }
}
