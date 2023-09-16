using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.IdentityManagement
{
    public class Permission
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "عنوان دسترسی")]
        public string Title { get; set; }

        public long? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public Permission Parent { get; set; }

        public IEnumerable<RolePermission> RolePermissions { get; set; }
    }
}
