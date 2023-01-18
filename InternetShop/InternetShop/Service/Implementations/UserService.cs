using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetShop.DAL.Interfaces;
using InternetShop.Domain.Entity;
using InternetShop.Domain.Enum;
using InternetShop.Domain.Response;
using InternetShop.Domain.ViewModels.User;
using InternetShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Basket> _basketRepository;

        public UserService(IBaseRepository<User> userRepository, 
            IBaseRepository<Basket> basketRepository)
        {
            _userRepository = userRepository;
            _basketRepository = basketRepository;
        }
        
        public async Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.Select()
                    .Select(x => new UserViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Role = x.Role
                    })
                    .ToListAsync();

                return new BaseResponse<IEnumerable<UserViewModel>>()
                {
                    Data = users,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<UserViewModel>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }

        public async Task<BaseResponse<bool>> DeleteUser(long id,string userName)
        {
            try
            {
                var user = await _userRepository.Select().FirstOrDefaultAsync(x => x.Id == id && userName!=x.Name);
                if (user == null)
                {
                    return new BaseResponse<bool>
                    {
                        StatusCode = StatusCode.UserNotFound,
                        Data = false
                    };
                }
                var basket = _basketRepository.Select().Where(u => u.UserName == user.Name).ToList();
                if(basket!=null)
                {
                    foreach(var b in basket)
                    {
                       await _basketRepository.Delete(b);
                    }
                }
                await _userRepository.Delete(user);
                
                return new BaseResponse<bool>
                {
                    StatusCode = StatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"Внутренняя ошибка: {ex.Message}"
                };
            }
        }
    }
}