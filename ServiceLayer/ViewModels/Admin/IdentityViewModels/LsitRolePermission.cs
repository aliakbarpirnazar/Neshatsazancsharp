using DataLayer.Models.IdentityManagement;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayer.ViewModels.Admin.IdentityViewModels
{
    public class LsitRolePermission
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public long? ParentId { get; set; }
    }
}
