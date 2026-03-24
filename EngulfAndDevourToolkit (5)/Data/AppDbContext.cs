using EngulfAndDevourToolkit.Models;
using Microsoft.EntityFrameworkCore;

namespace EngulfAndDevourToolkit.Data;

public class AppDbContext : DbContext
{
    public DbSet<LineItem> BalanceSheetItems { get; set; } = null!;
    public DbSet<ReserveComponent> ReserveComponents { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}