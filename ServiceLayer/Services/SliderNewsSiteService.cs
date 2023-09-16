using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.NewsManagement;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Admin.SliderNewsSiteViewModels;

namespace ServiceLayer.Services
{
    public class SliderNewsSiteService : ISliderNewsSite
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;


        public SliderNewsSiteService(ApplicationDbContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }
        public List<ListSliderNewsSiteViewModel> GetAllSliderAdmin(long id)
        {
            var sellerList = _context.sliderNewsSites.Include(x => x.NewsSite).Where(x => x.IsRemoved == false && x.NewsSite.Id == id).OrderByDescending(x => x.Id).ToList();



            var resault = sellerList.Select(x => new ListSliderNewsSiteViewModel
            {
                Id = x.Id,
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,

            }).ToList();

            return resault;
        }

        public OperationResult CreatePicSlide(CreateSliderNewsSiteViewModel command)
        {
            var operation = new OperationResult();
            try
            {

                var pictureName = _fileUploader.UploadMyPath(command.Picture, "SliderNewsSite");
                var project = new SliderNewsSite()
                {

                    Picture = pictureName,
                    PictureAlt = command.PictureAlt,
                    PictureTitle = command.PictureTitle,
                    IsRemoved = false,
                    NewsSiteId = command.NewsSiteId,

                };

                _context.Add(project);
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با مدیر سایت تماس بگیرید");
            }
        }
        public OperationResult EditPicSlide(EditSliderNewsSiteViewModel command)
        {
            var operation = new OperationResult();
            try
            {

                SliderNewsSite project = Get(command.Id);

                if (command.Picture != null)
                {
                    var pictureName = _fileUploader.UploadMyPath(command.Picture, "SliderNewsSite");
                    project.Picture = pictureName;
                }
                project.PictureAlt = command.PictureAlt;
                project.PictureTitle = command.PictureTitle;
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با مدیر سایت تماس بگیرید");
            }
        }
        public SliderNewsSite Get(long id)
        {
            return _context.sliderNewsSites.Find(id);
        }
        public EditSliderNewsSiteViewModel GetDetails(long id)
        {
            return _context.sliderNewsSites.Include(x => x.NewsSite).Select(x => new EditSliderNewsSiteViewModel
            {
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PictureStr = x.Picture,
                NewsSiteId = x.NewsSite.Id
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<ListSliderNewsSiteViewModel> GetAllDeleteSliderAdmin(long id)
        {
            var sellerList = _context.sliderNewsSites.Include(x => x.NewsSite).Where(x => x.IsRemoved == true && x.NewsSite.Id == id).OrderByDescending(x => x.Id).ToList();



            var resault = sellerList.Select(x => new ListSliderNewsSiteViewModel
            {
                Id = x.Id,
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,

            }).ToList();

            return resault;
        }
        public OperationResult SliderDelete(long id)
        {
            var operation = new OperationResult();
            SliderNewsSite project = Get(id);
            if (project != null)
            {
                project.IsRemoved = true;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }
        public OperationResult SliderRecovery(long id)
        {
            var operation = new OperationResult();
            SliderNewsSite project = Get(id);
            if (project != null)
            {
                project.IsRemoved = false;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

    }
}
