using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.AskedQuestionsManagement;
using DataLayer.Models.BlogManagement;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.ViewModels.Admin.ArticleCategoryViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Services
{
    public class ArticleCategoryService : IArticleCategory
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;
        public ArticleCategoryService(ApplicationDbContext context, IFileUploader fileUploader)
        {
            _context = context;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operation = new OperationResult();
            if (Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            try
            {
                var slug = command.Slug.Slugify();
                var pictureName = _fileUploader.Upload(command.Picture, "ArticleCategory");
                var articleCategory = new ArticleCategory(command.Name, pictureName, command.PictureAlt, command.PictureTitle
                    , command.Description, command.ShowOrder, slug, command.Keywords, command.MetaDescription,
                    command.CanonicalAddress, command.Language);
                _context.Add(articleCategory);
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با مدیر سایت تماس بگیرید!");
            }
           
        }
        public bool Exists(Expression<Func<ArticleCategory, bool>> experssion)
        {
            return _context.ArticleCategories.Any(experssion);
        }
        public OperationResult Edit(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var articleCategory = Get(command.Id);

            if (articleCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            try
            {
                var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, "ArticleCategory");
            articleCategory.Edit(command.Name, pictureName, command.PictureAlt, command.PictureTitle,
                command.Description, command.ShowOrder, slug, command.Keywords, command.MetaDescription,
                command.CanonicalAddress,command.Language);

            _context.SaveChanges();
            return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با مدیر سایت تماس بگیرید!");
            }
        }
        public ArticleCategory Get(long id)
        {
            return _context.ArticleCategories.Find(id);
        }
        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _context.ArticleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,Language=x.Language   ,
            }).ToList();
        }
        public EditArticleCategory GetDetails(long id)
        {
            return _context.ArticleCategories.Select(x => new EditArticleCategory
            {
                Id = x.Id,
                Name = x.Name,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,Language=x.Language,
            }).FirstOrDefault(x => x.Id == id);
        }
        public string GetSlugBy(long id)
        {
            return _context.ArticleCategories.Select(x => new { x.Id, x.Slug })
               .FirstOrDefault(x => x.Id == id).Slug;
        }
        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            var query = _context.ArticleCategories
                .Include(x => x.Articles)
                .Select(x => new ArticleCategoryViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Picture = x.Picture,
                    ShowOrder = x.ShowOrder,
                    CreationDate = x.CreationDate.ToFarsi(),
                    ArticlesCount = x.Articles.Count,Language=x.Language,
                    IsRemoved=x.IsRemoved,
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.ShowOrder).ToList();
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            ArticleCategory model = Get(id);
            if (model != null)
            {
                model.IsRemoved = true;
                _context.SaveChanges();
                return operation.Succedded();
            }
            return operation.Failed(ApplicationMessages.RecordNotFound);


        }
        public OperationResult Recovery(long id)
        {
            var operation = new OperationResult();
            ArticleCategory project = Get(id);
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
