using AWC.Shared.Kernel.Utilities;
using Awc.Dapr.Services.Company.API.ViewModels;

namespace Awc.Dapr.Services.Company.API.Services
{
    public interface ICompanyService
    {
        Task<Result<CompanyViewModel>> GetCompanyViewModel(int id);    
    }
}