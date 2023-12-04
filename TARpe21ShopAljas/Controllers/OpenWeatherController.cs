using Microsoft.AspNetCore.Mvc;
using TARpe21ShopAljas.Core.ServiceInterface;
using TARpe21ShopAljas.Models.OpenWeather;
using TARpe21ShopAljas.ApplicationServices.Services;
using TARpe21ShopAljas.Core.Dto.OpenWeatherDto;

namespace Tarpe21ShopAljas.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IWeatherForecastsServices _openWeatherForecastServices;

        public OpenWeatherController(IWeatherForecastsServices openWeathersServices)
        {
            _openWeatherForecastServices = openWeathersServices;
        }
        public IActionResult Index()
        {
            SearchCityViewModel vm = new SearchCityViewModel();

            return View();
        }
        [HttpPost]
        public IActionResult ShowWeather()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "OpenWeather");
            }

            return View();
        }
        [HttpPost]
        public IActionResult SearchCity(SearchCityViewModel searchCityViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "OpenWeather", new { city = searchCityViewModel.CityName });
            }
            return View();
        }


        [HttpGet]
        public IActionResult City(string city)
        {
            OpenWeatherResultDto dto = new();
            CityResultViewModel vm = new CityResultViewModel();
            dto.City = city;
            _openWeatherForecastServices.OpenWeatherDetail(dto);
            vm.City = city;
            vm.Timezone = dto.Timezone;
            vm.Name = dto.Name;
            vm.Lon = dto.Lon;
            vm.Lat = dto.Lat;
            vm.Temperature = dto.Temperature;
            vm.Feels_like = dto.Feels_like;
            vm.Pressure = dto.Pressure;
            vm.Humidity = dto.Humidity;
            vm.Main = dto.Main;
            vm.Description = dto.Description;
            vm.Speed = dto.Speed;
            return View(vm);
        }
    }
}
