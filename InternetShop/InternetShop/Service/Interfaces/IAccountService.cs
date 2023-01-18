using System.Security.Claims;
using System.Threading.Tasks;
using InternetShop.Domain.Response;
using InternetShop.Domain.ViewModels.Account;

namespace InternetShop.Service.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

    }
}