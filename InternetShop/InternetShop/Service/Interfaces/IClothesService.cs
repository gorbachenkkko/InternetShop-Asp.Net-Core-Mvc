using InternetShop.Domain.Entity;
using InternetShop.Domain.Response;
using InternetShop.Domain.ViewModels.Clothes;

namespace InternetShop.Service.Interfaces
{
    public interface IClothesService
    {
        Task<BaseResponse<IEnumerable<Clothes>>> GetAllClothes();

        Task<BaseResponse<Clothes>> GetClothes(int id);

        Task<IBaseResponse<Clothes>> GetClothesByName(string name);

        Task<BaseResponse<bool>> DeleteClothes(int id);

        Task<IBaseResponse<bool>> CreateClothes(ClothesViewModel clothesView);

        Task<BaseResponse<Clothes>> Edit(int id,ClothesViewModel model);
    }
}
