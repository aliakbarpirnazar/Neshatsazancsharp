using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.InformationManagement;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Admin.ChartViewModels;

namespace ServiceLayer.Services
{
    public class ChartPictureService : IchartPicture
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;

        public ChartPictureService(ApplicationDbContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }

        public ChartPictureViewModel GetChartPictureEN()
        {
            var Siteinfo = _context.ChartPictures.FirstOrDefault(x=>x.Language=="1");
            ChartPictureViewModel model = new ChartPictureViewModel()
            {
                PictureStr = Siteinfo.Picture,               
                PictureAlt = Siteinfo.PictureAlt,
                PictureTitle = Siteinfo.PictureTitle,  
                Language = Siteinfo.Language,
            };

            return model;
        }
        public ChartPictureViewModel GetChartPicture()
        {
            var Siteinfo = _context.ChartPictures.FirstOrDefault(x=>x.Language=="0");
            ChartPictureViewModel model = new ChartPictureViewModel()
            {
                PictureStr = Siteinfo.Picture,               
                PictureAlt = Siteinfo.PictureAlt,
                PictureTitle = Siteinfo.PictureTitle,  
                Language = Siteinfo.Language,
            };

            return model;
        }

        public OperationResult UpdateChartPicture(ChartPictureViewModel model)
        {
            var operation = new OperationResult();
            ChartPicture siteInfo = _context.ChartPictures.FirstOrDefault(x => x.Language == model.Language);
            try
            {
                if (model.Picture != null)
                {
                    var pictureName = _fileUploader.Upload(model.Picture, "ChartPicture");
                    siteInfo.Picture = pictureName;
                }
                siteInfo.PictureAlt = model.PictureAlt;
                siteInfo.PictureTitle = model.PictureTitle;              
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
