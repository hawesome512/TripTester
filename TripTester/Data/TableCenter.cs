using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TripTester
{

    public class TableCenter
    {
        static Dictionary<int, double[]> mods = new Dictionary<int, double[]>()
        {
            {76,new double[]{1,0.1,1,0.1}},
            {83,new double[]{1,0.001,1,0.01}},
            {73,new double[]{1,0.01,1,0.01}},
            {71,new double[]{1,0.001,1,0.01}},
            {80,new double[]{1,1,0.1,0.01}},
            {82,new double[]{1,0.01,1,0.01}},
        };
        static Dictionary<int, string[]> units = new Dictionary<int, string[]>()
        {
            {76,new string[]{"r",""}},
            {83,new string[]{"sd",""}},
            {73,new string[]{"i",""}},
            {71,new string[]{"g",""}},
            {80,new string[]{"u","%"}},
            {82,new string[]{"i",""}},
        };
        /// <summary>
        /// 创建标准表结构
        /// </summary>
        /// <returns></returns>
        public static DataTable getDeviceTable()
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

        public static void genDeviceRow(ref DataRow deviceRow, byte[] rcv)
        {
            int Inm = rcv[14] * 256 + rcv[15];
            deviceRow["DeviceCode"] = "BW-"+Inm;
            deviceRow["FactoryCode"] = "Shihlin Electirc";
            deviceRow["ProductNumber"] = (rcv[4] * 256 + rcv[5]).ToString("D4") + (rcv[6] * 256 + rcv[7]).ToString("D3");
            deviceRow["ProductDate"] = genTime(2000 + rcv[8] * 256 + rcv[9], rcv[10], rcv[11]);
            deviceRow["Inm"] = rcv[14] * 256 + rcv[15];
            deviceRow["In"] = rcv[16] * 256 + rcv[17];
            deviceRow["Imcr"] = rcv[18] + rcv[19];
            int nInm = Inm == 2000 ? 1 : (Inm == 3200 ? 2 : 3);
            deviceRow["BreakType"] = string.Format("XSIC-P{0}G{1}", rcv[13], nInm);
            deviceRow["Version"] = "";
            deviceRow["ControllerType"] = "";
            deviceRow["Fn"] = rcv[24] * 256 + rcv[25];
            deviceRow["SaveTime"] = DateTime.Now;
        }

        public static DataTable getTestTable()
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
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("Type");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("Iset");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("Tset");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("I");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);
            col = new DataColumn("T");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);

            return table;
        }

        public static void genTestRow(ref DataRow testRow, string productNumber, string item, byte[] rcv)
        {
            testRow["ProductNumber"] = productNumber;
            testRow["Item"] = item;
            testRow["Result"] = rcv[1]==79?"OK":"NG";
            testRow["Time"] = genTime(2000 + cbd(rcv[2]), cbd(rcv[3]), cbd(rcv[4]), cbd(rcv[5]), cbd(rcv[6]), cbd(rcv[7]));
            testRow["Type"] = genType(rcv[9]);
            testRow["Iset"] = genValue(rcv[9], 0, rcv[10], rcv[11], "I"); //rcv[10] * 256 + rcv[11];
            testRow["Tset"] = genValue(rcv[9], 1, rcv[12], rcv[13], "T");// rcv[12] * 256 + rcv[13];
            testRow["I"] = genNum(rcv[9], 2, rcv[14], rcv[15]); //rcv[14] * 256 + rcv[15];
            testRow["T"] = genNum(rcv[9], 3, rcv[16], rcv[17]); //rcv[16] * 256 + rcv[17];
        }

        public static DataTable getTripTable()
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
            col = new DataColumn("Iset");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("Tset");
            col.DataType = System.Type.GetType("System.String");
            table.Columns.Add(col);
            col = new DataColumn("I");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);
            col = new DataColumn("T");
            col.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(col);

            return table;
        }

        public static void genTripRow(ref DataRow tripRow, string productNumber, byte[] rcv)
        {
            tripRow["ProductNumber"] = productNumber;
            tripRow["Time"] = genTime(2000 + cbd(rcv[0]), cbd(rcv[1]), cbd(rcv[2]), cbd(rcv[3]), cbd(rcv[4]), cbd(rcv[5]));
            tripRow["Phase"] = rcv[7] == 0 || rcv[7] == 255 ? "-" : char.ConvertFromUtf32(rcv[7]);
            tripRow["Type"] = genType(rcv[9]);
            tripRow["Ia"] = genNum(rcv[9], 2, rcv[10], rcv[11]);// rcv[10] * 256 + rcv[11];
            tripRow["Ib"] = genNum(rcv[9], 2, rcv[12], rcv[13]);//rcv[12] * 256 + rcv[13];
            tripRow["Ic"] = genNum(rcv[9], 2, rcv[14], rcv[15]);//rcv[14] * 256 + rcv[15];
            tripRow["In"] = genNum(rcv[9], 2, rcv[16], rcv[17]);//rcv[16] * 256 + rcv[17];
            tripRow["Iset"] = genValue(rcv[9], 0, rcv[18], rcv[19], "I");//rcv[18] * 256 + rcv[19];
            tripRow["Tset"] = genValue(rcv[9], 1, rcv[20], rcv[21], "T");//rcv[20] * 256 + rcv[21];
            tripRow["I"] = genNum(rcv[9], 2, rcv[22], rcv[23]); //rcv[22] * 256 + rcv[23];
            tripRow["T"] = genNum(rcv[9], 3, rcv[24], rcv[25]); //rcv[24] * 256 + rcv[25];
        }

        private static int cbd(int source)
        {
            return int.Parse(source.ToString("x"));
        }

        private static DateTime genTime(int year, int month, int day, int hour = 0, int minute = 0, int secend = 0)
        {
            month = month == 0 ? 1 : month;
            day = day == 0 ? 1 : day;
            return new DateTime(year, month, day, hour, minute, secend);
        }

        private static string genType(int type)
        {
            switch (type)
            {
                case 76:
                    return "Overload";
                case 83:
                    return "Short";
                case 73:
                    return "Instant";
                case 71:
                    return "Ground";
                case 82:
                    return "MCR";
                case 80:
                    return "OpenPhase";
                default:
                    return "Unknown";
            }
        }

        private static double genNum(int type, int index, int first, int secend)
        {
            double temp = first * 256 + secend;
            if (mods.ContainsKey(type))
            {
                temp =Math.Round(temp*mods[type][index],3);
            }
            return temp;
        }

        private static string genValue(int type, int index, int first, int secend, string IorT)
        {
            double temp = genNum(type, index, first, secend);
            string[] unit = new string[2];
            if (units.ContainsKey(type))
            {
                unit = units[type];
            }
            return string.Format("{2}{3}({0}{1})", IorT, unit[0], temp, unit[1]);
        }
    }
}
