using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System.Xml.Linq;
using TARpe21ShopAljas.ApplicationServices.Services;
using TARpe21ShopAljas.Core.Dto;
using TARpe21ShopAljas.Core.ServiceInterface;
using TARpe21ShopAljas.Data;
using TARpe21ShopAljas.Models.Car;
using TARpe21ShopAljas.Models.RealEstate;
using TARpe21ShopAljas.Models.Shared;

namespace TARpe21ShopAljas.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarServices _cars;
        private readonly TARpe21ShopAljasContext _context;
        private readonly IFilesServices _filesServices;
        public CarsController
            (
            ICarServices cars,
            TARpe21ShopAljasContext context, IFilesServices files
            )
        {
            _cars = cars;
            _context = context;
            _filesServices = files;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    DriveTrain = x.DriveTrain,
                    Transmission = x.Transmission,
                    Horsepower = x.Horsepower,
                    Previously_Owned = x.Previously_Owned,
                    ZeroToSixty = x.ZeroToSixty,
                    FuelType = x.FuelType,
                });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(FileToApiViewModel vm)
        {
            var dto = new FileToApiDto()
            {
                Id = vm.ImageId
            };
            var image = await _filesServices.RemoveImageFromApi(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel vm = new();
            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = Guid.NewGuid(),
                Name = vm.Name,
                DriveTrain = vm.DriveTrain,
                Transmission = vm.Transmission,
                Horsepower = vm.Horsepower,
                Previously_Owned = vm.Previously_Owned,
                ZeroToSixty = vm.ZeroToSixty,
                FuelType = vm.FuelType,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                FilesToApiDtos = vm.FileToApiViewModels
                .Select(z => new FileToApiDto
                {
                    Id = z.ImageId,
                    ExistingFilePath = z.FilePath,
                    CarId = z.CarId,
                }).ToArray()
            };
            var result = await _cars.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();
            var vm = new CarCreateUpdateViewModel();

            vm.Id = car.Id;
            vm.Name = car.Name;
            vm.DriveTrain = car.DriveTrain;
            vm.Transmission = car.Transmission;
            vm.Horsepower = car.Horsepower;
            vm.Previously_Owned = car.Previously_Owned;
            vm.ZeroToSixty = car.ZeroToSixty;
            vm.FuelType = car.FuelType;
            vm.CreatedAt = DateTime.Now;
            vm.ModifiedAt = DateTime.Now;
            vm.FileToApiViewModels.AddRange(images);

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                DriveTrain = vm.DriveTrain,
                Transmission = vm.Transmission,
                Horsepower = vm.Horsepower,
                Previously_Owned = vm.Previously_Owned,
                ZeroToSixty = vm.ZeroToSixty,
                FuelType = vm.FuelType,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                FilesToApiDtos = vm.FileToApiViewModels
                .Select(z => new FileToApiDto
                {
                    Id = z.ImageId,
                    ExistingFilePath = z.FilePath,
                    CarId = z.CarId,
                }).ToArray()
            };
            var result = await _cars.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();

            var vm = new CarDeleteDetailsViewModel();

            vm.Id = car.Id;
            vm.Name = car.Name;
            vm.DriveTrain = car.DriveTrain;
            vm.Transmission = car.Transmission;
            vm.Horsepower = car.Horsepower;
            vm.Previously_Owned = car.Previously_Owned;
            vm.isDeleting = false;
            vm.ZeroToSixty = car.ZeroToSixty;
            vm.FuelType = car.FuelType;
            vm.CreatedAt = DateTime.Now;
            vm.ModifiedAt = DateTime.Now;
            vm.FileToApiViewModels.AddRange(images);

            return View("DeleteDetails", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id
                }).ToArrayAsync();

            var vm = new CarDeleteDetailsViewModel();

            vm.Id = car.Id;
            vm.Name = car.Name;
            vm.DriveTrain = car.DriveTrain;
            vm.Transmission = car.Transmission;
            vm.Horsepower = car.Horsepower;
            vm.Previously_Owned = car.Previously_Owned;
            vm.ZeroToSixty = car.ZeroToSixty;
            vm.FuelType = car.FuelType;
            vm.CreatedAt = DateTime.Now;
            vm.ModifiedAt = DateTime.Now;
            vm.isDeleting = true;
            vm.FileToApiViewModels.AddRange(images);

            return View("DeleteDetails",vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var car = await _cars.Delete(id);
            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
