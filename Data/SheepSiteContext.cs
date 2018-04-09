using System;
using Sheep.Site.Api.Controllers;
using Sheep.Site.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Sheep.Site.Api.Data{
    public class SheepSiteContext : DbContext
    {
        public SheepSiteContext(DbContextOptions<SheepSiteContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);

        
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Pregnancy> Pregnancies { get; set; }
    }
}