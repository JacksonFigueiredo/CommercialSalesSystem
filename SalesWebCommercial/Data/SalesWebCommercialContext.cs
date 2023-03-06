using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebCommercial.Models;

    public class SalesWebCommercialContext : DbContext
    {
        public SalesWebCommercialContext (DbContextOptions<SalesWebCommercialContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebCommercial.Models.Department> Department { get; set; } = default!;
    }
