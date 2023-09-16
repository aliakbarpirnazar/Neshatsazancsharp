using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.InformationManagement;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Admin.SiteInfoViewModels;

namespace ServiceLayer.Services
{
    public class SiteInfoService : ISiteInfo
    {
        private readonly ApplicationDbContext _context;

        private readonly IFileUploader _fileUploader;

        public SiteInfoService(ApplicationDbContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }
        public SiteInfoViewModel GetSiteInfoEN()
        {
            var Siteinfo = _context.SiteInfos.FirstOrDefault(x => x.Language == "1");
            SiteInfoViewModel model = new SiteInfoViewModel()
            {
                Address = Siteinfo.Address,
                LinkLocation = Siteinfo.LinkLocation,
                Description = Siteinfo.Description,
                PictureStr = Siteinfo.Picture,
                MetaDescription = Siteinfo.MetaDescription,
                MissionCompany = Siteinfo.MissionCompany,
                PictureAlt = Siteinfo.PictureAlt,
                PictureTitle = Siteinfo.PictureTitle,
                Qusetion = Siteinfo.Qusetion,
                ShortDescription = Siteinfo.ShortDescription,
                TelNumber = Siteinfo.TelNumber,
                TimeRun = Siteinfo.TimeRun,
                VisionCompany = Siteinfo.VisionCompany,
                Linkinstagram = Siteinfo.Linkinstagram,
                LinkTelegram=Siteinfo.LinkTelegram,
                LinkWhatsApp=Siteinfo.LinkWhatsApp,
                Language=Siteinfo.Language,
            };

            return model;
        }
        public SiteInfoViewModel GetSiteInfo()
        {
            var Siteinfo = _context.SiteInfos.FirstOrDefault(x=>x.Language=="0");
            SiteInfoViewModel model = new SiteInfoViewModel()
            {
                Address = Siteinfo.Address,
                LinkLocation = Siteinfo.LinkLocation,
                Description = Siteinfo.Description,
                PictureStr = Siteinfo.Picture,
                MetaDescription = Siteinfo.MetaDescription,
                MissionCompany = Siteinfo.MissionCompany,
                PictureAlt = Siteinfo.PictureAlt,
                PictureTitle = Siteinfo.PictureTitle,
                Qusetion = Siteinfo.Qusetion,
                ShortDescription = Siteinfo.ShortDescription,
                TelNumber = Siteinfo.TelNumber,
                TimeRun = Siteinfo.TimeRun,
                VisionCompany = Siteinfo.VisionCompany,
                Language=Siteinfo.Language,
                Linkinstagram = Siteinfo.Linkinstagram,
                LinkTelegram = Siteinfo.LinkTelegram,
                LinkWhatsApp = Siteinfo.LinkWhatsApp,
            };

            return model;
        }

        public OperationResult UpdateSiteInfo(SiteInfoViewModel model)
        {
            var operation = new OperationResult();
            SiteInfo siteInfo = _context.SiteInfos.FirstOrDefault(x=>x.Language==model.Language);
            try
            {
                if (model.Picture != null)
                {
                    var pictureName = _fileUploader.Upload(model.Picture, "PictureSiteInfo");
                    siteInfo.Picture = pictureName;
                }
                siteInfo.Address = model.Address;
                siteInfo.LinkLocation = model.LinkLocation;
                siteInfo.Description = model.Description;
                siteInfo.MetaDescription = model.MetaDescription;
                siteInfo.MissionCompany = model.MissionCompany;
                siteInfo.PictureAlt = model.PictureAlt;
                siteInfo.PictureTitle = model.PictureTitle;
                siteInfo.Qusetion = model.Qusetion;
                siteInfo.ShortDescription = model.ShortDescription;
                siteInfo.TelNumber = model.TelNumber;
                siteInfo.TimeRun = model.TimeRun;
                siteInfo.VisionCompany = model.VisionCompany;
                siteInfo.Language = model.Language;
                siteInfo.Linkinstagram = model.Linkinstagram;
                siteInfo.LinkTelegram= model.LinkTelegram;
                siteInfo.LinkWhatsApp=model.LinkWhatsApp;
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

