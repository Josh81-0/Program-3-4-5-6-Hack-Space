using EngulfAndDevourToolkit.Models;

namespace EngulfAndDevourToolkit.Services;

public interface IReserveStudyService
{
    Task<List<ReserveComponent>> GetAllAsync();
    Task AddAsync(ReserveComponent item);
    Task UpdateAsync(ReserveComponent item);
    Task DeleteAsync(string name);
    decimal[] CalculateAnnualExpenditures(List<ReserveComponent> components);
    decimal CalculateMonthlyFee(List<ReserveComponent> components, int units);
}