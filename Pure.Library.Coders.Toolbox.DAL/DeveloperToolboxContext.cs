using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pure.Library.Coders.Toolbox.DAL.Entities;
using Pure.Library.SQLite.Entities;

namespace Pure.Library.Coders.Toolbox.DAL;

/// <summary>
/// The <see cref="DbContext"/> for the Developer Toolbox database.
/// </summary>
/// <param name="options">The <see cref="DbContextOptions"/> collection.</param>
public sealed class DeveloperToolboxContext(DbContextOptions<DeveloperToolboxContext> options) :  DbContext(options)
{
    #region Create Statements

    #endregion

    #region Entities
    public DbSet<LookUp> LookUps { get; set; }
    public DbSet<CodeObjectMapping> CodeObjectMappings { get; set; }
    public DbSet<KeyManager> Identities { get; set; }
    public DbSet<CodeFlavour> CodeFlavours { get; set; }
    public DbSet<FileLocation> FileLocations { get; set; }
    public DbSet<CreatedCodeObject> CreatedCodeObjects { get; set; }
    public DbSet<SystemDetail> SystemDetails { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // CodeObjectMapping
        modelBuilder.Entity<CodeObjectMapping>()
            .HasKey(o => new { o.CodeFlavour, o.InputType, o.CodeObject });

        modelBuilder.Entity<LookUp>(entity =>
        {
            entity.Property(e => e.Id)
            .ValueGeneratedNever();

            entity.HasKey(o => o.Id);
        });

        modelBuilder.Entity<KeyManager>()
            .HasKey(o => o.GlobalKey);

        modelBuilder.Entity<CodeFlavour>()
            .HasKey(o => o.Name);

        modelBuilder.Entity<FileLocation>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<CreatedCodeObject>()
            .HasKey(o => o.Id);

        modelBuilder.Entity<SystemDetail>()
            .HasKey(o => new { o.Application, o.Name });

        IMutableEntityType[] entities = [.. modelBuilder.Model.GetEntityTypes()];

        // Adjust the table names so that they don't pluralise.
        int i = 0;
        while (i < entities.Length)
        {
            IMutableEntityType entity = entities[i++];

            entity.SetTableName(entity.DisplayName());
        }     
    }
}
