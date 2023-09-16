using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.PodcastManagement;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.PodcastViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Services
{
    public class PodcastService : IPodcast
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;


        public PodcastService(ApplicationDbContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreatePodcastViewModel command)
        {
            var operation = new OperationResult();
            if (Exists(x => x.PictureTitle == command.PictureTitle && x.Language==command.Language))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            try
            {
                var slug = command.Slug.Slugify();
                var videoName = _fileUploader.Upload(command.Video, "Podcast");
                var pictureName = _fileUploader.Upload(command.Picture, "Podcast");
                var project = new Podcast()
                {
                    Title = command.Title,
                    IsRemoved = false,
                    Video = videoName,
                    Picture=pictureName,
                    PictureAlt = command.PictureAlt,
                    PictureTitle = command.PictureTitle,
                    Slug = slug,
                    Language=command.Language,
                };
                _context.Add(project);
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("عملیات انجام نشد لطفا با مدیر سایت تماس بگیرید.");
            }
        }
        public OperationResult Edit(EditPodcastViewModel command)
        {
            var operation = new OperationResult();
            Podcast project = Get(command.Id);

            if (project == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (Exists(x => x.Title == command.Title && x.Id != command.Id && x.Language==command.Language))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            if (command.Video != null)
            {
                var videoName = _fileUploader.Upload(command.Video, "Podcast");
                project.Video = videoName;
            } 
            if (command.Picture != null)
            {
                var pictureName = _fileUploader.Upload(command.Picture, "Podcast");
                project.Picture = pictureName;
            }
            project.Title = command.Title;
            project.IsRemoved = false;
            project.PictureAlt = command.PictureAlt;
            project.PictureTitle = command.PictureTitle;
            project.Slug = slug;
            project.Language=command.Language;
            _context.SaveChanges();
            return operation.Succedded();
        }
        public bool Exists(Expression<Func<Podcast, bool>> experssion)
        {
            return _context.Podcasts.Any(experssion);
        }
        public BaseFilterViewModel<ListPodcastViewModel> GetAllAdmin(int pageIndex, string search)
        {
            var sellerList = _context.Podcasts.Where(x => x.IsRemoved == false).OrderByDescending(x => x.Id).ToList();
            int take = 10;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.Title.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new ListPodcastViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                Id = x.Id,
                Language = x.Language,
            }).ToList();

            var outPut = PagingHelper.Pagination<ListPodcastViewModel>(resault, pager);

            BaseFilterViewModel<ListPodcastViewModel> res = new BaseFilterViewModel<ListPodcastViewModel>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }
        public BaseFilterViewModel<ListPodcastViewModel> GetDeleteAdmin(int pageIndex, string search)
        {
            var sellerList = _context.Podcasts.Where(x => x.IsRemoved == true).OrderByDescending(x => x.Id).ToList();
            int take = 10;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.Title.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new ListPodcastViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                Id = x.Id,
                Language=x.Language,
            }).ToList();

            var outPut = PagingHelper.Pagination<ListPodcastViewModel>(resault, pager);

            BaseFilterViewModel<ListPodcastViewModel> res = new BaseFilterViewModel<ListPodcastViewModel>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }
        public EditPodcastViewModel GetDetails(long id)
        {
            return _context.Podcasts.Select(x => new EditPodcastViewModel
            {
                Id = x.Id,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                videoStr = x.Video,
                Language = x.Language,
                pictureStr=x.Picture,
                
            }).FirstOrDefault(x => x.Id == id);
        }
        public Podcast Get(long id)
        {
            return _context.Podcasts.Find(id);
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            Podcast project = Get(id);
            if (project != null)
            {
                project.IsRemoved = true;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);

        }
        public OperationResult Recovery(long id)
        {
            var operation = new OperationResult();
            Podcast project = Get(id);
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
