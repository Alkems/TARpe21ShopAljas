using Microsoft.AspNetCore.Mvc;

namespace TARpe21ShopAljas.Controllers
{
    public class OpenWeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
