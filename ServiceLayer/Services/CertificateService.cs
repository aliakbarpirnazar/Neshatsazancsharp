using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.CertificateManagement;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.CertificateViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Services
{
    public class CertificateService : ICertificate
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;


        public CertificateService(ApplicationDbContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateCertificateViewModel command)
        {
            var operation = new OperationResult();
            if (Exists(x => x.PictureTitle == command.PictureTitle))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            try
            {
            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, "Article");
            var project = new Certificate()
            {
                Title = command.Title,
                IsRemoved = false,               
                Picture = pictureName,
                PictureAlt = command.PictureAlt,
                PictureTitle = command.PictureTitle,
                Slug = slug,   
                EnTitle=command.EnTitle,
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
        public OperationResult Edit(EditCertificateViewModel command)
        {
            var operation = new OperationResult();
            Certificate project = Get(command.Id);

            if (project == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            if (command.Picture != null)
            {
                var pictureName = _fileUploader.Upload(command.Picture, "Article");
                project.Picture = pictureName;
            }
            project.Title = command.Title;
            project.IsRemoved = false;
            project.PictureAlt = command.PictureAlt;
            project.PictureTitle = command.PictureTitle;
            project.EnTitle = command.EnTitle;
            project.Slug = slug;
            _context.SaveChanges();
            return operation.Succedded();
        }
        public bool Exists(Expression<Func<Certificate, bool>> experssion)
        {
            return _context.Certificates.Any(experssion);
        }
        public BaseFilterViewModel<ListCertificateViewModel> GetAllAdmin(int pageIndex, string search)
        {
            var sellerList = _context.Certificates.Where(x => x.IsRemoved == false).OrderByDescending(x => x.Id).ToList();
            int take = 10;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.Title.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new ListCertificateViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                Id = x.Id,                
            }).ToList();

            var outPut = PagingHelper.Pagination<ListCertificateViewModel>(resault, pager);

            BaseFilterViewModel<ListCertificateViewModel> res = new BaseFilterViewModel<ListCertificateViewModel>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }
        public BaseFilterViewModel<ListCertificateViewModel> GetDeleteAdmin(int pageIndex, string search)
        {
            var sellerList = _context.Certificates.Where(x => x.IsRemoved == true).OrderByDescending(x => x.Id).ToList();
            int take = 10;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.Title.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new ListCertificateViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                Id = x.Id
            }).ToList();

            var outPut = PagingHelper.Pagination<ListCertificateViewModel>(resault, pager);

            BaseFilterViewModel<ListCertificateViewModel> res = new BaseFilterViewModel<ListCertificateViewModel>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }
        public EditCertificateViewModel GetDetails(long id)
        {
            return _context.Certificates.Select(x => new EditCertificateViewModel
            {
                Id = x.Id,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,                
                Title = x.Title,
                PictureStr=x.Picture,               
            }).FirstOrDefault(x => x.Id == id);
        }
        public Certificate Get(long id)
        {
            return _context.Certificates.Find(id);
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            Certificate project = Get(id);
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
            Certificate project = Get(id);
            if (project != null)
            {
                project.IsRemoved=false;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);

        }

    }
}
