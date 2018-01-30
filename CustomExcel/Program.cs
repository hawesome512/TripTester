using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using System.Data;

namespace CustomExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            Application excelApp = new Application();
            Workbooks excelBooks = excelApp.Workbooks;
            Workbook excelBook = excelBooks.Add(Missing.Value);
            Worksheet excelSheet = excelBook.Sheets.get_Item(2);
            excelSheet.Cells[1, 1] = "aaa";

            excelBook.SaveAs(@"E:\My Work\手持编程器项目\TripTester\CustomExcel\bin\Debug\d", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            excelApp = null;
        }
    }
}
