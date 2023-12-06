using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopAljas.Core.Dto.WeatherDtos;
using TARpe21ShopAljas.Core.Dto.OpenWeatherDto;
using TARpe21ShopAljas.Core.ServiceInterface;
using Tarpe21ShopAljas.Core.Dto.OpenWeatherDto;

namespace TARpe21ShopAljas.ApplicationServices.Services
{
    public class WeatherForecastsServices : IWeatherForecastsServices
    {

        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            string apikey = "UoJSCG3lbTnHIA9VEMQbeILRapsOWdQx";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apiKey=UoJSCG3lbTnHIA9VEMQbeILRapsOWdQx&metric=true";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                WeatherRootDto weatherInfo = new JavaScriptSerializer().Deserialize<WeatherRootDto>(json);

                dto.EffectiveDate = weatherInfo.Headline.EffectiveDate;
                dto.EffectiveEpochDate = weatherInfo.Headline.EffectiveEpochDate;
                dto.Severity = weatherInfo.Headline.Severity;
                dto.Text = weatherInfo.Headline.Text;
                dto.Category = weatherInfo.Headline.Category;
                dto.EndDate = weatherInfo.Headline.EndDate;
                dto.EndEpochDate = weatherInfo.Headline.EndEpochDate;
                dto.MobileLink = weatherInfo.Headline.MobileLink;
                dto.Link = weatherInfo.Headline.Link;

                //weatherInfo.DailyForecasts[0].Date = dto.DailyForecastsDay;
                //weatherInfo.DailyForecasts[0].EpochDate = dto.DailyForecastsEpochDate;

                dto.TempMinValue = weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                dto.TempMinUnit = weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit;
                dto.TempMinUnitType = weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType;

                dto.TempMaxValue = weatherInfo.DailyForecasts[0].Temperature.Maximum.Value;
                dto.TempMaxUnit = weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit;
                dto.TempMaxUnitType = weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType;

                dto.DayIcon = weatherInfo.DailyForecasts[0].Day.Icon;
                dto.DayIconPhrase = weatherInfo.DailyForecasts[0].Day.IconPhrase;
                dto.DayHasPrecipitation = weatherInfo.DailyForecasts[0].Day.HasPrecipitation;
                dto.DayPrecipitationType = weatherInfo.DailyForecasts[0].Day.PrecipitationType;
                dto.DayPrecipitationIntensity = weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity;

                dto.NightIcon = weatherInfo.DailyForecasts[0].Night.Icon;
                dto.NightIconPhrase = weatherInfo.DailyForecasts[0].Night.IconPhrase;
                dto.NightHasPrecipitation = weatherInfo.DailyForecasts[0].Night.HasPrecipitation;
                dto.NightPrecipitationType = weatherInfo.DailyForecasts[0].Night.PrecipitationType;
                dto.NightPrecipitationIntensity = weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity;
            }
            return dto;
        }

        public async Task<OpenWeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto)
        {
            string apikey = "e294f7c54fe454ddfe2131bbe603db4b";
            string city = dto.City;
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={apikey}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                OpenWeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<OpenWeatherRootDto>(json);

                dto.City = weatherInfo.Name;
                dto.Timezone = weatherInfo.Timezone;
                dto.Temperature = weatherInfo.Main.Temp;
                dto.Humidity = weatherInfo.Main.Humidity;
                dto.Pressure = weatherInfo.Main.Pressure;
                dto.Speed = weatherInfo.Wind.Speed;
                dto.Description = weatherInfo.Weather[0].Description;
                dto.Main = weatherInfo.Weather[0].Main;
            }
            return dto;
        }
    }
}