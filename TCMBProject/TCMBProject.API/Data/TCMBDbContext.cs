using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCMBProject.Currency.Models;

namespace TCMBProject.API.Data
{
    public class TCMBDbContext:DbContext
    {
       
        public TCMBDbContext(DbContextOptions<TCMBDbContext> options):base(options)
        {
        }
       
        public DbSet<CurrencyModel> CurrencyModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyModel>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
