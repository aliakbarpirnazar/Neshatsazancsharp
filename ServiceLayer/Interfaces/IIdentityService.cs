using ServiceLayer.ViewModels.Admin.IdentityViewModels;
using ServiceLayer.ViewModels;
using DataLayer.Models.IdentityManagement;
using System.Linq.Expressions;
using _0_Framework.Application;

namespace ServiceLayer.Interfaces
{
    public interface IIdentityService
    {
        //For User
        BaseFilterViewModel<ListUserForAdminViewModel> GetAllUsersForAdmin(int pageIndext);
        bool Exists(Expression<Func<User, bool>> experssion);
        OperationResult AddUser(CreateUserViewModel command);
        OperationResult EditUser(EditUserViewModel command);
        OperationResult PasswordUser(PasswordUserViewModel command);
        User GetUser(long id);
        void RecoveryUser(long id);
        void DeleteUser(long id);
        User LoginByPhoneNumber(string phoneNumber, string pass);
        string GetUserDisplayName(string username);
        string GetUserPicture(string username);
        User GetUserProfile(string userName);
        string updateUser(ProfileViewModel model);
        string updateUserPass(ProfileViewModel model);
        string updateUserPic(ProfileViewModel model);


        //For Role
        BaseFilterViewModel<ListRoleViewModel> GetAllRoleForAdmin(int pageIndext);
        List<Role> GetSelectList();
        void AddRole(Role role);
        bool IsExistRoleTitle(string title);
        Role GetRole(long id);
        long GetRoleid(long id);
        void UpdateRole(long id, RoleViewModel model);
        Role SearchByTitle(string title);
        void RecoveryRole(long id);
        void DeleteRole(long id);
        string GetUserRoleName(string username);


        //For Permission
        bool CheckPerimission(long permissionId, string phoneNumber);
        public List<LsitRolePermission> GetAllPermission(long id);
        void UpdateRolePermissions(long id, long roleId, bool IsActive);

    }
}
