//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

namespace Bookswagon.ExcelReader
{
    /// <summary>
    /// to read data from excel file
    /// </summary>
    public class Credentials
    {
        public string userName = "";
        public string pass = "";
        public string url = "";
        public string ePass = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="Credentials"/> class
        /// </summary>
        public Credentials()
        {
            ExcelOperation.PopulateInCollection(@"C:\Users\Shivani\Desktop\Backup\Hybrid.xlsx");
            userName = ExcelOperation.ReadData(1, "userName");
            pass = ExcelOperation.ReadData(1, "password");
            ePass = ExcelOperation.ReadData(1, "emailPass");
        }
    }
}
