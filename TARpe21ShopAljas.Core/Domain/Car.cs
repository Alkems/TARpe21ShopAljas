using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe21ShopAljas.Core.Domain
{
    internal class Car
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Transmission { get; set; }
        public string DriveTrain { get; set; }
        public int Horsepower { get; set; }
        public string Previously_Owned { get; set; }

    }
}
