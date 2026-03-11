using EngulfAndDevourToolkit.Models;

namespace EngulfAndDevourToolkit.Services;

public interface IReserveStudyService
{
    List<AnnualExpenditure> CalculateAnnualExpenditures(List<ReserveComponent> components);
    decimal CalculateTotalExpenditures(List<AnnualExpenditure> annuals);
    decimal CalculateMonthlyFeePerUnit(decimal totalExpenditures, int numberOfUnits);
}