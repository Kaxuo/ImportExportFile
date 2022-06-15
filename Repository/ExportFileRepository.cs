using AspNetCore.Reporting;
using ExcelDataReader;
using ExportedPDF.Models;
using ExportPDF.Interface;
using System.Reflection;
using System.Text;


namespace ExportPDF.Repository
{
    public class ExportFileRepository : IExport
    {
        public byte[] GenerateReportAsync(string reportName)
        {
            // ExportedPDF.dll can be found in bin/debug/.. , needed to find the rdlc file
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("ExportedPDF.dll", string.Empty);
            // Providing the path and file name
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, reportName);
            // Create instance of System Text Encoding 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");
            // File is loaded // 
            LocalReport report = new LocalReport(rdlcFilePath);
            // Simulate data for the report
            List<ProductDto> productList = new List<ProductDto> {
                { new ProductDto("jp", "Blob", "email", "09790709") }, { new ProductDto("Kain", "Dragoon", "email", "09790709") }, { new ProductDto("Cecil", "DK", "email", "09790709") }, { new ProductDto("Vivi", "BLM", "email", "09790709") } };
            // dsProducts needs to match the datasets of the rdlc file, the properties of the model should also matched the fields of the datasets
            report.AddDataSource("dsProducts", productList);
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            // Create render type , pdf, excel or any other
            var result = report.Execute(RenderType.Pdf, 1, parameters);
            return result.MainStream;
        }

        public List<FinancialReport> Import(IFormFile file)
        {
            if (file == null)
            {
                throw new Exception("File not found");
            }
            if (Path.GetExtension(file.FileName) != ".xlsx")
            {
                throw new Exception("Invalid File Type, Please us a .xlsx File");
            }
            List<FinancialReport> allFinanceReportList = new List<FinancialReport>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read()) //Each row of the file
                    {
                        allFinanceReportList.Add(new FinancialReport(reader.GetValue(0).ToString()!, reader.GetValue(1).ToString()!, reader.GetValue(2).ToString()!, reader.GetValue(3).ToString()!, reader.GetValue(4).ToString()!));
                    }
                }
            };
            allFinanceReportList.RemoveAt(0);
            return allFinanceReportList;
        }
    }
}