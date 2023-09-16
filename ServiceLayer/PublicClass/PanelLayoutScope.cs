using ServiceLayer.Interfaces;

namespace ServiceLayer.PublicClass
{
    public class PanelLayoutScope
    {
        private readonly IIdentityService _identityService;
        private readonly ISettings _setting;

        public PanelLayoutScope(IIdentityService identityService, ISettings setting)
        {
            _identityService = identityService;
            _setting = setting;
        }

        public string GetUserRoleName(string username)
        {
            return _identityService.GetUserRoleName(username);
        }
        public string GetUserDisplayName(string username)
        {
            return _identityService.GetUserDisplayName(username);
        }
        public string GetUserPicture(string username)
        {
            return _identityService.GetUserPicture(username);
        }
        public string GetSiteName()
        {
            var r = _setting.GetSettingsEN();
            return r.SiteName;
        } 
        public string GetSiteLogo()
        {
            var r = _setting.GetSettings();
            return r.LogoStr;
        }


    }
}
