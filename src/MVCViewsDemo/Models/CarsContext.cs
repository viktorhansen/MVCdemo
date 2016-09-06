using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MVCViewsDemo.Models
{
    public class CarsContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarsContext(DbContextOptions<CarsContext> options) : base(options)
        {

        }
    }
}
