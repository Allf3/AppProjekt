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
                new Measurement { ID = Guid.NewGuid(), Date = DateTime.Now, Humidity = 0, Temperatur = 24 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
