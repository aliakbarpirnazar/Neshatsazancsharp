using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.ProjectManagement;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.ProjectViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Services
{
    public class ProjectService : IProject
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;


        public ProjectService(ApplicationDbContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProjectViewModel command)
        {
            var operation = new OperationResult();
            if (Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            try
            {

            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, "Projects");
            var project = new Project()
            {
                AddressLocation = command.AddressLocation,
                StartDate = command.StartDate.ToGeorgianDateTime(),
                BudgetProject = command.BudgetProject,
                Title = command.Title,
                IsRemoved = false,
                Keywords = command.Keywords,
                LinkLocation = command.LinkLocation,
                OwnerProject = command.OwnerProject,
                Picture = pictureName,
                PictureAlt = command.PictureAlt,
                PictureTitle = command.PictureTitle,
                Slug = slug,
                TypeContract = command.TypeContract,
                Usefularea = command.Usefularea,
                TypeStructureProject = command.TypeStructureProject,
                PresenterProject = command.PresenterProject,
                NumberUnit= command.NumberUnit,
                Language= command.Language,
            };

            _context.Add(project);
            _context.SaveChanges();
            return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با ادمین سایت تماس بگیرید!");
            }
        }
        public OperationResult Edit(EditProjectViewModel command)
        {
            var operation = new OperationResult();
            Project project = Get(command.Id);

            if (project == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            try
            {

            var slug = command.Slug.Slugify();
            if (command.Picture != null)
            {
                var pictureName = _fileUploader.Upload(command.Picture, "Projects");
                project.Picture = pictureName;
            }
            project.AddressLocation = command.AddressLocation;
            project.StartDate = command.StartDate.ToGeorgianDateTime();
            project.BudgetProject = command.BudgetProject;
            project.Title = command.Title;
            project.IsRemoved = false;
            project.Keywords = command.Keywords;
            project.LinkLocation = command.LinkLocation;
            project.OwnerProject = command.OwnerProject;
            project.PictureAlt = command.PictureAlt;
            project.PictureTitle = command.PictureTitle;
            project.Slug = slug;
            project.TypeContract = command.TypeContract;
            project.Usefularea = command.Usefularea;
            project.TypeStructureProject = command.TypeStructureProject;
            project.PresenterProject = command.PresenterProject;
            project.NumberUnit = command.NumberUnit;
            project.Language = command.Language;
            _context.SaveChanges();
            return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با ادمین سایت تماس بگیرید!");
            }
        }
        public bool Exists(Expression<Func<Project, bool>> experssion)
        {
            return _context.Projects.Any(experssion);
        }
        public BaseFilterViewModel<ListProjectViewModel> GetAllProjectAdmin(int pageIndex, string search)
        {
            var sellerList = _context.Projects.Where(x => x.IsRemoved == false).OrderByDescending(x => x.Id).ToList();
            int take = 10;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.Title.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new ListProjectViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                StartDate = MyDateTime.GetShamsiDateFromGregorian(x.StartDate, false),
                Id = x.Id,
                Language=x.Language
            }).ToList();

            var outPut = PagingHelper.Pagination<ListProjectViewModel>(resault, pager);

            BaseFilterViewModel<ListProjectViewModel> res = new BaseFilterViewModel<ListProjectViewModel>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }
        public BaseFilterViewModel<ListProjectViewModel> GetDeleteProjectAdmin(int pageIndex, string search)
        {
            var sellerList = _context.Projects.Where(x => x.IsRemoved == true).OrderByDescending(x => x.Id).ToList();
            int take = 10;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.Title.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new ListProjectViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                StartDate = MyDateTime.GetShamsiDateFromGregorian(x.StartDate, false),
                Id = x.Id,
                Language= x.Language
            }).ToList();

            var outPut = PagingHelper.Pagination<ListProjectViewModel>(resault, pager);

            BaseFilterViewModel<ListProjectViewModel> res = new BaseFilterViewModel<ListProjectViewModel>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }
        public EditProjectViewModel GetDetails(long id)
        {
            return _context.Projects.Select(x => new EditProjectViewModel
            {
                Id = x.Id,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                AddressLocation = x.AddressLocation,
                BudgetProject = x.BudgetProject,
                Keywords = x.Keywords,
                LinkLocation = x.LinkLocation,
                OwnerProject = x.OwnerProject,
                PictureStr = x.Picture,
                PresenterProject = x.PresenterProject,
                StartDate = x.StartDate.ToFarsi(),
                Title = x.Title,
                TypeContract = x.TypeContract,
                TypeStructureProject = x.TypeStructureProject,
                Usefularea = x.Usefularea,
                Language=x.Language,NumberUnit = x.NumberUnit,
            }).FirstOrDefault(x => x.Id == id);
        }
        public Project Get(long id)
        {
            return _context.Projects.Find(id);
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            Project project = Get(id);
            if (project != null)
            {
                project.IsRemoved=true;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);

        }
        public OperationResult Recovery(long id)
        {
            var operation = new OperationResult();
            Project project = Get(id);
            if (project != null)
            {
                project.IsRemoved=false;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);

        }
        public int GetCount()
        {
            return _context.Projects.Where(x=>x.IsRemoved == false && x.Language=="0").Count();
        }
        public long GetSum()
        {
            return _context.Projects.Where(x => x.IsRemoved == false && x.Language=="0").Sum(x => x.NumberUnit);
        }
    }
}
