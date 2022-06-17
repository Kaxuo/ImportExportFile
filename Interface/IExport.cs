using ExportedPDF.Models;

namespace ExportPDF.Interface
{
    public interface IExport
    {
        byte[] GenerateReportAsync(string reportName);
        List<FinancialReport> Import(IFormFile postedFile);
    }
}