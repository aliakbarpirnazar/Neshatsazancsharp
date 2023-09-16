using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.NewsManagement;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.NewsSiteViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Services
{
    public class NewsSiteService : INewsSite
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;


        public NewsSiteService(ApplicationDbContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateNewsSiteViewModel command)
        {
            var operation = new OperationResult();
            if (Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            try
            {

            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, "NewsSite");
            var NewsSite = new NewsSite()
            {
                StartDate = command.StartDate.ToGeorgianDateTime(),             
                Title = command.Title,
                IsRemoved = false,
                Keywords = command.Keywords,
                Picture = pictureName,
                PictureAlt = command.PictureAlt,
                PictureTitle = command.PictureTitle,
                Slug = slug,
                Description = command.Description,
                MetaDescription=command.MetaDescription,
                ShortDescription=command.ShortDescription,  
                Language = command.Language,
            };

            _context.Add(NewsSite);
            _context.SaveChanges();
            return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با ادمین سایت تماس بگیرید");
            }
        }
        public OperationResult Edit(EditNewsSiteViewModel command)
        {
            var operation = new OperationResult();
            try
            {

            NewsSite newsSite = Get(command.Id);

            if (newsSite == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            if (command.Picture != null)
            {
                var pictureName = _fileUploader.Upload(command.Picture, "NewsSite");
                newsSite.Picture = pictureName;
            }
            newsSite.StartDate = command.StartDate.ToGeorgianDateTime();
            newsSite.Title = command.Title;
            newsSite.IsRemoved = false;
            newsSite.Keywords = command.Keywords;
            newsSite.PictureAlt = command.PictureAlt;
            newsSite.PictureTitle = command.PictureTitle;
            newsSite.Slug = slug;
            newsSite.Description=command.Description;
            newsSite.ShortDescription = command.ShortDescription;
            newsSite.MetaDescription=command.MetaDescription;
            newsSite.Language=command.Language;
            _context.SaveChanges();
            return operation.Succedded();
            }
            catch
            {
               return operation.Failed("لطفا با مدیر سایت تماس بگیرید.");
            }
        }
        public bool Exists(Expression<Func<NewsSite, bool>> experssion)
        {
            return _context.NewsSites.Any(experssion);
        }
        public BaseFilterViewModel<ListNewsSiteViewModel> GetAllAdmin(int pageIndex, string search)
        {
            var sellerList = _context.NewsSites.Where(x => x.IsRemoved == false).OrderByDescending(x => x.Id).ToList();
            int take = 10;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.Title.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new ListNewsSiteViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                StartDate = MyDateTime.GetShamsiDateFromGregorian(x.StartDate, false),
                Id = x.Id,
                Language=x.Language,

            }).ToList();

            var outPut = PagingHelper.Pagination<ListNewsSiteViewModel>(resault, pager);

            BaseFilterViewModel<ListNewsSiteViewModel> res = new BaseFilterViewModel<ListNewsSiteViewModel>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }
        public BaseFilterViewModel<ListNewsSiteViewModel> GetDeleteAdmin(int pageIndex, string search)
        {
            var sellerList = _context.NewsSites.Where(x => x.IsRemoved == true).OrderByDescending(x => x.Id).ToList();
            int take = 10;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.Title.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new ListNewsSiteViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                StartDate = MyDateTime.GetShamsiDateFromGregorian(x.StartDate, false),
                Id = x.Id,
                Language=x.Language,

            }).ToList();

            var outPut = PagingHelper.Pagination<ListNewsSiteViewModel>(resault, pager);

            BaseFilterViewModel<ListNewsSiteViewModel> res = new BaseFilterViewModel<ListNewsSiteViewModel>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }
        public EditNewsSiteViewModel GetDetails(long id)
        {
            return _context.NewsSites.Select(x => new EditNewsSiteViewModel
            {
                Id = x.Id,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,               
                Keywords = x.Keywords,               
                PictureStr = x.Picture,                
                StartDate = x.StartDate.ToFarsi(),
                Title = x.Title,
                Description=x.Description,
                ShortDescription=x.ShortDescription,
                MetaDescription=x.MetaDescription,
                Language=x.Language,
            }).FirstOrDefault(x => x.Id == id);
        }
        public NewsSite Get(long id)
        {
            return _context.NewsSites.Find(id);
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            NewsSite NewsSite = Get(id);
            if (NewsSite != null)
            {
                NewsSite.IsRemoved=true;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);

        }
        public OperationResult Recovery(long id)
        {
            var operation = new OperationResult();
            NewsSite NewsSite = Get(id);
            if (NewsSite != null)
            {
                NewsSite.IsRemoved=false;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);

        }

    }
}
