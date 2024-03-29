﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe21ShopAljas.Core.Dto.OpenWeatherDto
{
    public class OpenWeatherResultDto
    {
        public string City { get; set; }
        public int Timezone { get; set; }
        public string Description { get; set; }
        public double Lon { get; set; }
        public double Speed { get; set; }
        public double Lat { get; set; }
        public double Temperature { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public string Main { get; set; }
    }
}
