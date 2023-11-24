using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopAljas.Core.Dto;
using TARpe21ShopAljas.Core.ServiceInterface;
using Xunit;

namespace TARpe21ShopAljas.SpaceshipTest
{
    public class SpaeshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceShip_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Name = "Test name";
            spaceship.Description = "Test description";
            spaceship.PassengerCount = 4;
            spaceship.CrewCount = 4;
            spaceship.CargoWeight = 5000;
            spaceship.MaxSpeedInVaccuum = 420;
            spaceship.BuiltAtDate = DateTime.Now;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.Manufacturer = "Test manufacturer";
            spaceship.IsSpaceshipPreviouslyOwned = true;
            spaceship.FullTripsCount = 50;
            spaceship.Type = "Test type";
            spaceship.FuelConsumptionPerDay = 50000;
            spaceship.MaintenanceCount = 9;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.NotNull(result);
        }
    }
}
