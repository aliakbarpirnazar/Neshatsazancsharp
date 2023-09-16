namespace ServiceLayer.ViewModels.Admin.IdentityViewModels
{
    public class ListUserForAdminViewModel
    {
        public long UserId { get; set; }
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public string CreateDate { get; set; }
        public bool IsRemoved { get; set; }

    }
}
