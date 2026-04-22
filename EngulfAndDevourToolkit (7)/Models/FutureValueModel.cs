namespace EngulfAndDevourToolkit.Models;

public class FutureValueModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Principal { get; set; }
    public decimal AnnualRate { get; set; }        // e.g. 0.05 = 5%
    public int Years { get; set; }
    public decimal? FutureValue { get; set; }      // computed result
}