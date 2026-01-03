using Common.Domain;
using Common.Domain.Execptions;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Domain.RoleAgg
{
    public class Role : BaseEntity
    {

        public string Title { get; set; }

        public List<RolePermission> Permissions { get; set; }

        public Role(string title, List<RolePermission> permissions)
        {
            Title = title;
            Permissions = permissions;
        }

        public Role(string title)
        {
            Title = title;
            Permissions = new List<RolePermission>();
        }

        public Role()
        {
        }

        public void SetPermisions(List<RolePermission> rolePermissions)
        {
            this.Permissions = rolePermissions;
        }

        public void Edit(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title))
            this.Title = title;
        }

    }



}
