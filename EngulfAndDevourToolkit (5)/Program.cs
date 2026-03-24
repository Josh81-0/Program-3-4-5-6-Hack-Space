using EngulfAndDevourToolkit.Data;
using EngulfAndDevourToolkit.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// EF Core + SQLite
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=ed-toolkit.db"));

// Services
builder.Services.AddScoped<IBalanceSheetService, BalanceSheetService>();
builder.Services.AddScoped<IReserveStudyService, ReserveStudyService>();

var app = builder.Build();

// Auto-migrate database on startup
using (var scope = app.Services.CreateScope())
{
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    await using var context = await factory.CreateDbContextAsync();
    await context.Database.MigrateAsync();
}

app.UseStaticFiles();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();