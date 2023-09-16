using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.InformationManagement;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Admin.SettingsViewModels;

namespace ServiceLayer.Services
{
    public class SettingsService : ISettings
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;

        public SettingsService(ApplicationDbContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }
        public SettingsViewModel GetSettingsEN()
        {
            var setting = _context.Settings.FirstOrDefault(x=>x.Language == "1");
            SettingsViewModel model = new SettingsViewModel()
            {
                IconStr = setting.Icon,
                LogoStr = setting.Logo,
                LogoAlt = setting.LogoAlt,
                LogoTitle = setting.LogoTitle,
                SiteDesc = setting.SiteDesc,
                SiteKeys = setting.SiteKeys,
                SiteName = setting.SiteName,
                Language = setting.Language,
            };

            return model;
        }

        public SettingsViewModel GetSettings()
        {
            var setting = _context.Settings.FirstOrDefault(x=>x.Language=="0");
            SettingsViewModel model = new SettingsViewModel()
            {
                IconStr=setting.Icon,
                LogoStr=setting.Logo,
                LogoAlt=setting.LogoAlt,
                LogoTitle=setting.LogoTitle,
                SiteDesc = setting.SiteDesc,
                SiteKeys = setting.SiteKeys,
                SiteName= setting.SiteName,
                Language=setting.Language,
            };

            return model;
        }
        public OperationResult UpdateSettings(SettingsViewModel model)
        {
            var operation = new OperationResult();
            Settings siteInfo = _context.Settings.FirstOrDefault(x => x.Language == model.Language);
            try
            {
                if (model.Logo != null)
                {
                    var LogoName = _fileUploader.Upload(model.Logo, "Logo");
                    siteInfo.Logo = LogoName;
                }
                if (model.Icon != null)
                {
                    var iconName = _fileUploader.UploadIcon(model.Icon, "Icon"); 
                    siteInfo.Icon = iconName;
                }
                siteInfo.SiteDesc = model.SiteDesc;
                siteInfo.SiteKeys = model.SiteKeys;
                siteInfo.SiteName = model.SiteName;
                siteInfo.LogoAlt= model.LogoAlt;
                siteInfo.LogoTitle= model.LogoTitle;                    
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با مدیر سایت تماس بگیرید.");
            }
        }
    }
}
