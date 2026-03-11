using EngulfAndDevourToolkit.Models;

namespace EngulfAndDevourToolkit.Services;

public class ReserveStudyService : IReserveStudyService
{
    public List<AnnualExpenditure> CalculateAnnualExpenditures(List<ReserveComponent> components)
    {
        var result = Enumerable.Range(1, 30)
            .Select(year => new AnnualExpenditure { Year = year, Amount = 0 })
            .ToList();

        foreach (var comp in components)
        {
            if (comp.UsefulLifeYears < 1 || comp.ReplacementCost <= 0) continue;

            for (int year = comp.UsefulLifeYears; year <= 30; year += comp.UsefulLifeYears)
            {
                result[year - 1].Amount += comp.ReplacementCost;
            }
        }
        return result;
    }

    public decimal CalculateTotalExpenditures(List<AnnualExpenditure> annuals)
        => annuals.Sum(x => x.Amount);

    public decimal CalculateMonthlyFeePerUnit(decimal totalExpenditures, int numberOfUnits)
    {
        if (numberOfUnits <= 0) throw new ArgumentException("Number of units must be greater than 0");
        return totalExpenditures / (30 * 12 * numberOfUnits);
    }
}