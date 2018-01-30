using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Table2Excel;

namespace TripTester
{
    /// <summary>
    /// 静态常用工具函数类
    /// </summary>
    static class Tools
    {
        public static string[] TestTypes = { "A-L", "B-L", "C-L", "N-L", "A-S", "B-S", "C-S", "N-S", "A-I", "B-I", "C-I", "N-I", "G", "MCR" };

        public static byte[] CRCck(byte[] data)
        {
            byte CRC_L = 0xFF;
            byte CRC_H = 0xFF;   //CRC寄存器 
            byte SH;
            byte SL;
            int j;

            for (int i = 0; i < data.Length; i++)
            {
                CRC_L = (byte)(CRC_L ^ data[i]); //每一个数据与CRC寄存器进行异或 
                for (j = 0; j < 8; j++)
                {
                    SH = CRC_H;
                    SL = CRC_L;
                    CRC_H = (byte)(CRC_H >> 1);      //高位右移一位
                    //CRC_H = (byte)(CRC_H & 0x7F);
                    CRC_L = (byte)(CRC_L >> 1);      //低位右移一位 
                    //CRC_L = (byte)(CRC_L & 0x7F);
                    if ((SH & 0x01) == 0x01) //如果高位字节最后一位为1 
                    {
                        CRC_L = (byte)(CRC_L | 0x80);   //则低位字节右移后前面补1 
                    }             //否则自动补0 
                    if ((SL & 0x01) == 0x01) //如果低位为1，则与多项式码进行异或 
                    {
                        CRC_H = (byte)(CRC_H ^ 0xA0);
                        CRC_L = (byte)(CRC_L ^ 0x01);
                    }
                }
            }

            byte[] rtn = new byte[data.Length + 2];
            data.CopyTo(rtn, 0);
            rtn[data.Length] = CRC_L;
            rtn[data.Length + 1] = CRC_H;
            return rtn;
            //return CRC_L * 256 + CRC_H;
        }

        public static bool CheckCrc(byte[] data)
        {
            byte CRC_L = 0xFF;
            byte CRC_H = 0xFF;   //CRC寄存器 
            byte SH;
            byte SL;
            int j;

            for (int i = 0; i < data.Length-2; i++)
            {
                CRC_L = (byte)(CRC_L ^ data[i]); //每一个数据与CRC寄存器进行异或 
                for (j = 0; j < 8; j++)
                {
                    SH = CRC_H;
                    SL = CRC_L;
                    CRC_H = (byte)(CRC_H >> 1);      //高位右移一位
                    //CRC_H = (byte)(CRC_H & 0x7F);
                    CRC_L = (byte)(CRC_L >> 1);      //低位右移一位 
                    //CRC_L = (byte)(CRC_L & 0x7F);
                    if ((SH & 0x01) == 0x01) //如果高位字节最后一位为1 
                    {
                        CRC_L = (byte)(CRC_L | 0x80);   //则低位字节右移后前面补1 
                    }             //否则自动补0 
                    if ((SL & 0x01) == 0x01) //如果低位为1，则与多项式码进行异或 
                    {
                        CRC_H = (byte)(CRC_H ^ 0xA0);
                        CRC_L = (byte)(CRC_L ^ 0x01);
                    }
                }
            }

            return (CRC_L==data[data.Length-2])&&(CRC_H==data[data.Length-1]);
            //return CRC_L * 256 + CRC_H;
        }


        /// <summary>
        /// 创建标准表结构
        /// </summary>
        /// <returns></returns>
        static DataTable DevicesTable()
        {
            DataTable table = new DataTable();
            DataColumn col;

            col = new DataColumn("DeviceCode");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("FactoryCode");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("ProductNumber");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("ProductDate");
            col.DataType = System.Type.GetType("System.DateTime");
            table.Columns.Add(col);
            col = new DataColumn("BreakType");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("Inm");
            col.DataType = System.Type.GetType("System.Int32");
            table.Columns.Add(col);
            col = new DataColumn("In");
            col.DataType = System.Type.GetType("System.Int32");
            table.Columns.Add(col);
            col = new DataColumn("Imcr");
            col.DataType = System.Type.GetType("System.Int32");
            table.Columns.Add(col);
            col = new DataColumn("Version");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("ControllerType");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("Fn");
            col.DataType = System.Type.GetType("System.Int32");
            table.Columns.Add(col);
            col = new DataColumn("SaveTime");
            col.DataType = System.Type.GetType("System.DateTime");
            table.Columns.Add(col);

            return table;
        }

        static DataTable TestTable()
        {
            DataTable table = new DataTable();
            DataColumn col;

            col = new DataColumn("Time");
            col.DataType = System.Type.GetType("System.DateTime");
            table.Columns.Add(col);
            col = new DataColumn("Item");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("ProductNumber");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("Result");
            col.DataType = System.Type.GetType("System.Int32");
            table.Columns.Add(col);
            col = new DataColumn("Type");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("Ir");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);
            col = new DataColumn("Tr");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);
            col = new DataColumn("I");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);
            col = new DataColumn("T");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);

            return table;
        }

        static DataTable TripTable()
        {
            DataTable table = new DataTable();
            DataColumn col;

            col = new DataColumn("Time");
            col.DataType = System.Type.GetType("System.DateTime");
            table.Columns.Add(col);
            col = new DataColumn("Phase");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("ProductNumber");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("Type");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("Ia");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);
            col = new DataColumn("Ib");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);
            col = new DataColumn("Ic");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);
            col = new DataColumn("In");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);
            col = new DataColumn("Ir");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);
            col = new DataColumn("Tr");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);
            col = new DataColumn("I");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);
            col = new DataColumn("T");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);

            return table;
        }

        public static string ByteTArrayToString(byte[] array, int count)
        {
            string r = string.Empty;
            count = array.Length >= count ? count : array.Length;
            for (int i = 0; i < count; i++)
            {
                r += array[i].ToString("X2")+" ";
            }
            return r;
        }

        public static int HtoD(byte h)
        {
            return h / 16 * 10 + h % 16;
        }

        public static void Table2Excel(string excelSavePath, DataTable sourceTable, string sheetName="sheet")
        {
            new Transform(excelSavePath, sourceTable, sheetName);
        }

        public static void ToExcel(string excelSavePath, DataTable sourceTable)
        {
            int cols = sourceTable.Columns.Count;
            int rows = sourceTable.Rows.Count;
            ExcelWriter excel = new ExcelWriter(excelSavePath);

            excel.BeginWrite();

            //标题栏
            for (int c = 0; c < cols; c++)
            {
                 excel.WriteString((short)0, (short)c, sourceTable.Columns[c].ToString());
            }

            //数据
            string productNumber=null;
            int rowIndex = 0;
            for (int r = 0; r < rows; r++)
            {
                if (productNumber != sourceTable.Rows[r][0].ToString())
                {
                    productNumber = sourceTable.Rows[r][0].ToString();
                    excel.WriteString((short)(r + 1), (short)0, productNumber);
                }
                for (int c = 1; c < cols; c++)
                {
                    excel.WriteString((short)(r + 1), (short)c, sourceTable.Rows[r][c].ToString());
                }
            }

            excel.EndWrite();
        }

        public static void ToCustomedExcel(string excelSavePath,DataTable table)
        {
            
        }

        public static string GetLocation(string registryKey)
        {
            Microsoft.Win32.RegistryKey reg =Microsoft.Win32.Registry.LocalMachine.OpenSubKey(registryKey);
            return reg==null?null:reg.GetValue(null).ToString();
        }
    }
}
