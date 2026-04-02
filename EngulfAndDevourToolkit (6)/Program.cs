using EngulfAndDevourToolkit.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Database
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=ed-toolkit.db"));

// Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login";
    options.LogoutPath = "/logout";
    options.AccessDeniedPath = "/login";
});

// Services
builder.Services.AddScoped<IBalanceSheetService, BalanceSheetService>();
builder.Services.AddScoped<IReserveStudyService, ReserveStudyService>();

var app = builder.Build();

// Auto-migrate + seed test user
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();

    // Seed default test user
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    if (!userManager.Users.Any())
    {
        var testUser = new IdentityUser { UserName = "accountant@engulf.dev", Email = "accountant@engulf.dev" };
        await userManager.CreateAsync(testUser, "Password123!");
    }
}

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();