using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace TripTester
{
    class SQLiteHelper
    {
        private static string conString = "Data Source=Records;Version=3;";

        public static void InitDB()
        {
            SQLiteConnection.CreateFile("Records");
            SQLiteConnection conn = new SQLiteConnection(conString);
            try
            {
                conn.Open();

                string sql0 = "create table TestDevices (DeviceCode string,FactoryCode string,ProductNumber string,ProductDate datetime,BreakType string,Inm int,[In] int,Imcr int,Version string,ControllerType string,Fn int,SaveTime datetime,Primary Key(ProductNumber) ON CONFLICT Replace)";
                SQLiteCommand command0 = new SQLiteCommand(sql0, conn);
                command0.ExecuteNonQuery();

                string sql1 = "create table TestRecords (ProductNumber string,Item string,Time datetime,Result string,Type string,Iset string,Tset string,I double,T double,Primary Key(ProductNumber,Item,Time) ON CONFLICT Replace)";
                SQLiteCommand command1 = new SQLiteCommand(sql1, conn);
                command1.ExecuteNonQuery();

                string sql2 = "create table TripDevices (DeviceCode string,FactoryCode string,ProductNumber string,ProductDate datetime,BreakType string,Inm int,[In] int,Imcr int,Version string,ControllerType string,Fn int,SaveTime datetime,Primary Key(ProductNumber) ON CONFLICT Replace)";
                SQLiteCommand command2 = new SQLiteCommand(sql2, conn);
                command2.ExecuteNonQuery();

                string sql3 = "create table TripRecords (ProductNumber string,Time datetime,Phase string,Type string,Ia double,Ib double,Ic double,[In] double,Iset string,Tset string,I double,T double,Primary Key(ProductNumber,Time) ON CONFLICT Replace)";
                SQLiteCommand command3 = new SQLiteCommand(sql3, conn);
                command3.ExecuteNonQuery();

                conn.Close();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public static DataTable ReadTable()
        {
            //string conString = "Data Source=Trips;Version=3;";
            SQLiteConnection conn = new SQLiteConnection(conString);
            SQLiteConnection con = null;
            SQLiteCommand command = null;
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {

                string sql = string.Format("select * from Trips");
                command = new SQLiteCommand(sql, conn);
                da = new SQLiteDataAdapter(command);
                da.Fill(dt);
            }
            catch { }
            finally
            {
                if (da != null)
                    da.Dispose();
                if (command != null)
                    command.Dispose();
                if (con != null)
                    con.Close();
            }
            DataTable newTable = TableCenter.getTestTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = newTable.NewRow();

                row["ProductNumber"] = dt.Rows[i]["ProductNumber"];
                row["Item"] = dt.Rows[i]["Item"];
                row["Time"] = dt.Rows[i]["Time"];
                row["Result"] = dt.Rows[i]["Result"];
                row["Type"] = dt.Rows[i]["Type"];
                row["Ir"] = dt.Rows[i]["Ir"];
                row["Tr"] = dt.Rows[i]["Tr"];
                row["I"] = dt.Rows[i]["I"];
                row["T"] = dt.Rows[i]["T"];

                //if (i >= 3 && i < dt.Rows.Count - 1)
                //{
                //    continue;
                //}
                //row["DeviceCode"] = "DW45";
                //row["FactoryCode"] = "Shihlin Electric";
                //row["ProductNumber"] = dt.Rows[i]["ProductNumber"];
                //row["ProductDate"] = dt.Rows[i]["ProductDate"];
                //row["ProductNumber"] = dt.Rows[i]["ProductNumber"];
                //row["BreakType"] = "XSIC-P3G1";
                //row["Inm"] = dt.Rows[i]["Inm"];
                //row["In"] = dt.Rows[i]["In"];
                //row["Imcr"] = dt.Rows[i]["Imcr"];
                //row["Version"] = dt.Rows[i]["Version"];
                //row["ControllerType"] = dt.Rows[i]["ControllerType"];
                //row["Fn"] = dt.Rows[i]["Fn"];
                //row["SaveTime"] = DateTime.Now;
                //if (dt.Rows[i]["Inm"].ToString() == "1")
                //{
                //    row["Inm"] = "2000";
                //}

                newTable.Rows.Add(row);
            }
            return newTable;
        }

        //修改数据表记录
        public static void UpdateDeviceTable()
        {
            SQLiteConnection con = null;
            SQLiteCommand command = null;
            SQLiteDataAdapter oda = null;
            SQLiteCommandBuilder ocb = null;

            try
            {
                con = new SQLiteConnection(conString);
                command = con.CreateCommand();
                command.CommandText = "select * from TestDevices";
                oda = new SQLiteDataAdapter(command);
                ocb = new SQLiteCommandBuilder(oda);
                oda.UpdateCommand = ocb.GetUpdateCommand();
                oda.InsertCommand = ocb.GetInsertCommand();
                oda.DeleteCommand = ocb.GetDeleteCommand();

                byte[] rcv = ACBTester.genDeviceInfo();
                DataTable dt = TableCenter.getDeviceTable() ;
                DataRow deviceRow = dt.NewRow();
                deviceRow["DeviceCode"] = "DW45";
                deviceRow["FactoryCode"] = "Shihlin Electirc";
                deviceRow["ProductNumber"] = (rcv[7] * 256 + rcv[8]).ToString("D4") + (rcv[9] * 256 + rcv[10]).ToString("D4");
                deviceRow["ProductDate"] = new DateTime(rcv[11] * 256 + rcv[12], rcv[13], rcv[14]);
                deviceRow["Inm"] = rcv[17] * 256 + rcv[18];
                deviceRow["In"] = rcv[19] * 256 + rcv[20];
                deviceRow["Imcr"] = rcv[21] + rcv[22];

                int Inm = rcv[17] * 256 + rcv[18];
                int nInm = Inm == 2000 ? 1 : (Inm == 3200 ? 2 : 3);
                deviceRow["BreakType"] = string.Format("XSIC-P{0}G{1}", rcv[16], nInm);
                deviceRow["Version"] = "";
                deviceRow["ControllerType"] = "";
                deviceRow["Fn"] = rcv[27] * 256 + rcv[28];
                deviceRow["SaveTime"] = DateTime.Now;
                dt.Rows.Add(deviceRow);

                int n = oda.Update(dt);
            }
            catch
            { }
            finally
            {
                if (ocb != null)
                    ocb.Dispose();
                if (oda != null)
                    oda.Dispose();
                if (command != null)
                    command.Dispose();
                if (con != null)
                    con.Close();
            }
        }

        //修改数据表记录
        public static void UpdateTable1(string key)
        {
            SQLiteConnection conn = new SQLiteConnection(conString);
            try
            {
                conn.Open();
                string sql =string.Format("delete from TestDevices where ProductNumber=='{0}'",key);
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                int n=command.ExecuteNonQuery();

            }
            catch { }
            finally
            {
                conn.Close();
            }
        }
    }
}
