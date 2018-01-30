using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;

namespace TripTester
{
    public class CustomizedExcel
    {
        public static bool SaveExcel(string savePath, System.Data.DataTable tripTable,System.Data.DataTable testTable)
        {
            try
            {
                Application excelApp = new Application();
                Workbooks excelBooks = excelApp.Workbooks;
                Workbook excelBook = excelBooks.Add(Missing.Value);
                Sheets sheets = excelBook.Sheets;
                Worksheet tripSheet = ((Worksheet)sheets.get_Item(1));
                Worksheet testSheet = ((Worksheet)sheets.get_Item(2));
                fillData(ref tripSheet, "Trip", tripTable);
                fillData(ref testSheet, "Test", testTable);
                excelBook.SaveAs(savePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                excelBook.Close(Missing.Value, Missing.Value, Missing.Value);
                excelBooks.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                excelApp = null;
                return true;
            }
            catch(Exception exp)
            {
                MsgBox.Show(exp.Message);
                return false;
            }
        }

        private static void fillData(ref Worksheet sheet,string name, System.Data.DataTable table)
        {
            sheet.Name = name;
            int colCount=table.Columns.Count;
            int rowCount=table.Rows.Count;
            string lastCol=char.ConvertFromUtf32(colCount + 64);

            //标题
            Range titleRange = sheet.get_Range("A1",lastCol+"1");
            titleRange.Font.Size = 16;
            titleRange.Font.Bold = true;
            titleRange.Font.ColorIndex = 2;//白色
            titleRange.Interior.ColorIndex = 50;//seagreen
            titleRange.ColumnWidth = 8;
            titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            titleRange.Borders.LineStyle = 1;

            sheet.Cells[1, 1] = "ID";
            for (int i = 1; i < colCount; i++)
            {
                string colName=table.Columns[i].ToString();
                sheet.Cells[1, i + 1] = colName;
                if (colName.Contains("Time"))
                {
                    ((Range)(sheet.Cells[1, i + 1])).ColumnWidth = 16;
                }
                else if (colName.Contains("set"))
                {
                    ((Range)(sheet.Cells[1, i + 1])).ColumnWidth = 12;
                }
            }


            string productNumber = null;
            int record = 0;
            for (int r = 0; r < table.Rows.Count; r++)
            {
                if (productNumber != table.Rows[r][0].ToString())
                {
                    //合并单元格
                    if (record != 0)
                    {
                        setSeperator(sheet, lastCol, record, r);
                    }
                    productNumber = table.Rows[r][0].ToString();
                    sheet.Cells[r + 2, 1] = productNumber;
                    record = 1;
                }
                else
                {
                    record++;
                }
                for (int c = 1; c < colCount; c++)
                {
                    sheet.Cells[r+2,c+1]=table.Rows[r][c].ToString();
                }
                if (r % 2 == 1)
                {
                    sheet.get_Range("B" + (r + 2), lastCol + (r + 2)).Interior.ColorIndex = 15; 
                }
                if (r == table.Rows.Count - 1)
                {
                    setSeperator(sheet, lastCol, record, r+1);
                }
            }
        }

        private static void setSeperator(Worksheet sheet, string lastCol, int record, int r)
        {
            Range idRange = sheet.get_Range("A" + (r + 2 - record), "A" + (r + 2 - 1));
            idRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            idRange.Merge(Missing.Value);

            Range dvRange = sheet.get_Range("A" + (r + 2 - record), lastCol + (r + 2 - 1));
            dvRange.Borders.LineStyle = 1;
        }
    }
}
