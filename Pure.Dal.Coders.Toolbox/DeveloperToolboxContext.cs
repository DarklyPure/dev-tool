using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pure.Dal.Coders.Toolbox.Entities;

namespace Pure.Dal.Coders.Toolbox;

/// <summary>
/// Implementation of a <see cref="DbContext"/>.
/// </summary>
/// <param name="options">A <see cref="DbContextOptions"/> instance.</param>
public class DeveloperToolboxContext(DbContextOptions<DeveloperToolboxContext> options) : DbContext(options)
{
    #region DbSets
    public DbSet<LookUp> LookUps { get; set; }
    public DbSet<CodeFlavour> CodeFlavours { get; set; }
    public DbSet<CodeObjectMatrix> CodeObjectMatrices { get; set; }
    public DbSet<ClassSpecification> ClassSpecifications { get; set; }
    public DbSet<PropertySpecification> PropertySpecifications { get; set; }
    public DbSet<MethodSpecification> MethodSpecifications { get; set; }
    public DbSet<ParameterSpecification> ParameterSpecifications { get; set; }
    public DbSet<PropertySpecificationCodeImplementation> PropertySpecificationCodeImplementations { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<NoteContent> NoteContent { get; set; }
    #endregion

    #region Construction
    /// <summary>
    /// Runs once each start of the Application. Only builds on the first run.
    /// </summary>
    /// <param name="modelBuilder">A <see cref="ModelBuilder"/> instance.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CodeFlavour>()
            .HasKey(o => o.Name);

        modelBuilder.Entity<CodeObjectMatrix>()
            .HasKey(o => new { o.CodeFlavour, o.InputType, o.CodeObject });

        modelBuilder.Entity<LookUp>()
            .HasKey(o => o.Id);

        // Class Specification
        modelBuilder.Entity<ClassSpecification>()
            .HasMany(e => e.MethodSpecifications)
            .WithOne(e => e.ClassSpecification)
            .HasForeignKey(o => o.ClassId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<ClassSpecification>()
            .HasMany(e => e.PropertySpecifications)
            .WithOne(e => e.ClassSpecification)
            .HasForeignKey(o => o.ClassId);

        modelBuilder.Entity<PropertySpecification>()
            .HasOne(e => e.ClassSpecification)
            .WithMany(e => e.PropertySpecifications)
            .HasForeignKey(e => e.ClassId)
            .HasPrincipalKey(e => e.Id);
        modelBuilder.Entity<PropertySpecification>()
            .HasMany(e => e.PropertySpecificationCodeImplementations)
            .WithOne(e => e.PropertySpecification)
            .HasForeignKey(e => e.PropertySpecificationId);

        modelBuilder.Entity<MethodSpecification>()
            .HasMany(e => e.ParameterSpecifications)
            .WithOne(e => e.MethodSpecification)
            .HasForeignKey(e => e.MethodId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<ParameterSpecification>()
            .HasOne(e => e.MethodSpecification)
            .WithMany(e => e.ParameterSpecifications)
            .HasForeignKey(e => e.MethodId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<PropertySpecificationCodeImplementation>()
            .HasOne(e => e.PropertySpecification)
            .WithMany(e => e.PropertySpecificationCodeImplementations)
            .HasForeignKey(e => e.PropertySpecificationId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<Note>()
            .HasOne(e => e.NoteContent)
            .WithOne(e => e.Note)
            .HasForeignKey<NoteContent>(e => e.Id)
            .HasPrincipalKey<Note>(e => e.Id);

        modelBuilder.Entity<NoteContent>()
            .HasOne(e => e.Note)
            .WithOne(e => e.NoteContent)
            .HasForeignKey<Note>(e => e.Id)
            .HasPrincipalKey<NoteContent>(e => e.Id);

        // Adjust for table names - This stops the automatic pluralisation on creation
        IMutableEntityType[] entities = [.. modelBuilder.Model.GetEntityTypes()];

        int i = 0;
        while (i < entities.Length)
        {
            IMutableEntityType entity = entities[i++];

            entity.SetTableName(entity.DisplayName());
        }
    }
    #endregion
}
