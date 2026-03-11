var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register services
builder.Services.AddScoped<IReserveStudyService, ReserveStudyService>();
builder.Services.AddScoped<IBalanceSheetService, BalanceSheetService>();
builder.Services.AddScoped<IDataPersistenceService, JsonDataPersistenceService>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();