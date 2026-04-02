using EngulfAndDevourToolkit.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EngulfAndDevourToolkit.Data;

public class AppDbContext : IdentityDbContext
{
    public DbSet<LineItem> BalanceSheetItems { get; set; } = null!;
    public DbSet<ReserveComponent> ReserveComponents { get; set; } = null!;
    public DbSet<ContactSubmission> ContactSubmissions { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}