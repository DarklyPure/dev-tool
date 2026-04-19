using Microsoft.EntityFrameworkCore;
using Pure.Dal.TheGarden.Entities;

namespace Pure.Dal.TheGarden;

public sealed class TheGardenContext(DbContextOptions<TheGardenContext> options) : DbContext(options)
{
    #region DbSets
    public DbSet<CompanionPlantingMatrix> CompanionPlantingMatrices { get; set; }
    public DbSet<KeyManager> KeyManagers { get; set; }
    public DbSet<LookUp> LookUps { get; set; }
    public DbSet<GenusName> Genera { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GenusName>()
            .HasKey(o => o.Name);

        modelBuilder.Entity<Plantae>()
            .HasKey(o => new { o.Genus, o.Species, o.CommonName });
    }
}
