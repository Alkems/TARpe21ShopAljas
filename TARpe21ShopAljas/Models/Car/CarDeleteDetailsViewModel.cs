using TARpe21ShopAljas.Models.RealEstate;
using TARpe21ShopAljas.Models.Spaceship;

namespace TARpe21ShopAljas.Models.Car
{
    public class CarDeleteDetailsViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Transmission { get; set; }
        public string DriveTrain { get; set; }
        public int Horsepower { get; set; }
        public string Previously_Owned { get; set; }
        public int ZeroToSixty { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<FileToApiViewModel> FileToApiViewModels { get; set; } = new List<FileToApiViewModel>();
        public string FuelType { get; set; }



        public List<ImageViewModel> Image { get; set; } = new List<ImageViewModel>();
        //Db only
        public DateTime CreatedAt { get; set; } // when the entry was created
        public DateTime ModifiedAt { get; set; } // when the entry has been modified last
    }
}
