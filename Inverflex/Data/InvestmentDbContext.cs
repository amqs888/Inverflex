using Inverflex.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inverflex.Data;

public sealed class InvestmentDbContext(DbContextOptions<InvestmentDbContext> options) : DbContext(options)
{
    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<AdvisorAssignment> AdvisorAssignments => Set<AdvisorAssignment>();
    public DbSet<Instrument> Instruments => Set<Instrument>();
    public DbSet<Portfolio> Portfolios => Set<Portfolio>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<InvestmentOrder> Orders => Set<InvestmentOrder>();
    public DbSet<PriceAlert> PriceAlerts => Set<PriceAlert>();
    public DbSet<ClientNotification> Notifications => Set<ClientNotification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>().HasIndex(x => x.Username).IsUnique();
        modelBuilder.Entity<AdvisorAssignment>().HasIndex(x => new { x.AdvisorId, x.ClientId }).IsUnique();
        modelBuilder.Entity<Instrument>().HasIndex(x => x.Symbol).IsUnique();
        modelBuilder.Entity<Position>().HasIndex(x => new { x.PortfolioId, x.InstrumentId }).IsUnique();
        modelBuilder.Entity<InvestmentOrder>().Property(x => x.Version).IsConcurrencyToken();
        modelBuilder.Entity<InvestmentOrder>().HasIndex(x => new { x.ClientId, x.CreatedAt });
        modelBuilder.Entity<PriceAlert>().HasIndex(x => new { x.ClientId, x.IsTriggered });
        modelBuilder.Entity<InvestmentOrder>().Property(x => x.CreatedAt).HasConversion(new DateTimeOffsetToBinaryConverter());
        modelBuilder.Entity<InvestmentOrder>().Property(x => x.CompletedAt).HasConversion(new DateTimeOffsetToBinaryConverter());
        modelBuilder.Entity<PriceAlert>().Property(x => x.TriggeredAt).HasConversion(new DateTimeOffsetToBinaryConverter());
        modelBuilder.Entity<ClientNotification>().Property(x => x.CreatedAt).HasConversion(new DateTimeOffsetToBinaryConverter());
        modelBuilder.Entity<Portfolio>().HasMany(x => x.Positions).WithOne().HasForeignKey(x => x.PortfolioId);
        modelBuilder.Entity<AppUser>().HasMany(x => x.Portfolios).WithOne().HasForeignKey(x => x.ClientId);
    }
}
