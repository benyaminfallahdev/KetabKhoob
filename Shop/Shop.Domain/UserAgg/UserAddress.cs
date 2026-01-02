using Common.Domain;
using Common.Domain.Execptions;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        public long UserId { get; set; }

        public string Shire { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PostalAddress { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public bool ActiveAddress { get; set; } = false;
        public bool IsRemoved { get; set; } = false
        public UserAddress(string shire, string city, string postalCode, string postalAddress, string name, string family, string nationalCode)
        {
            Guard(shire, city, postalCode, postalAddress, name, family, nationalCode);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }

        public void Edit(string shire, string city, string postalCode, string postalAddress,
            string name, string family, string nationalCode)
        {
            Guard(shire, city, postalCode, postalAddress, name, family, nationalCode);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }

        public void SetActive()
        {
            ActiveAddress = true;
        }

        public void Guard(string shire, string city, string postalCode, string postalAddress,
            string name, string family, string nationalCode)

        {
            NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
            NullOrEmptyDomainDataException.CheckString(city, nameof(city));
            NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
            NullOrEmptyDomainDataException.CheckString(name, nameof(name));
            NullOrEmptyDomainDataException.CheckString(family, nameof(family));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));


            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new NullOrEmptyDomainDataException("کدملی معتبر نیست");



        }



    }
}
