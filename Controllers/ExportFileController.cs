using ExportedPDF.Models;
using ExportPDF.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ExportPDF.Controllers
{
    [ApiController]
    public class ExportFileController : ControllerBase
    {
        private readonly IExport _exportRepository;
        public ExportFileController(IExport repository)
        {
            _exportRepository = repository;
        }

        [HttpGet("{reportName}")]
        public ActionResult Generate(string reportname)
        {
            try
            {
                var reportFileByteString = _exportRepository.GenerateReportAsync(reportname);
                // Provile values to the report //
                return File(reportFileByteString, MediaTypeNames.Application.Octet, "Report" + ".pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPost("send")]
        public ActionResult<List<FinancialReport>> Send(IFormFile file)
        {

            try
            {
                var value = _exportRepository.Import(file);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}