using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.InformationManagement;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.ChartViewModels;

namespace ServiceLayer.Services
{
    public class ChartDesignService : IChartDesign
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;

        public ChartDesignService(ApplicationDbContext context, IFileUploader fileUploader = null)
        {
            _context = context;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(CreateChartDesignViewModel command)
        {
            var operation = new OperationResult();
            try
            {
                var pictureName = _fileUploader.Upload(command.Picture, "ChartDesign");
                var project = new ChartDesign()
                {
                    Title = command.Title,
                    IsRemove = false,
                    MetaDescription = command.MetaDescription,
                    NameFamily = command.NameFamily,
                    Picture = pictureName,
                    PictureAlt = command.PictureAlt,
                    PictureTitle = command.PictureTitle,
                    SideCompany = command.SideCompany,
                    Language = command.Language,
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

        public OperationResult Edit(EditChartDesignViewModel command)
        {
            var operation = new OperationResult();
            ChartDesign project = Get(command.Id);

            if (project == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            try
            {
                if (command.Picture != null)
                {
                    var pictureName = _fileUploader.Upload(command.Picture, "ChartDesign");
                    project.Picture = pictureName;
                }
                project.Title = command.Title;
                project.IsRemove = false;
                project.MetaDescription = command.MetaDescription;
                project.NameFamily = command.NameFamily;
                project.PictureAlt = command.PictureAlt;
                project.PictureTitle = command.PictureTitle;
                project.SideCompany = command.SideCompany;
                project.Language = command.Language;
                _context.SaveChanges();
                return operation.Succedded();

            }
            catch
            {
                return operation.Failed("عملیات انجام نشد لطفا با مدیر سایت تماس بگیرید.");

            }
        }

        public ChartDesign Get(long id)
        {
            return _context.ChartDesigns.Find(id);
        }

        public BaseFilterViewModel<ChartDesignViewModel> GetAllAdmin(int pageIndex, string search)
        {
            var sellerList = _context.ChartDesigns.Where(x => x.IsRemove == false).OrderByDescending(x => x.Id).ToList();
            int take = 10;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.Title.Contains(search) || x.NameFamily.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new ChartDesignViewModel
            {
                Title = x.Title,
                IsRemove = x.IsRemove,
                Id = x.Id,
                NameFamily = x.NameFamily,
                SideCompany = x.SideCompany,
                Picture = x.Picture,
                Language= x.Language,
            }).ToList();

            var outPut = PagingHelper.Pagination<ChartDesignViewModel>(resault, pager);

            BaseFilterViewModel<ChartDesignViewModel> res = new BaseFilterViewModel<ChartDesignViewModel>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }

        public BaseFilterViewModel<ChartDesignViewModel> GetDeleteAdmin(int pageIndex, string search)
        {
            var sellerList = _context.ChartDesigns.Where(x => x.IsRemove == true).OrderByDescending(x => x.Id).ToList();
            int take = 10;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.Title.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new ChartDesignViewModel
            {
                Title = x.Title,
                IsRemove = x.IsRemove,
                Id = x.Id,
                NameFamily = x.NameFamily,
                SideCompany = x.SideCompany,
                Picture = x.Picture,
                Language = x.Language,
            }).ToList();

            var outPut = PagingHelper.Pagination<ChartDesignViewModel>(resault, pager);

            BaseFilterViewModel<ChartDesignViewModel> res = new BaseFilterViewModel<ChartDesignViewModel>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }

        public EditChartDesignViewModel GetDetails(long id)
        {
            return _context.ChartDesigns.Select(x => new EditChartDesignViewModel
            {
                Id = x.Id,
                Title = x.Title,
                MetaDescription = x.MetaDescription,
                NameFamily = x.NameFamily,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PictureStr = x.Picture,
                SideCompany = x.SideCompany,
                Language=x.Language,
            }).FirstOrDefault(x => x.Id == id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            ChartDesign project = Get(id);
            if (project != null)
            {
                project.IsRemove = true;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);

        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            ChartDesign project = Get(id);
            if (project != null)
            {
                project.IsRemove = false;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }
    }
}
