using System;
using Sheep.Site.Api.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Sheep.Site.Api.Models{
    public class SheepSiteContext : DbContext
    {
        public SheepSiteContext(DbContextOptions<SheepSiteContext> options)
        : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Pregnancy> Pregnancies { get; set; }
    }
}