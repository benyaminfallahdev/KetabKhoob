using Common.Domain;
using Shop.Domain.UserAgg.Enums;

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

        public User(string name, string family, string phoneNumber, string password, string email, Gender gender)
        {
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


        public void Edit(string name, string family, string phoneNumber, string email, Gender gender)
        {

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

        public void EditAddress(UserAddress address)
        {
            var OldAddress = Addresses.FirstOrDefault(f => f.Id == address.Id);
            if (OldAddress == null)
                throw new NullorEmpty;

            Addresses.Remove(OldAddress);
            Addresses.Add(address);

        }


    }
    public class UserAddress : BaseEntity
    {
        public long UserId { get; set; }

    }
    public class UserRole : BaseEntity
    {

    }
    public class Wallet : BaseEntity
    {

    }
}
