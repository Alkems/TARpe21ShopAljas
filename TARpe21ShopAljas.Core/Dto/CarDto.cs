using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe21ShopAljas.Core.Dto
{
    public class CarDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Transmission { get; set; }
        public string DriveTrain { get; set; }
        public int Horsepower { get; set; }
        public string Previously_Owned { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToApiDto> FilesToApiDtos { get; set; } = new List<FileToApiDto>();
        public int ZeroToSixty { get; set; }
        public string FuelType { get; set; }
        //Db only
        public DateTime CreatedAt { get; set; } // when the entry was created
        public DateTime ModifiedAt { get; set; } // when the entry has been modified last
    }
}
