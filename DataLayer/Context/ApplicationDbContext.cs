using _0_Framework.Application;
using DataLayer.Models.AskedQuestionsManagement;
using DataLayer.Models.BlogManagement;
using DataLayer.Models.CertificateManagement;
using DataLayer.Models.HeaderManagement;
using DataLayer.Models.IdentityManagement;
using DataLayer.Models.InformationManagement;
using DataLayer.Models.NewsManagement;
using DataLayer.Models.PodcastManagement;
using DataLayer.Models.ProjectManagement;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{ }

		//Project Management
		public DbSet<Project> Projects { get; set; }
		public DbSet<SliderProject> SliderProjects { get; set; }


		//NewsSiteManagement
		public DbSet<NewsSite> NewsSites { get; set; }
		public DbSet<SliderNewsSite> sliderNewsSites { get; set; }
		public DbSet<VideoNewsSite> videoNewsSites { get; set; }


		//AskedQuestionsManagement
		public DbSet<AskedQuestion> AskedQuestions { get; set; }


		//CertificateManagement
		public DbSet<Certificate> Certificates { get; set; }

		//PodcastManagement
		public DbSet<Podcast> Podcasts { get; set; }

		//BlogManagement
		public DbSet<Article> Articles { get; set; }
		public DbSet<ArticleCategory> ArticleCategories { get; set; }

		//InformationManageMent
		public DbSet<SiteInfo> SiteInfos { get; set; }
		public DbSet<ChartDesign> ChartDesigns { get; set; }
		public DbSet<ChartPicture> ChartPictures { get; set; }
		public DbSet<Settings> Settings { get; set; }
		public DbSet<Visit> Visits { get; set; }

		//HeaderManageMent
		public DbSet<SlideHeader> SlideHeaders { get; set; }

		//IdentityManageMent
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<RolePermission> RolePermissions { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }






		//DataSeed
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<SiteInfo>().HasData(new SiteInfo { Id = 1, Address = "قم", CreationDate = DateTime.Now, Description = "", LinkLocation = "", MetaDescription = "", MissionCompany = "", Picture = "", PictureAlt = "", PictureTitle = "", Qusetion = "", ShortDescription = "", TelNumber = "", TimeRun = "", VisionCompany = "", Language = "0" });
			modelBuilder.Entity<SiteInfo>().HasData(new SiteInfo { Id = 2, Address = "Qom", CreationDate = DateTime.Now, Description = "", LinkLocation = "", MetaDescription = "", MissionCompany = "", Picture = "", PictureAlt = "", PictureTitle = "", Qusetion = "", ShortDescription = "", TelNumber = "", TimeRun = "", VisionCompany = "", Language = "1" });
			modelBuilder.Entity<ChartPicture>().HasData(new ChartPicture { Id = 1, CreationDate = DateTime.Now, Picture = "", PictureAlt = "", PictureTitle = "", Language = "0" });
			modelBuilder.Entity<ChartPicture>().HasData(new ChartPicture { Id = 2, CreationDate = DateTime.Now, Picture = "", PictureAlt = "", PictureTitle = "", Language = "1" });
			modelBuilder.Entity<Settings>().HasData(new Settings { Id = 1, CreationDate = DateTime.Now, Icon = "", Logo = "", LogoAlt = "", LogoTitle = "", SiteDesc = "", SiteKeys = "", SiteName = "", Language = "0" });
			modelBuilder.Entity<Settings>().HasData(new Settings { Id = 2, CreationDate = DateTime.Now, Icon = "", Logo = "", LogoAlt = "", LogoTitle = "", SiteDesc = "", SiteKeys = "", SiteName = "", Language = "1" });

			//DataSeed User And Permission And Role
			modelBuilder.Entity<User>().HasData(new User { UserId = 1, RegisteerTime = DateTime.Now, Password = HashGenerators.MD5Encoding("123456"), Avatar = "/ViewData/Profile/Default.png", PhoneNumber = "09128541094", DisplayName = "کاربر ادمین", IsDeleted = false });
			modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Title = "مدیر", IsDeleted = false });
			modelBuilder.Entity<UserRole>().HasData(new UserRole { Id = 1, UserId = 1, RoleId = 1 });

			//Dashboard Panel Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 1, Title = "دسترسی به پنل ادمین" });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 1, PermissionId = 1, RoleId = 1 });

			//Slider Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 2, Title = "دسترسی به اسلایدر" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 16, Title = "ایجاد", ParentId = 2 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 17, Title = "ویرایش", ParentId = 2 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 18, Title = "حذف", ParentId = 2 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 19, Title = "بازگردانی", ParentId = 2 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 20, Title = "نمایش حذف شده ها", ParentId = 2 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 2, PermissionId = 2, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 3, PermissionId = 16, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 4, PermissionId = 17, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 5, PermissionId = 18, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 6, PermissionId = 19, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 7, PermissionId = 20, RoleId = 1 });

			//Projects Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 3, Title = "دسترسی به پروژه ها" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 21, Title = "ایجاد", ParentId = 3 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 22, Title = "ویرایش", ParentId = 3 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 23, Title = "حذف", ParentId = 3 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 24, Title = "بازگردانی", ParentId = 3 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 25, Title = "نمایش حذف شده ها", ParentId = 3 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 26, Title = "ایجاد اسلایدر پروژه", ParentId = 3 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 27, Title = "ویرایش اسلایدر پروژه ", ParentId = 3 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 28, Title = "حذف اسلایدر پروژه", ParentId = 3 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 29, Title = "بازگردانی اسلایدر پروژه", ParentId = 3 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 30, Title = "نمایش اسلایدر پروژه حذف شده ها", ParentId = 3 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 31, Title = "نمایش اسلایدر پروژه ها", ParentId = 3 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 8, PermissionId = 3, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 9, PermissionId = 21, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 10, PermissionId = 22, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 11, PermissionId = 23, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 12, PermissionId = 24, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 13, PermissionId = 25, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 14, PermissionId = 26, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 15, PermissionId = 27, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 16, PermissionId = 28, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 17, PermissionId = 29, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 18, PermissionId = 30, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 19, PermissionId = 31, RoleId = 1 });

			//Question Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 4, Title = "دسترسی به اسلایدر" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 32, Title = "ایجاد", ParentId = 4 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 33, Title = "ویرایش", ParentId = 4 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 34, Title = "حذف", ParentId = 4 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 35, Title = "بازگردانی", ParentId = 4 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 36, Title = "نمایش حذف شده ها", ParentId = 4 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 20, PermissionId = 4, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 21, PermissionId = 32, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 22, PermissionId = 33, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 23, PermissionId = 34, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 24, PermissionId = 35, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 25, PermissionId = 36, RoleId = 1 });

			//NewsSite Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 5, Title = "دسترسی به اخبار" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 37, Title = "ایجاد", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 38, Title = "ویرایش", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 39, Title = "حذف", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 40, Title = "بازگردانی", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 41, Title = "نمایش حذف شده ها", ParentId = 5 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 26, PermissionId = 5, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 27, PermissionId = 37, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 28, PermissionId = 38, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 29, PermissionId = 39, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 30, PermissionId = 40, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 31, PermissionId = 41, RoleId = 1 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 42, Title = "نمایش اسلایدر خبر", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 43, Title = "ایجاداسلایدر خبر", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 44, Title = "ویرایش اسلایدر خبر", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 45, Title = "حذف اسلایدر خبر", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 46, Title = "بازگردانی اسلایدر خبر", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 47, Title = "نمایش اسلایدر خبر حذف شده ها", ParentId = 5 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 32, PermissionId = 42, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 33, PermissionId = 43, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 34, PermissionId = 44, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 35, PermissionId = 45, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 36, PermissionId = 46, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 37, PermissionId = 47, RoleId = 1 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 48, Title = "نمایش ویدیو خبر", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 49, Title = "ایجاد ویدیو خبر", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 50, Title = "ویرایش ویدیو خبر", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 51, Title = "حذف ویدیو خبر", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 52, Title = "بازگردانی ویدیو خبر", ParentId = 5 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 53, Title = "نمایش ویدیو خبر حذف شده ها", ParentId = 5 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 38, PermissionId = 48, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 39, PermissionId = 49, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 40, PermissionId = 50, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 41, PermissionId = 51, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 42, PermissionId = 52, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 43, PermissionId = 53, RoleId = 1 });

			//Certificate Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 6, Title = "دسترسی به افتخارات و گواهینامه ها" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 54, Title = "ایجاد", ParentId = 6 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 55, Title = "ویرایش", ParentId = 6 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 56, Title = "حذف", ParentId = 6 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 57, Title = "بازگردانی", ParentId = 6 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 58, Title = "نمایش حذف شده ها", ParentId = 6 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 44, PermissionId = 6, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 45, PermissionId = 54, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 46, PermissionId = 55, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 47, PermissionId = 56, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 48, PermissionId = 57, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 49, PermissionId = 58, RoleId = 1 });

			//Podcast Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 7, Title = "دسترسی به کلیپ ها و پادکست ها" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 59, Title = "ایجاد", ParentId = 7 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 60, Title = "ویرایش", ParentId = 7 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 61, Title = "حذف", ParentId = 7 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 62, Title = "بازگردانی", ParentId = 7 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 63, Title = "نمایش حذف شده ها", ParentId = 7 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 50, PermissionId = 7, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 51, PermissionId = 59, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 52, PermissionId = 60, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 53, PermissionId = 61, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 54, PermissionId = 62, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 55, PermissionId = 63, RoleId = 1 });

			//ChartDesign Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 8, Title = "دسترسی به چارت سازمانی" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 64, Title = "ایجاد", ParentId = 8 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 65, Title = "ویرایش", ParentId = 8 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 66, Title = "حذف", ParentId = 8 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 67, Title = "بازگردانی", ParentId = 8 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 68, Title = "نمایش حذف شده ها", ParentId = 8 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 56, PermissionId = 8, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 57, PermissionId = 64, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 58, PermissionId = 65, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 59, PermissionId = 66, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 60, PermissionId = 67, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 61, PermissionId = 68, RoleId = 1 });

			//ChartPicture Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 9, Title = "دسترسی به تصویر چارت سازمانی" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 69, Title = "ویرایش", ParentId = 9 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 62, PermissionId = 9, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 63, PermissionId = 69, RoleId = 1 });

			//ArticleCategory Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 10, Title = "دسترسی به گروه مقالات" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 70, Title = "ایجاد", ParentId = 10 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 71, Title = "ویرایش", ParentId = 10 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 72, Title = "حذف", ParentId = 10 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 73, Title = "بازگردانی", ParentId = 10 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 64, PermissionId = 10, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 65, PermissionId = 70, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 66, PermissionId = 71, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 67, PermissionId = 72, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 68, PermissionId = 73, RoleId = 1 });

			//Article Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 11, Title = "دسترسی به مقالات" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 74, Title = "ایجاد", ParentId = 11 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 75, Title = "ویرایش", ParentId = 11 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 76, Title = "حذف", ParentId = 11 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 77, Title = "بازگردانی", ParentId = 11 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 69, PermissionId = 11, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 70, PermissionId = 74, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 71, PermissionId = 75, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 72, PermissionId = 76, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 73, PermissionId = 77, RoleId = 1 });

			//Account Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 12, Title = "دسترسی به کاربران" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 78, Title = "ایجاد", ParentId = 12 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 79, Title = "ویرایش", ParentId = 12 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 80, Title = "حذف", ParentId = 12 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 81, Title = "بازگردانی", ParentId = 12 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 82, Title = "تغییر کلمه عبور کاربران", ParentId = 12 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 74, PermissionId = 12, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 75, PermissionId = 78, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 76, PermissionId = 79, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 77, PermissionId = 80, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 78, PermissionId = 81, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 79, PermissionId = 82, RoleId = 1 });

			//Role Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 13, Title = "دسترسی به نقش ها" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 84, Title = "ایجاد", ParentId = 13 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 85, Title = "ویرایش", ParentId = 13 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 86, Title = "حذف", ParentId = 13 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 87, Title = "بازگردانی", ParentId = 13 });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 88, Title = "تعیین سطح دسترسی نقش ", ParentId = 13 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 81, PermissionId = 13, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 82, PermissionId = 84, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 83, PermissionId = 85, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 84, PermissionId = 86, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 85, PermissionId = 87, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 86, PermissionId = 88, RoleId = 1 });

			//Setting Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 14, Title = "دسترسی به تنظیمات سایت" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 89, Title = "ویرایش تنظیمات سایت", ParentId = 14 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 87, PermissionId = 14, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 88, PermissionId = 89, RoleId = 1 });

			//SiteInfo Permission
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 15, Title = "دسترسی به درباره ما" });
			modelBuilder.Entity<Permission>().HasData(new Permission { Id = 90, Title = "ویرایش درباره ما", ParentId = 15 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 89, PermissionId = 15, RoleId = 1 });
			modelBuilder.Entity<RolePermission>().HasData(new RolePermission { Id = 90, PermissionId = 90, RoleId = 1 });







		}









	}
}
