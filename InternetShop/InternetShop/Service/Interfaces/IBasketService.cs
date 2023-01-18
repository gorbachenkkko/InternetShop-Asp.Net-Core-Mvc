using InternetShop.Domain.Entity;
using InternetShop.Domain.Response;

namespace InternetShop.Service.Interfaces
{
    public interface IBasketService
    {
        Task<BaseResponse<IEnumerable<Clothes>>> GetItems(string userName);

        Task<BaseResponse<Basket>> AddInBasket(string userName, int clothesId);

        Task<BaseResponse<bool>> DeleteBasket(string userName,int id);
    }
}
