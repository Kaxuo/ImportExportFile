namespace ExportedPDF.Models
{
    public class RandomData
    {
        public RandomData(string dataId, string dataName, string anotherData, string fourthData)
        {
            DataId = dataId;
            DataName = dataName;
            AnotherData = anotherData;
            FourthData = fourthData;
        }
        public string DataId { get; set; }
        public string DataName { get; set; }
        public string AnotherData { get; set; }
        public string FourthData { get; set; }

    }
}
