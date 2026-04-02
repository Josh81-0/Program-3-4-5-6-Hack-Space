using EngulfAndDevourToolkit.Models;

namespace EngulfAndDevourToolkit.Services;

public interface IBalanceSheetService
{
    Task<List<LineItem>> GetAllAsync();
    Task AddAsync(LineItem item);
    Task UpdateAsync(LineItem item);
    Task DeleteAsync(int id);
}