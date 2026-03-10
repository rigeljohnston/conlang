using ConlangCreator.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ConlangCreator.Data;

public class ConlangDbContext : DbContext
{
    public ConlangDbContext(DbContextOptions<ConlangDbContext> options) : base(options) { }

    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Phoneme> Phonemes => Set<Phoneme>();
    public DbSet<SyllableRule> SyllableRules => Set<SyllableRule>();
    public DbSet<PhonologicalRule> PhonologicalRules => Set<PhonologicalRule>();
    public DbSet<RomanizationMapping> RomanizationMappings => Set<RomanizationMapping>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Endonym).HasMaxLength(200);
            entity.HasIndex(e => e.UserId);
        });

        modelBuilder.Entity<Phoneme>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.IpaSymbol).IsRequired().HasMaxLength(10);
            entity.HasOne(e => e.Language)
                .WithMany(l => l.Phonemes)
                .HasForeignKey(e => e.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(e => new { e.LanguageId, e.IpaSymbol }).IsUnique();
        });

        modelBuilder.Entity<SyllableRule>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Template).IsRequired().HasMaxLength(50);
            entity.HasOne(e => e.Language)
                .WithMany(l => l.SyllableRules)
                .HasForeignKey(e => e.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PhonologicalRule>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Input).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Output).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Environment).HasMaxLength(100);
            entity.HasOne(e => e.Language)
                .WithMany(l => l.PhonologicalRules)
                .HasForeignKey(e => e.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<RomanizationMapping>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Romanization).IsRequired().HasMaxLength(20);
            entity.HasOne(e => e.Language)
                .WithMany(l => l.RomanizationMappings)
                .HasForeignKey(e => e.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Phoneme)
                .WithMany(p => p.RomanizationMappings)
                .HasForeignKey(e => e.PhonemeId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
