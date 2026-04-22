using EngulfAndDevourToolkit.Data;
using EngulfAndDevourToolkit.Models;
using Microsoft.EntityFrameworkCore;

namespace EngulfAndDevourToolkit.Services;

public class ReserveStudyService : IReserveStudyService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public ReserveStudyService(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<ReserveComponent>> GetAllAsync()
    {
        await using var context = await _factory.CreateDbContextAsync();
        return await context.ReserveComponents.ToListAsync();
    }

    public async Task AddAsync(ReserveComponent item)
    {
        await using var context = await _factory.CreateDbContextAsync();
        context.ReserveComponents.Add(item);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ReserveComponent item)
    {
        await using var context = await _factory.CreateDbContextAsync();
        context.ReserveComponents.Update(item);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string name)
    {
        await using var context = await _factory.CreateDbContextAsync();
        var item = await context.ReserveComponents.FirstOrDefaultAsync(x => x.Name == name);
        if (item != null)
        {
            context.ReserveComponents.Remove(item);
            await context.SaveChangesAsync();
        }
    }

    public decimal[] CalculateAnnualExpenditures(List<ReserveComponent> components)
    {
        var exp = new decimal[30];
        foreach (var c in components)
        {
            if (c.UsefulLifeYears <= 0) continue;
            for (int y = c.UsefulLifeYears; y <= 30; y += c.UsefulLifeYears)
                exp[y - 1] += c.ReplacementCost;
        }
        return exp;
    }

    public decimal CalculateMonthlyFee(List<ReserveComponent> components, int units)
    {
        if (units <= 0) return 0;
        var total = CalculateAnnualExpenditures(components).Sum();
        return total / (30m * 12 * units);
    }
}