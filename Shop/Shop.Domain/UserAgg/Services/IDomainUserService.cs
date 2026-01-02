namespace Shop.Domain.UserAgg.Services
{
    public interface IDomainUserService
    {
        public bool PhoneNumberIsExists(string phoneNumber);
        public bool EmailIsExists(string Email);
    }
}
