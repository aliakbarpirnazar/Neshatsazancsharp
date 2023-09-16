using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.BlogManagement;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.ViewModels.Admin.ArticleViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Services
{
    public class ArticleService : IArticle
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploader _fileUploader;
        private readonly IArticleCategory _articleCategoryRepository;
        public ArticleService(ApplicationDbContext context, IFileUploader fileUploader, IArticleCategory articleCategoryRepository)
        {
            _context = context;
            _fileUploader = fileUploader;
            _articleCategoryRepository = articleCategoryRepository;
        }
        public OperationResult Create(CreateArticle command)
        {
            var operation = new OperationResult();
            if (Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            try
            {


                var slug = command.Slug.Slugify();
                var categorySlug = _articleCategoryRepository.GetSlugBy(command.CategoryId);
                var path = $"{categorySlug}/{slug}";
                var pictureName = _fileUploader.Upload(command.Picture, "Article");
                var publishDate = command.PublishDate.ToGeorgianDateTime();

                var article = new Article(command.Title, command.ShortDescription, command.Description, pictureName,
                    command.PictureAlt, command.PictureTitle, publishDate, slug, command.Keywords, command.MetaDescription,
                    command.CanonicalAddress, command.CategoryId);

                _context.Add(article);
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با ادمین سایت تماس بگیرید!");
            }
        }
        public bool Exists(Expression<Func<Article, bool>> experssion)
        {
            return _context.Articles.Any(experssion);
        }
        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();
            try
            {
                var article = GetWithCategory(command.Id);

                if (article == null)
                    return operation.Failed(ApplicationMessages.RecordNotFound);

                if (Exists(x => x.Title == command.Title && x.Id != command.Id))
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);

                var slug = command.Slug.Slugify();
                var path = $"{article.Category.Slug}/{slug}";
                var pictureName = _fileUploader.Upload(command.Picture, "Article");
                var publishDate = command.PublishDate.ToGeorgianDateTime();

                article.Edit(command.Title, command.ShortDescription, command.Description, pictureName,
                    command.PictureAlt, command.PictureTitle, publishDate, slug, command.Keywords, command.MetaDescription,
                    command.CanonicalAddress, command.CategoryId);

                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("لطفا با ادمین سایت تماس بگیرید!");
            }
        }
        public EditArticle GetDetails(long id)
        {
            return _context.Articles.Select(x => new EditArticle
            {
                Id = x.Id,
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }
        public Article GetWithCategory(long id)
        {
            return _context.Articles.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }
        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _context.Articles.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                Category = x.Category.Name,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + " ...",
                Title = x.Title,
                IsRemoved= x.IsRemoved,
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.CategoryId > 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
        public Article Get(long id)
        {
            return _context.Articles.Find(id);
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            Article model = Get(id);
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
            Article project = Get(id);
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
