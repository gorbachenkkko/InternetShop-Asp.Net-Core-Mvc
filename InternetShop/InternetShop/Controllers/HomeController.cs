using InternetShop.DAL;
using InternetShop.DAL.Repositories;
using InternetShop.Domain.Entity;
using InternetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using InternetShop.Domain.Enum;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            db= context;
            
        }

        public async Task<IActionResult> Index()
        {
            //UserRepository r = new UserRepository(db);
            //r.Create(new User() { Id = 0, Name = "Igor", Password = "igor228", Role = Role.Admin });
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}