namespace Bookswagon.ExcelReader
{
    public class Credentials
    {
        public string userName = "";
        public string pass = "";
        public string title = "";
        public string url = "";
        public Credentials()
        {
            ExcelOperation.PopulateInCollection(@"C:\Users\Shivani\Desktop\Backup\Hybrid.xlsx");
            userName = ExcelOperation.ReadData(1, "userName");
            pass = ExcelOperation.ReadData(1, "password");
            title = ExcelOperation.ReadData(1, "title");
            url = ExcelOperation.ReadData(1, "url");
        }
    }
}
