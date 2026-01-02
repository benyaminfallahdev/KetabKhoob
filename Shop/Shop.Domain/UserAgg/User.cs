using Common.Domain;
using Common.Domain.Execptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public List<UserRole> Roles { get; set; }
        public List<Wallet> Wallets { get; set; }
        public List<UserAddress> Addresses { get; set; }

        public User(string name, string family, string phoneNumber, string password, string email, Gender gender, IDomainUserService domainUserService)
        {
            Guard(phoneNumber, email, domainUserService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Password = password;
            Email = email;
            Gender = gender;
            //Roles = roles;
            //Wallets = wallets;
            //Addresses = addresses;
        }

        public static User RegisterUser(string email, string phoneNumber, string password, IDomainUserService domainUserService)
        {
            return new User("", "", phoneNumber, password, email, null, domainUserService);
        }
        public void Edit(string name, string family, string phoneNumber, string email, Gender gender, IDomainUserService domainUserService)
        {
            Guard(phoneNumber, email, domainUserService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public void AddAddress(UserAddress address)
        {
            address.UserId = this.Id;
            Addresses.Add(address);
        }
        public void DeleteAddress(long AddressId)
        {
            var address = Addresses.FirstOrDefault(x => x.Id == AddressId);
            if (address == null)
                throw new NullOrEmptyDomainDataException("Address Not Found");

            //address.IsRemoved = true;
            Addresses.Remove(address);

        }
        public void EditAddress(UserAddress address)
        {
            var OldAddress = Addresses.FirstOrDefault(f => f.Id == address.Id);
            if (OldAddress == null)
                throw new NullOrEmptyDomainDataException("Address Not Found");

            Addresses.Remove(OldAddress);
            Addresses.Add(address);

        }

        public void ChargeWallet(Wallet wallet)
        {

            Wallets.Add(wallet);

        }
        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(f => f.UserId = this.Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }


        public void Guard(string PhoneNumber, string Email, IDomainUserService domainUserService)

        {
            NullOrEmptyDomainDataException.CheckString(PhoneNumber, nameof(PhoneNumber));
            NullOrEmptyDomainDataException.CheckString(Email, nameof(Email));

            if (PhoneNumber.Length = !11)
                throw new InvalidDomainDataException("PhoneNumber is Not Valid");

            if (Email.IsValidEmail == false)
                throw new InvalidDomainDataException("Email is not Valid");

            if (PhoneNumber != this.PhoneNumber)
                if (domainUserService.PhoneNumberIsExists(PhoneNumber))
                    throw new InvalidDomainDataException("شماره تلفن از قبل در سیستم وجود دارد");

            if (Email != this.Email)
                if (domainUserService.EmailIsExists(Email))
                    throw new InvalidDomainDataException("آدرس ایمیل از قبل در سیستم وجود دارد");
        }

    }
}
