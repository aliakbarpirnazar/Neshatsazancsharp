using _0_Framework.Application;
using DataLayer.Context;
using DataLayer.Models.AskedQuestionsManagement;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.AskedQuestionViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Services
{
    public class QusetionService : IQusetion
    {
        private readonly ApplicationDbContext _context;
        public QusetionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public OperationResult Create(CreateAskedQuestion command)
        {

            var operation = new OperationResult();
            if (Exists(x => x.Qusetion == command.Qusetion && x.Language == command.Language))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);           

            try
            {
                var question = new AskedQuestion()
                {
                    Qusetion = command.Qusetion,
                    Answer = command.Answer,
                    OrderBy= command.OrderBy,
                    Language=command.Language,
                };

                _context.Add(question);
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("با خطا مواجه شدید لطفا با ادمین سایت تماس بگیرید");
            }
        }
        public OperationResult Edit(EditAskedQuestion command)
        {
            var operation = new OperationResult();
            AskedQuestion qusetion = Get(command.Id);

            if (qusetion == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (Exists(x => x.Qusetion == command.Qusetion && x.Id != command.Id && x.Language==command.Language))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            try
            {

                qusetion.Qusetion = command.Qusetion;
                qusetion.Answer = command.Answer;
                qusetion.OrderBy = command.OrderBy;
                qusetion.Language = command.Language;
                _context.SaveChanges();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed("با خطا مواجه شدید لطفا با ادمین سایت تماس بگیرید");
            }
        }
        public bool Exists(Expression<Func<AskedQuestion, bool>> experssion)
        {
            return _context.AskedQuestions.Any(experssion);
        }
        public BaseFilterViewModel<AskedQuestion> GetAllAdmin(int pageIndex, string search)
        {

            var sellerList = _context.AskedQuestions.Where(x => x.IsRemoved == false).OrderByDescending(x => x.Id).ToList();
            int take = 15;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.Qusetion.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new AskedQuestion
            {
                Qusetion = x.Qusetion,
                IsRemoved = x.IsRemoved,
                Answer = x.Answer,
                Id = x.Id,
                OrderBy=x.OrderBy,
                Language=x.Language,

            }).ToList();

            var outPut = PagingHelper.Pagination<AskedQuestion>(resault, pager);

            BaseFilterViewModel<AskedQuestion> res = new BaseFilterViewModel<AskedQuestion>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;

        }
        public BaseFilterViewModel<AskedQuestion> GetDeleteAdmin(int pageIndex, string search)
        {
            var sellerList = _context.AskedQuestions.Where(x => x.IsRemoved == true).OrderByDescending(x => x.Id).ToList();
            int take = 15;
            int howManyPageShow = 2;
            var pager = PagingHelper.Pager(pageIndex, sellerList.Count(), take, howManyPageShow);

            if (search != null)
            {
                sellerList = sellerList.Where(x => x.Qusetion.Contains(search)).ToList();
            }

            var resault = sellerList.Select(x => new AskedQuestion
            {
                Qusetion = x.Qusetion,
                IsRemoved = x.IsRemoved,
                Answer = x.Answer,
                Id = x.Id,
                OrderBy = x.OrderBy,
                Language=x.Language,
            }).ToList();

            var outPut = PagingHelper.Pagination<AskedQuestion>(resault, pager);

            BaseFilterViewModel<AskedQuestion> res = new BaseFilterViewModel<AskedQuestion>
            {
                EndPage = pager.EndPage,
                Entities = outPut,
                PageCount = pager.PageCount,
                StartPage = pager.StartPage,
                PageIndex = pageIndex
            };

            return res;
        }
        public AskedQuestion GetDetails(long id)
        {
            return _context.AskedQuestions.Select(x => new AskedQuestion
            {
                Id = x.Id,
                Qusetion = x.Qusetion,
                Answer = x.Answer,
                IsRemoved = x.IsRemoved,
                OrderBy = x.OrderBy,
                Language=x.Language,
            }).FirstOrDefault(x => x.Id == id);
        }
        public AskedQuestion Get(long id)
        {
            return _context.AskedQuestions.Find(id);
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            AskedQuestion model = Get(id);
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
            AskedQuestion project = Get(id);
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
