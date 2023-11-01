using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopAljas.Core.Domain;

namespace TARpe21ShopAljas.Data
{
    public class TARpe21ShopAljasContext : DbContext
    {
        public TARpe21ShopAljasContext(DbContextOptions<TARpe21ShopAljasContext> options) : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
    }
}
