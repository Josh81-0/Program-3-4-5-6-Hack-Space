namespace EngulfAndDevourToolkit.Services;

public interface IBalanceSheetService
{
    Task<MemoryStream> GenerateWordDocumentAsync(List<LineItem> assets, List<LineItem> liabilities);
}