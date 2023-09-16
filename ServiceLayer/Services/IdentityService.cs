using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.IdentityManagement;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.IdentityViewModels;
using System.Data;
using System.Linq.Expressions;

namespace ServiceLayer.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;

        public IdentityService(ApplicationDbContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }

        public BaseFilterViewModel<ListUserForAdminViewModel> GetAllUsersForAdmin(int pageIndext)
        {
            var userList = _context.Users.OrderByDescending(x => x.RegisteerTime);
            int take = 10;
            int howManyPageShow = 5;
            var pager = PagingHelper.Pager(pageIndext, userList.Count(), take, howManyPageShow);
            var result = userList.Select(x => new ListUserForAdminViewModel
            {
                CreateDate = MyDateTime.GetShamsiDateFromGregorian(x.RegisteerTime, false),
                DisplayName = x.DisplayName,
                PhoneNumber = x.PhoneNumber,
                UserId = x.UserId,
                IsRemoved = x.IsDeleted,
            }).ToList();

            var OutPut = PagingHelper.Pagination<ListUserForAdminViewModel>(result, pager);

            BaseFilterViewModel<ListUserForAdminViewModel> res = new BaseFilterViewModel<ListUserForAdminViewModel>()
            {
                EndPage = pager.EndPage,
                Entities = OutPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndext
            };

            return res;
        }
        public OperationResult AddUser(CreateUserViewModel command)
        {
            var operation = new OperationResult();
            if (Exists(x => x.PhoneNumber == command.PhoneNumber))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            try
            {

                var project = new User()
                {
                    DisplayName = command.DisplayName,
                    IsDeleted = false,
                    Avatar = "/ViewData/Profile/Default.png",
                    Password = HashGenerators.MD5Encoding(command.Password),
                    PhoneNumber = command.PhoneNumber,
                    RegisteerTime = DateTime.Now,
                };
                _context.Add(project);
                _context.SaveChanges();
                var UserRole = new UserRole()
                {
                    RoleId = command.RoleId,
                    UserId = _context.Users.FirstOrDefault(x => x.PhoneNumber == command.PhoneNumber).UserId,
                };
                _context.Add(UserRole);
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با ادمین سایت تماس بگیرید!");
            }
        }
        public OperationResult EditUser(EditUserViewModel command)
        {
            User role = GetUser(command.Id);
            UserRole userRoel = _context.UserRoles.FirstOrDefault(x => x.UserId == command.Id);
            var operation = new OperationResult();
            try
            {
                role.DisplayName = command.DisplayName;
                role.PhoneNumber = command.PhoneNumber;
                _context.Users.Update(role);
                _context.SaveChanges();
                userRoel.RoleId = command.RoleId;
                _context.UserRoles.Update(userRoel);
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با ادمین سایت تماس بگیرید!");
            }
        }
        public OperationResult PasswordUser(PasswordUserViewModel command)
        {
            User role = GetUser(command.Id);
            var operation = new OperationResult();
            try
            {
                role.Password = HashGenerators.MD5Encoding(command.pass);
                _context.Users.Update(role);
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با ادمین سایت تماس بگیرید!");
            }
        }
        public bool Exists(Expression<Func<User, bool>> experssion)
        {
            return _context.Users.Any(experssion);
        }
        public void RecoveryUser(long id)
        {
            User role = GetUser(id);
            role.IsDeleted = false;
            _context.Users.Update(role);
            _context.SaveChanges();
        }
        public void DeleteUser(long id)
        {
            User role = GetUser(id);
            role.IsDeleted = true;
            _context.Users.Update(role);
            _context.SaveChanges();
        }
        public User LoginByPhoneNumber(string phoneNumber, string pass)
        {
            return _context.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber && u.Password == HashGenerators.MD5Encoding(pass));
        }
        public User GetUser(long id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == id);
        }
        public void AddRole(Role role)
        {
            try
            {

                _context.Roles.Add(role);
                _context.SaveChanges();
            }
            catch
            {

            }
        }
        public BaseFilterViewModel<ListRoleViewModel> GetAllRoleForAdmin(int pageIndext)
        {
            var userList = _context.Roles;
            int take = 10;
            int howManyPageShow = 5;
            var pager = PagingHelper.Pager(pageIndext, userList.Count(), take, howManyPageShow);
            var result = userList.Select(x => new ListRoleViewModel
            {
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                Id = x.Id

            }).ToList();

            var OutPut = PagingHelper.Pagination<ListRoleViewModel>(result, pager);

            BaseFilterViewModel<ListRoleViewModel> res = new BaseFilterViewModel<ListRoleViewModel>()
            {
                EndPage = pager.EndPage,
                Entities = OutPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndext
            };

            return res;
        }
        public bool IsExistRoleTitle(string title)
        {
            return _context.Roles.Any(p => p.Title == title);
        }
        public Role GetRole(long id)
        {
            return _context.Roles.Include(x => x.UserRoles).FirstOrDefault(x => x.Id == id);
        }
        public long GetRoleid(long id)
        {
            return _context.UserRoles.Include(x => x.Role).FirstOrDefault(x => x.UserId == id).RoleId;
        }
        public void UpdateRole(long id, RoleViewModel model)
        {
            Role role = GetRole(id);
            role.Title = model.Title;
            role.IsDeleted = model.IsDeleted;
            _context.Roles.Update(role);
            _context.SaveChanges();
        }
        public void DeleteRole(long id)
        {
            Role role = GetRole(id);
            role.IsDeleted = true;
            _context.Roles.Update(role);
            _context.SaveChanges();
        }
        public void RecoveryRole(long id)
        {
            Role role = GetRole(id);
            role.IsDeleted = false;
            _context.Roles.Update(role);
            _context.SaveChanges();
        }
        public Role SearchByTitle(string title)
        {
            return _context.Roles.FirstOrDefault(u => u.Title == title);
        }
        public List<Role> GetSelectList()
        {
            return _context.Roles.Select(x => new Role
            {
                Id = x.Id,
                Title = x.Title,
            }).ToList();
        }
        public bool CheckPerimission(long permissionId, string phoneNumber)
        {
            long userId = _context.Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber).UserId;

            List<long> roleIds = _context.UserRoles.Where(x => x.UserId == userId).Select(x => x.RoleId).ToList();

            bool flag = false;

            if (!roleIds.Any())
            {
                flag = false;
            }
            else
            {
                foreach (int roleId in roleIds)
                {
                    foreach (var _rolePermission in _context.RolePermissions.Where(x => x.RoleId == roleId).ToList())
                    {
                        if (_rolePermission.PermissionId == permissionId)
                        {
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }
        public List<LsitRolePermission> GetAllPermission(long id)
        {
            var permission = _context.Permissions.Select(x => new LsitRolePermission
            {
                Title = x.Title,
                Id = x.Id,
                ParentId = x.ParentId,
            }
            ).ToList();

            foreach (var item in permission)
            {
                if (_context.RolePermissions.Any(x => x.RoleId == id && x.PermissionId == item.Id))
                {
                    item.IsActive = true;
                }
            }

            return permission;
        }
        public void UpdateRolePermissions(long id, long roleId, bool IsActive)
        {
            if (IsActive)
            {
                if (!_context.RolePermissions.Any(x => x.RoleId == roleId && x.PermissionId == id))
                {
                    RolePermission permission = new RolePermission
                    {
                        PermissionId = id,
                        RoleId = roleId,
                    };
                    _context.Add(permission);
                    _context.SaveChanges();
                }
            }
            else
            {
                if (_context.RolePermissions.Any(x => x.RoleId == roleId && x.PermissionId == id))
                {
                    RolePermission permission = _context.RolePermissions.First(x => x.RoleId == roleId && x.PermissionId == id);
                    _context.RolePermissions.Remove(permission);
                    _context.SaveChanges();
                }

            }

        }
        public string GetUserRoleName(string username)
        {
            var userId = _context.Users.FirstOrDefault(x => x.PhoneNumber == username).UserId;
            var userRoleId = _context.UserRoles.Include(x => x.Role).FirstOrDefault(x => x.UserId == userId).Role.Title;
            return userRoleId;


        }
        public string GetUserDisplayName(string username)
        {
            return _context.Users.FirstOrDefault(x => x.PhoneNumber == username).DisplayName;
        }
        public string GetUserPicture(string username)
        {
            return _context.Users.FirstOrDefault(x => x.PhoneNumber == username).Avatar;
        }
        public User GetUserProfile(string userName)
        {
            return _context.Users.FirstOrDefault(x => x.PhoneNumber == userName);

        }
        public string updateUser(ProfileViewModel model)
        {
            User role = GetUser(model.Id);
            if (model.PhoneNumber == role.PhoneNumber)
            {
                role.PhoneNumber = model.PhoneNumber;

            }
            else if (!_context.Users.Any(x => x.PhoneNumber == model.PhoneNumber && x.UserId == model.Id))
            {
                role.PhoneNumber = model.PhoneNumber;
            }
            role.DisplayName = model.DisplayName;
            _context.Users.Update(role);
            _context.SaveChanges();
            return role.PhoneNumber;
        }
        public string updateUserPass(ProfileViewModel model)
        {
            User role = GetUser(model.Id);
            role.Password = HashGenerators.MD5Encoding(model.Password);
            _context.Users.Update(role);
            _context.SaveChanges();
            return role.PhoneNumber;
        }
        public string updateUserPic(ProfileViewModel model)
        {
            User role = GetUser(model.Id);
            if (model.Avatarfile != null)
            {
               var picn = _fileUploader.Upload(model.Avatarfile, "Profile");
                role.Avatar = picn;
            }

            _context.Users.Update(role);
            _context.SaveChanges();
            return role.PhoneNumber;
        }
    }
}
