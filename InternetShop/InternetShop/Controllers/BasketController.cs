using InternetShop.Service.Implementations;
using InternetShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InternetShop.Domain.Enum;
using InternetShop.Domain.Response;
using InternetShop.Domain.Entity;
using Azure;


namespace InternetShop.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        /*Вывод всех элементов корзины*/
        public async Task<IActionResult> Detail()
        {
            var responce = await _basketService.GetItems(User.Identity.Name);
            if (responce.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(responce.Data.ToList());
            }
            return RedirectToAction("Error");
        }

        /*Добавить элемент в корзину*/
        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            var responce = await _basketService.AddInBasket(User.Identity.Name, id);
            if(responce.StatusCode != Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetAllClothes", "Clothes");
            }
            return RedirectToAction("GetAllClothes", "Clothes"); ;
        }

        /*Удалить элемент с корзины*/
        public async Task<IActionResult> Delete(string userName, int id)
        {
            var responce = await _basketService.DeleteBasket(User.Identity.Name,id);
            if (responce.Data)
            {
                return RedirectToAction("Detail");
            }
            return RedirectToAction("Error");
        }
    }
}
