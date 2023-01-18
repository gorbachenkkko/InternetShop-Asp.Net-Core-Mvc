using InternetShop.DAL.Interfaces;
using InternetShop.DAL.Repositories;
using InternetShop.Domain.Entity;
using InternetShop.Domain.Enum;
using InternetShop.Domain.Response;
using InternetShop.Domain.ViewModels.Clothes;
using InternetShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InternetShop.Service.Implementations
{
    public class ClothesService : IClothesService
    {
        private readonly IBaseRepository<Clothes> _clothesRepository;
        private readonly IBaseRepository<Basket> _basketRepository;
        public ClothesService(IBaseRepository<Clothes> clothesRepository, IBaseRepository<Basket> basketRepository)
        {
            _clothesRepository = clothesRepository;
            _basketRepository = basketRepository;
        }
        public async Task<BaseResponse<IEnumerable<Clothes>>> GetAllClothes()
        {
            var baseResponse = new BaseResponse<IEnumerable<Clothes>>();
            try
            {
                var clothes = _clothesRepository.Select();
                if(clothes==null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;

                    return baseResponse;
                }

                baseResponse.Data = clothes;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch(Exception e)
            {
                return new BaseResponse<IEnumerable<Clothes>>()
                {
                    Description = $"[GetAllClothes] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            };
        }

        public async Task<BaseResponse<Clothes>> GetClothes(int id)
        {
            var baseResponse=new BaseResponse<Clothes>();
            try
            {
                var clothes = await _clothesRepository.Select().FirstOrDefaultAsync<Clothes>(x=>x.Id==id);
                if(clothes==null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode=StatusCode.UserNotFound;

                    return baseResponse;
                }
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = clothes;
                return baseResponse;
            }
            catch(Exception e)
            {
                return new BaseResponse<Clothes>()
                {
                    Description = $"[GetClothes] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<Clothes>> GetClothesByName(string name)
        {
            var baseResponse = new BaseResponse<Clothes>();
            try
            {
                var clothes = await _clothesRepository.Select().FirstOrDefaultAsync(x => x.Name == name); 
                if (clothes == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;

                    return baseResponse;
                }

                baseResponse.Data = clothes;
                return baseResponse;
            }
            catch (Exception e)
            {
                return new BaseResponse<Clothes>()
                {
                    Description = $"[GetClothesByName] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<BaseResponse<bool>> DeleteClothes(int id)
        {
            var baseResponse = new BaseResponse<bool>() { Data = true };
            try
            {
                var clothes = await _clothesRepository.Select().FirstOrDefaultAsync<Clothes>(x => x.Id == id);
                if(clothes==null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Data = false;

                    return baseResponse;
                }

                var basket = _basketRepository.Select().Where(b => b.ClothesId == clothes.Id).ToList();
                foreach(Basket b in basket)
                {
                    await _basketRepository.Delete(b);
                }

                baseResponse.StatusCode=StatusCode.OK;
                await _clothesRepository.Delete(clothes);

                return baseResponse;
            }
            catch(Exception e)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteClothes] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<bool>> CreateClothes(ClothesViewModel clothesView)
        {
            var baseResponse = new BaseResponse<bool> { Data = true };
            try
            {
                var clothes = new Clothes()
                {
                    Name = clothesView.Name,
                    Color = /*(Color)Convert.ToInt32(clothesView.Color)*/clothesView.Color,
                    Gender = clothesView.Gender,
                    Price = clothesView.Price,
                    Size = /*(Size)Convert.ToInt32(clothesView.Size)*/clothesView.Size,
                    СlothingType = /*(СlothingType)Convert.ToInt32(clothesView.СlothingType)*/clothesView.СlothingType,
                    ImageUrl = clothesView.ImageUrl,
                    Description=clothesView.Description
                    
                };

                await _clothesRepository.Create(clothes);
                return baseResponse;
            }
            catch (Exception e)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[CreateClothes] : {e.Message}",
                    Data = false
                };
            }
        }

        public async Task<BaseResponse<Clothes>> Edit(int id, ClothesViewModel model)
        {
            var baseResponse = new BaseResponse<Clothes>();
            try
            {
                Clothes clothes = await _clothesRepository.Select().FirstOrDefaultAsync<Clothes>(x => x.Id == id);
                if (clothes == null)
                {
                    baseResponse.StatusCode = StatusCode.ClothesNotFound;
                    baseResponse.Description = "Clothes Not Found";
                    return baseResponse;
                }

                clothes.Description = model.Description;
                clothes.Name = model.Name;
                clothes.Price = model.Price;
                clothes.Color = model.Color;
                clothes.Gender = model.Gender;
                clothes.СlothingType =model.СlothingType;
                clothes.Size =model.Size;
                clothes.ImageUrl=model.ImageUrl;

                await _clothesRepository.Update(clothes);
                return baseResponse;
            }
            catch (Exception e)
            {
                return new BaseResponse<Clothes>()
                {
                    Description = $"[Edit] : {e.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
