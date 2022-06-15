using System.ComponentModel.DataAnnotations.Schema;

namespace ExportedPDF.Models
{
    public class FinancialReport
    {
        public FinancialReport(string segment, string country, string product, string discountBand, string unitsSold)
        {
            Segment = segment;
            Country = country;
            Product = product;
            DiscountBand = discountBand;
            UnitsSold = unitsSold;
        }

        public string Segment { get; set; }
        public string Country { get; set; }
        public string Product { get; set; }
        [Column("Discount Band")]
        public string DiscountBand { get; set; }
        [Column("Units Sold")]
        public string UnitsSold { get; set; }
    }
}
