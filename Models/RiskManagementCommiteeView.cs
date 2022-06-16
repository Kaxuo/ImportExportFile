namespace ExportedPDF.Models
{
    public class RiskManagementCommiteeView
    {
        public RiskManagementCommiteeView(string emergenceDate, string issueDetectedDate, string riskEventBased, string processLevel1, string processLevel2, string midiLinkedIncident, string errorType, string eventDescription, string compensationCalculationDetails, string amountIncidentInCurrency, string currency, string amount, string causeType)
        {
            EmergenceDate = emergenceDate;
            IssueDetectedDate = issueDetectedDate;
            RiskEventBased = riskEventBased;
            ProcessLevel1 = processLevel1;
            ProcessLevel2 = processLevel2;
            MIDILinkedIncident = midiLinkedIncident;
            ErrorType = errorType;
            EventDescription = eventDescription;
            CompensationCalculationDetails = compensationCalculationDetails;
            AmountIncidentInCurrency = amountIncidentInCurrency;
            Currency = currency;
            Amount = amount;
            CauseType = causeType;
        }
        public string EmergenceDate { get; set; }
        public string IssueDetectedDate { get; set; }
        public string RiskEventBased { get; set; }
        public string ProcessLevel1 { get; set; }
        public string ProcessLevel2 { get; set; }
        public string MIDILinkedIncident { get; set; }
        public string ErrorType { get; set; }
        public string EventDescription { get; set; }
        public string CompensationCalculationDetails { get; set; }
        public string AmountIncidentInCurrency { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string CauseType { get; set; }

    }
}
