using Agrovision.Dto;
using Microsoft.EntityFrameworkCore;

namespace Agrovision.Data
{
    public class SprayCalcDbContext : DbContext
    {
        public SprayCalcDbContext(DbContextOptions<SprayCalcDbContext> options) 
            : base(options)
        { }

        public SprayCalcDbContext() { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SprayCalcDbContext).Assembly);
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Sprayer> Sprayers { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
    }
}