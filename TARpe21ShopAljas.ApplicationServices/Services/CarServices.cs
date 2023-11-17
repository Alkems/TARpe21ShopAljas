using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopAljas.Core.Domain;
using TARpe21ShopAljas.Core.Dto;
using TARpe21ShopAljas.Core.ServiceInterface;
using TARpe21ShopAljas.Data;

namespace TARpe21ShopAljas.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly TARpe21ShopAljasContext _context;
        private readonly IFilesServices _filesServices;
        public CarServices
            (
            TARpe21ShopAljasContext context,
            IFilesServices filesServices
            )
        {
            _context = context;
            _filesServices = filesServices;
        }
        public async Task<Car> Create(CarDto dto)
        {
            Car car = new();

            car.Id = Guid.NewGuid();
            car.Name = dto.Name;
            car.Transmission = dto.Transmission;
            car.DriveTrain = dto.DriveTrain;
            car.Horsepower = dto.Horsepower;
            car.Previously_Owned = dto.Previously_Owned;
            car.Transmission = dto.Transmission;
            car.FuelType = dto.FuelType;
            car.ZeroToSixty = dto.ZeroToSixty;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;
            _filesServices.FilesToApi(dto, car);


            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .Include(x => x.FilesToApi)
                .FirstOrDefaultAsync(x => x.Id == id);
            var images = await _context.FilesToApi
                .Where(x => x.CarId == id)
                .Select(y => new FileToApiDto
                {
                    Id = y.Id,
                    CarId = y.CarId,
                    ExistingFilePath = y.ExistingFilePath
                }).ToArrayAsync();
            await _filesServices.RemoveImagesFromApi(images);
            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();
            return carId;
        }
        public async Task<Car> Update(CarDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
            car.Name = dto.Name;
            car.Transmission = dto.Transmission;
            car.DriveTrain = dto.DriveTrain;
            car.Horsepower = dto.Horsepower;
            car.Previously_Owned = dto.Previously_Owned;
            car.FuelType = dto.FuelType;
            car.ZeroToSixty = dto.ZeroToSixty;
            car.CreatedAt = dto.CreatedAt;
            car.ModifiedAt = DateTime.Now;
            _filesServices.FilesToApi(dto, car);

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}