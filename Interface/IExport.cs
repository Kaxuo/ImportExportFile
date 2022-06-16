using ExportedPDF.Models;

namespace ExportPDF.Interface
{
    public interface IExport
    {
        byte[] GenerateReportAsync();
        List<FinancialReport> Import(IFormFile postedFile);
    }
}