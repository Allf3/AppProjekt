using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options)
        {

        }

        public DbSet<Measurement> Measurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measurement>().HasData(
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now, Humidity = 0, Temperatur = 19 },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(2), Humidity = 0, Temperatur = 19.5f },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(4), Humidity = 0, Temperatur = 20.5f },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(8), Humidity = 0, Temperatur = 20.2f },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(10), Humidity = 0, Temperatur = 20.3f },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(12), Humidity = 0, Temperatur = 21.0f },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(14), Humidity = 0, Temperatur = 21.2f },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(16), Humidity = 0, Temperatur = 21.5f },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(18), Humidity = 0, Temperatur = 21.3f },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(20), Humidity = 0, Temperatur = 20.9f },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(22), Humidity = 0, Temperatur = 20.8f },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(24), Humidity = 0, Temperatur = 21.1f },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(26), Humidity = 0, Temperatur = 20.94f },
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now.AddSeconds(28), Humidity = 0, Temperatur = 20.6f }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
