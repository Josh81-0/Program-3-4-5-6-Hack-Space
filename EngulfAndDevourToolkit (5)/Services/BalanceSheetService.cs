using EngulfAndDevourToolkit.Data;
using EngulfAndDevourToolkit.Models;
using Microsoft.EntityFrameworkCore;

namespace EngulfAndDevourToolkit.Services;

public class BalanceSheetService : IBalanceSheetService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public BalanceSheetService(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<LineItem>> GetAllAsync()
    {
        await using var context = await _factory.CreateDbContextAsync();
        return await context.BalanceSheetItems.ToListAsync();
    }

    public async Task AddAsync(LineItem item)
    {
        await using var context = await _factory.CreateDbContextAsync();
        if (item.Id == 0)
            item.Id = (await context.BalanceSheetItems.MaxAsync(x => (int?)x.Id) ?? 0) + 1;

        context.BalanceSheetItems.Add(item);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LineItem item)
    {
        await using var context = await _factory.CreateDbContextAsync();
        context.BalanceSheetItems.Update(item);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await using var context = await _factory.CreateDbContextAsync();
        var item = await context.BalanceSheetItems.FindAsync(id);
        if (item != null)
        {
            context.BalanceSheetItems.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}