using Microsoft.AspNetCore.Mvc;
using TARpe21ShopAljas.Core.ServiceInterface;
using TARpe21ShopAljas.Models.OpenWeather;
using TARpe21ShopAljas.ApplicationServices.Services;
using TARpe21ShopAljas.Core.Dto.OpenWeatherDto;

namespace Tarpe21ShopAljas.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IWeatherForecastsServices _openWeatherServices;
        public OpenWeatherController(IWeatherForecastsServices weatherForecastServices)
        {
            _openWeatherServices = weatherForecastServices;
        }

        public IActionResult Index()
        {
            OWeatherViewModel vm = new OWeatherViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowWeather()
        {
            string city = Request.Form["City"];

            if (!string.IsNullOrEmpty(city))
            {
                OpenWeatherResultDto dto = new();
                dto.City = city;
                _openWeatherServices.OpenWeatherDetail(dto);

                OWeatherViewModel vm = new()
                {
                    City = dto.City,
                    Timezone = dto.Timezone,
                    Temperature = dto.Temperature,
                    Pressure = dto.Pressure,
                    Humidity = dto.Humidity,
                    Lon = dto.Lon,
                    Lat = dto.Lat,
                    Main = dto.Main,
                    Description = dto.Description,
                    Speed = dto.Speed
                };

                return View("City", vm);
            }

            return View();
        }
    }
}
