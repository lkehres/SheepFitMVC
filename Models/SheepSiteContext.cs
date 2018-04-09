using System;

namespace Sheep.Site.Api.Models{
    public class SheepSiteContext : DbContext
    {
        public SheepSiteContext(DbContextOptions<SheepSiteContext> options)
        : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; }
    }
}