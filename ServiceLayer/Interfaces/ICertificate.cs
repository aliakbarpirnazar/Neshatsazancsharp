using _0_Framework.Application;
using DataLayer.Models.CertificateManagement;
using ServiceLayer.ViewModels;
using ServiceLayer.ViewModels.Admin.CertificateViewModels;
using System.Linq.Expressions;

namespace ServiceLayer.Interfaces
{
    public interface ICertificate
    {
        OperationResult Create(CreateCertificateViewModel command);
        OperationResult Edit(EditCertificateViewModel command);
        bool Exists(Expression<Func<Certificate, bool>> experssion);
        BaseFilterViewModel<ListCertificateViewModel> GetAllAdmin(int pageIndex, string search);
        BaseFilterViewModel<ListCertificateViewModel> GetDeleteAdmin(int pageIndex, string search);
        EditCertificateViewModel GetDetails(long id);
        Certificate Get(long id);
        OperationResult Delete(long id);
        OperationResult Recovery(long id);

    }
}
