using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.HeaderManagement;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.SlideViewModels;


namespace ServiceLayer.Services
{
    public class SlideService : ISlide
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;

        public SlideService(ApplicationDbContext context, IFileUploader fileUploader = null)
        {
            _context = context;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlideViewModel command)
        {
            var operation = new OperationResult();
            try
            {
                var pictureName = _fileUploader.Upload(command.Picture, "slides");

                var slide = new SlideHeader()
                {
                    Picture = pictureName,
                    PictureAlt = command.PictureAlt,
                    PictureTitle = command.PictureTitle,
                    Heading = command.PictureTitle,
                    Title = command.Title,
                    Text = command.Text,
                    Language = command.Language,IsRemoved=false
                };

                _context.Add(slide);
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با پشتیبانی سایت تماس بگیرید");
            }
        }

        public OperationResult Edit(EditSlideViewModel command)
        {
            var operation = new OperationResult();
            SlideHeader slide = Get(command.Id);

            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            try
            {
                if (command.Picture != null)
                {
                    var pictureName = _fileUploader.Upload(command.Picture, "slides");
                    slide.Picture = pictureName;
                }
                slide.Title = command.Title;
                slide.Language = command.Language;
                slide.PictureAlt = command.PictureAlt;
                slide.PictureTitle = command.PictureTitle;
                slide.Heading = command.Heading;
                slide.Text = command.Text;
                _context.SaveChanges();
                return operation.Succedded();

            }
            catch
            {
                return operation.Failed("عملیات انجام نشد لطفا با مدیر سایت تماس بگیرید.");

            }
        }

        public EditSlideViewModel GetDetails(long id)
        {
            return _context.SlideHeaders.Select(x => new EditSlideViewModel
            {
                Id = x.Id,
                Heading = x.Heading,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
                Title = x.Title,
                Language = x.Language
            }).FirstOrDefault(x => x.Id == id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slide = Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Remove();
            _context.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slide = Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Restore();
            _context.SaveChanges();
            return operation.Succedded();
        }

        public SlideHeader Get(long id)
        {
            return _context.SlideHeaders.Find(id);
        }

        public BaseFilterViewModel<SlideViewModel> GetAllAdmin(int pageIndex, string search)
        {
            var sellerList = _context.SlideHeaders.Where(x => x.IsRemoved == false).OrderByDescending(x => x.Id).ToList();
            int take = 10;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.PictureTitle.Contains(search) || x.PictureAlt.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new SlideViewModel
            {
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Heading = x.Heading,
                Picture = x.Picture,
                Language = x.Language,
            }).ToList();

            var outPut = PagingHelper.Pagination<SlideViewModel>(resault, pager);

            BaseFilterViewModel<SlideViewModel> res = new BaseFilterViewModel<SlideViewModel>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }
        public BaseFilterViewModel<SlideViewModel> GetDeleteAdmin(int pageIndex, string search)
        {
            var sellerList = _context.SlideHeaders.Where(x => x.IsRemoved == true).OrderByDescending(x => x.Id).ToList();
            int take = 10;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.PictureTitle.Contains(search) || x.PictureAlt.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new SlideViewModel
            {
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Heading = x.Heading,
                Picture = x.Picture,
                Language = x.Language,
            }).ToList();

            var outPut = PagingHelper.Pagination<SlideViewModel>(resault, pager);

            BaseFilterViewModel<SlideViewModel> res = new BaseFilterViewModel<SlideViewModel>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }
    }
}
