using Common.Domain;

namespace Shop.Domain.UserAgg
{
    public class UserRole : BaseEntity
    {
        public long UserId { get; internal set; }
        public long RoleId { get; set; }

        public UserRole(long roleId)
        {
            RoleId = roleId;
        }
    }
}
