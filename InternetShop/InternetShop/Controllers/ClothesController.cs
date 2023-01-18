using InternetShop.DAL;
using InternetShop.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using InternetShop.Domain.Entity;
using InternetShop.Domain.Enum;
using InternetShop.DAL.Interfaces;
using InternetShop.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using InternetShop.Domain.ViewModels.Clothes;

namespace InternetShop.Controllers
{
    public class ClothesController : Controller
    {
        private readonly IClothesService _clothesService;
        public ClothesController(IClothesService service)
        {
            _clothesService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClothes()
        {
            var response = await _clothesService.GetAllClothes();
            
            if (response.StatusCode== Domain.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetManClothes()
        {
            var response = await _clothesService.GetAllClothes();
            var manList = response.Data.Where(x => x.Gender == Gender.Man);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View("GetAllClothes", manList.ToList());
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetWomanClothes()
        {
            var response = await _clothesService.GetAllClothes();
            var manList = response.Data.Where(x => x.Gender == Gender.Woman);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View("GetAllClothes", manList.ToList());
                
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetClothes(int id)
        {
            var response = await _clothesService.GetClothes(id);

            if(response.StatusCode==Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _clothesService.DeleteClothes(id);
            if(response.Data)
            {
                return RedirectToAction("GetAllClothes");
            }
            return RedirectToAction("Error");
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
                return View();
            else
            {
                var response = await _clothesService.GetClothes(id);
                ClothesViewModel model = new ClothesViewModel()
                {
                    Id = response.Data.Id,
                    Color = response.Data.Color,
                    Description = response.Data.Description,
                    Gender = response.Data.Gender,
                    ImageUrl = response.Data.ImageUrl,
                    Name = response.Data.Name,
                    Price = response.Data.Price,
                    Size = response.Data.Size,
                    СlothingType = response.Data.СlothingType
                };
                
                if (response.StatusCode == Domain.Enum.StatusCode.OK)
                    return View(model);
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Save(ClothesViewModel model)
        {
            if (model.Id == 0)
            {
                await _clothesService.CreateClothes(model);
            }
            else
            {
                await _clothesService.Edit(model.Id, model);
            }

            return RedirectToAction("GetAllClothes");
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
