using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.IdentityManagement
{
    public class Role
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "عنوان")]
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        #region rel

        public IEnumerable<UserRole> UserRoles { get; set; }

        #endregion
    }
}
