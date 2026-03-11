using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EngulfAndDevourToolkit.Models;

namespace EngulfAndDevourToolkit.Services;

public class BalanceSheetService : IBalanceSheetService
{
    public async Task<MemoryStream> GenerateWordDocumentAsync(List<LineItem> assets, List<LineItem> liabilities)
    {
        var stream = new MemoryStream();
        using (var wordDoc = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document, true))
        {
            var mainPart = wordDoc.AddMainDocumentPart();
            mainPart.Document = new Document();
            var body = new Body();

            body.Append(CreateParagraph("Balance Sheet", true, 32));
            body.Append(CreateParagraph("Company: Engulf & Devour"));
            body.Append(CreateParagraph($"Date: {DateTime.Now:MMMM dd, yyyy}"));
            body.Append(new Paragraph(new Run(new Break())));

            // Assets
            body.Append(CreateParagraph("Assets", true));
            decimal totalAssets = 0;
            foreach (var a in assets)
            {
                body.Append(CreateParagraph($"{a.Name,-40} {a.Amount,12:C2}"));
                totalAssets += a.Amount;
            }
            body.Append(CreateParagraph($"Total Assets{"",-35} {totalAssets,12:C2}", true));

            body.Append(new Paragraph(new Run(new Break())));

            // Liabilities
            body.Append(CreateParagraph("Liabilities", true));
            decimal totalLiab = 0;
            foreach (var l in liabilities)
            {
                body.Append(CreateParagraph($"{l.Name,-40} {l.Amount,12:C2}"));
                totalLiab += l.Amount;
            }
            body.Append(CreateParagraph($"Total Liabilities{"",-32} {totalLiab,12:C2}", true));

            body.Append(new Paragraph(new Run(new Break())));

            var equity = totalAssets - totalLiab;
            body.Append(CreateParagraph($"Equity{"",-45} {equity,12:C2}", true));

            mainPart.Document.Append(body);
            mainPart.Document.Save();
        }
        stream.Position = 0;
        return stream;
    }

    private Paragraph CreateParagraph(string text, bool bold = false, int size = 20)
    {
        var run = new Run(new Text(text));
        if (bold) run.AppendChild(new Bold());
        run.AppendChild(new RunProperties(new FontSize { Val = size.ToString() }));
        return new Paragraph(run);
    }
}