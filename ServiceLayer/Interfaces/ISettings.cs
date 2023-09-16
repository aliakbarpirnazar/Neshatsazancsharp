using _0_Framework.Application;
using ServiceLayer.ViewModels.Admin.SettingsViewModels;

namespace ServiceLayer.Interfaces
{
    public interface ISettings
    {
        SettingsViewModel GetSettingsEN();
        SettingsViewModel GetSettings();
        OperationResult UpdateSettings(SettingsViewModel model);
    }
}
