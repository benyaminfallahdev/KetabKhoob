using Common.Domain;

namespace Shop.Domain.RoleAgg.Enums
{
    public class RolePermission : BaseEntity
    {
        public long RoleId { get; set; }
        public Permission Permission { get; set; }
    }



}
