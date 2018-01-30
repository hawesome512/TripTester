using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
//using System.Diagnostics;

namespace Table2Excel
{
    public class Transform
    {
        /// <summary>
        /// 将内存中的DataTable转成Excel
        /// </summary>
        /// <param name="excelSavePath">Excel保存路径</param>
        /// <param name="sourceTable">内存中的DataTable</param>
        /// <param name="sheetName">在Excel中保存的Sheet名称</param>
        public Transform(string excelSavePath, DataTable sourceTable, string sheetName)
        {
            Object missing = Type.Missing;
            Object format = Excel.XlFileFormat.xlWorkbookDefault;
            int cols = sourceTable.Columns.Count;
            int rows = sourceTable.Rows.Count;

            //TextWriterTraceListener textListener = new TextWriterTraceListener("log.txt");
            //Debug.Listeners.Add(textListener);
            //Debug.AutoFlush = true;



            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Sheets sheets = null;
            Excel.Worksheet newSheet = null; 

            try
            {
                //Debug.WriteLine(DateTime.Now + "：初始化Excel");
                excelApp = new Excel.Application();
                //Debug.WriteLineIf(excelApp!=null,DateTime.Now + "：初始化成功");
                workbook = excelApp.Workbooks.Add(missing);
                sheets = workbook.Sheets;

                //check columns exist
                foreach (Excel.Worksheet sheet in sheets)
                {
                    sheet.Select(missing);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                }

                newSheet = (Excel.Worksheet)sheets.Add(sheets[1], Type.Missing, Type.Missing, Type.Missing);
                newSheet.Name = sheetName;

                //标题栏
                for (int i = 0; i < cols; i++)
                {
                    newSheet.Cells[1, i + 1] = sourceTable.Columns[i].ToString();
                }
                //数据
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        newSheet.Cells[r + 2, c + 1] = sourceTable.Rows[r][c].ToString();
                    }
                }

                workbook.SaveAs(excelSavePath, missing, missing, missing, missing, missing, Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
                workbook.Close(missing, missing, missing);
                excelApp.Quit();
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(newSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheets);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                newSheet = null;
                sheets = null;
                workbook = null;
                excelApp = null;

                GC.Collect();
            }

        }
    }
}
