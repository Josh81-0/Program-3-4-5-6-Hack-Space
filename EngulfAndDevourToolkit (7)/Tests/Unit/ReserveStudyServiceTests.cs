using EngulfAndDevourToolkit.Models;
using EngulfAndDevourToolkit.Services;
using Xunit;

namespace EngulfAndDevourToolkit.Tests;

public class ReserveStudyServiceTests
{
    private readonly IReserveStudyService _service = new ReserveStudyService();

    [Fact]
    public void CalculateAnnualExpenditures_TypicalCase_CorrectScheduling()
    {
        var components = new List<ReserveComponent>
        {
            new() { Name = "Roof", UsefulLifeYears = 5, ReplacementCost = 10000 }
        };

        var result = _service.CalculateAnnualExpenditures(components);

        Assert.Equal(6, result.Count(x => x.Amount == 10000)); // years 5,10,15,20,25,30
        Assert.Equal(60000, result.Sum(x => x.Amount));
    }

    [Fact]
    public void CalculateMonthlyFeePerUnit_ValidInput_CorrectResult()
    {
        var fee = _service.CalculateMonthlyFeePerUnit(360000, 200);
        Assert.Equal(5m, fee); // 360000 / (30*12*200) = 5
    }

    [Fact]
    public void CalculateMonthlyFeePerUnit_ZeroUnits_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
            _service.CalculateMonthlyFeePerUnit(100000, 0));
    }
}