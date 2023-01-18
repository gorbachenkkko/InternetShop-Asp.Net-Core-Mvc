using System.Collections.Generic;
using System.Threading.Tasks;
using InternetShop.Domain.Entity;
using InternetShop.Domain.Response;
using InternetShop.Domain.ViewModels.User;


namespace InternetShop.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();

        Task<BaseResponse<bool>> DeleteUser(long id,string userName);
    }
}