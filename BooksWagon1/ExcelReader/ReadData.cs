namespace Bookswagon.ExcelReader
{
    public class Credentials
    {
        public string userName = "";
        public string pass = "";
        public string url = "";
        public string ePass = "";
        public Credentials()
        {
            ExcelOperation.PopulateInCollection(@"C:\Users\Shivani\Desktop\Backup\Hybrid.xlsx");
            userName = ExcelOperation.ReadData(1, "userName");
            pass = ExcelOperation.ReadData(1, "password");
        }
    }
}
