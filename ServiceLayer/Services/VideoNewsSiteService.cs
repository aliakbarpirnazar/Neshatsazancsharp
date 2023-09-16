using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.NewsManagement;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.Admin.VideoNewsSiteViewModels;

namespace ServiceLayer.Services
{
    public class VideoNewsSiteService : IVideoNewsSite
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;


        public VideoNewsSiteService(ApplicationDbContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }
        public List<ListVideoNewsSiteViewModel> GetAllAdmin(long id)
        {
            var sellerList = _context.videoNewsSites.Include(x => x.NewsSite).Where(x => x.IsRemoved == false && x.NewsSite.Id == id).OrderByDescending(x => x.Id).ToList();



            var resault = sellerList.Select(x => new ListVideoNewsSiteViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                Id = x.Id,

            }).ToList();

            return resault;
        }

        public OperationResult CreateVideo(CreateVideoNewsSiteViewModel command)
        {
            var operation = new OperationResult();
            try
            {

                var slug = command.Slug.Slugify();
                var pictureName = _fileUploader.Upload(command.video, "SliderNewsSite");
                var project = new VideoNewsSite()
                {

                    Title = command.Title,
                    IsRemoved = false,
                    Video = pictureName,
                    VideoAlt = command.videoAlt,
                    VideoTitle = command.videoTitle,
                    Slug = slug,
                    NewsSiteId = command.NewsSiteId,
                };

                _context.Add(project);
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با مدیر سایت تماس بگیرید.");
            }
        }

        public OperationResult EditVideo(EditVideoNewsSiteViewModel command)
        {
            var operation = new OperationResult();
            try
            {
                VideoNewsSite project = Get(command.Id);

                var slug = command.Slug.Slugify();
               if(command.video != null)
                {
                    var videoName = _fileUploader.Upload(command.video, "SliderNewsSite");
                    project.Video = videoName;
                }
                project.IsRemoved = false;
                project.VideoAlt = command.VideoAlt;
                project.VideoTitle = command.videoTitle;
                project.Slug = slug;
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با مدیر سایت تماس بگیرید.");
            }
        }
        public VideoNewsSite Get(long id)
        {
            return _context.videoNewsSites.Find(id);
        }

        public EditVideoNewsSiteViewModel GetDetails(long id)
        {
            return _context.videoNewsSites.Include(x => x.NewsSite).Select(x => new EditVideoNewsSiteViewModel
            {
                Id = x.Id,
                Slug = x.Slug,
                VideoAlt = x.VideoAlt,
                videoTitle = x.VideoTitle,
                Title = x.Title,
                videoStr = x.Video,
                NewsSiteId = x.NewsSite.Id
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ListVideoNewsSiteViewModel> GetAllDeleteAdmin(long id)
        {
            var sellerList = _context.videoNewsSites.Include(x => x.NewsSite).Where(x => x.IsRemoved == true && x.NewsSite.Id == id).OrderByDescending(x => x.Id).ToList();

            var resault = sellerList.Select(x => new ListVideoNewsSiteViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                Id = x.Id,

            }).ToList();

            return resault;
        }

        public OperationResult VideoDelete(long id)
        {
            var operation = new OperationResult();
            VideoNewsSite project = Get(id);
            if (project != null)
            {
                project.IsRemoved = true;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

        public OperationResult VideoRecovery(long id)
        {
            var operation = new OperationResult();
            VideoNewsSite project = Get(id);
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
