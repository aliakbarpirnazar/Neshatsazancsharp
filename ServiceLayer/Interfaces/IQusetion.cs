using _0_Framework.Application;
using DataLayer.Models.AskedQuestionsManagement;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.AskedQuestionViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Interfaces
{
    public interface IQusetion
    {
        OperationResult Create(CreateAskedQuestion command);
        OperationResult Edit(EditAskedQuestion command); 
        bool Exists(Expression<Func<AskedQuestion, bool>> experssion);
        BaseFilterViewModel<AskedQuestion> GetAllAdmin(int pageIndex, string search);
        BaseFilterViewModel<AskedQuestion> GetDeleteAdmin(int pageIndex, string search);
        AskedQuestion GetDetails(long id);
        AskedQuestion Get(long id);
        OperationResult Delete(long id);
        OperationResult Recovery(long id);


    }
}
