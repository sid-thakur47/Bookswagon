//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Bookswagon.ExcelReader
{
   public class ExcelOperation
    {
        public static List<Datacollection> dataCol = new List<Datacollection>();
        private static DataTable ExcelToDataTable(String filename)
        {
            //open file and returns as Stream
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            //Createopenxmlreader via ExcelReaderFactory
            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //Return as DataSet
            DataSet resultSet = excelDataReader.AsDataSet(new ExcelDataSetConfiguration() // does not read excel header
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTableCollection table = resultSet.Tables;
            DataTable resultTable = table["MyTable"];
            stream.Close();
            return resultTable;
        }

        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colvalue { get; set; }
        }

        public static void PopulateInCollection(String filename)
        {
            DataTable table = ExcelToDataTable(filename);
            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colvalue = table.Rows[row - 1][col].ToString()

                    };
                    //Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            string data = (from colData in dataCol where colData.colName == columnName && colData.rowNumber == rowNumber select colData.colvalue).FirstOrDefault();
            return data.ToString();
        }
    }
}

