using InternetShop.DAL.Interfaces;
using InternetShop.Domain.Entity;
using InternetShop.Domain.Response;
using InternetShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using InternetShop.Domain.Enum;

namespace InternetShop.Service.Implementations
{
    public class BasketService : IBasketService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Clothes> _clothesRepository;
        private readonly IBaseRepository<Basket> _basketRepository;

        public BasketService(IBaseRepository<User> userRepository, IBaseRepository<Basket> basketRepository,
            IBaseRepository<Clothes> clothesRepository)
        {
            _userRepository = userRepository;
            _clothesRepository = clothesRepository;
            _basketRepository = basketRepository;
        }

        public async Task<BaseResponse<Basket>> AddInBasket(string userName, int clothesId)
        {
            try
            {
                var user = _userRepository.Select().Where(u => u.Name == userName).FirstOrDefault();
                if (user == null)
                {
                    return new BaseResponse<Basket>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var bas = _basketRepository.Select().Where(b => (b.UserName == userName && b.ClothesId == clothesId)).FirstOrDefault();
                if (bas != null)
                {
                    return new BaseResponse<Basket>()
                    {
                        Description = "Товар уже был добавлен в корзину",
                        StatusCode = StatusCode.BasketAlreadyExists
                    };
                }

                var basket = new Basket()
                {
                    UserName = userName,
                    ClothesId = clothesId
                };
                await _basketRepository.Create(basket);

                return new BaseResponse<Basket>()
                {
                    Data = basket,
                    Description = "Товар добавлен",
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<Basket>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<bool>> DeleteBasket(string userName,int id)
        {
            try
            {
                var basket =await _basketRepository.Select().Where(b => (b.ClothesId == id && b.UserName==userName)).FirstOrDefaultAsync();
                if(basket==null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Заказ не найден",
                        StatusCode = StatusCode.OrdersNotFound 
                    };
                }
                await _basketRepository.Delete(basket);
                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<Clothes>>> GetItems(string? userName)
        {
            try
            {
                var user = _userRepository.Select().Where(u => u.Name == userName).FirstOrDefault();
                if (user == null)
                {
                    return new BaseResponse<IEnumerable<Clothes>>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var baskets = _basketRepository.Select().Where(b => b.UserName == user.Name).ToList();
                if (baskets == null || baskets.Count == 0)
                {
                    return new BaseResponse<IEnumerable<Clothes>>()
                    {
                        Description = "Корзина пуста",
                        StatusCode = StatusCode.OK, 
                        Data = new List<Clothes>()
                    };
                }
                List<Clothes> result = new List<Clothes>();

                foreach (var b in baskets)
                {
                    Clothes clothes = await _clothesRepository.Select().Where(c => c.Id == b.ClothesId).FirstOrDefaultAsync();
                    result.Add(clothes);
                }
                return new BaseResponse<IEnumerable<Clothes>>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Clothes>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }  
}





