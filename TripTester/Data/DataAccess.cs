using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace TripTester
{
    class DataAccess
    {
        private static string conString = "Data Source=Records;Version=3;";
        //读取数据表记录
        public static DataTable ReadTable(string sqlText)
        {
            SQLiteConnection con = null;
            SQLiteCommand command = null;
            SQLiteDataAdapter da= null;
            DataTable dt = new DataTable();
            //string conString = "Data Source=" + System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Trips";//静态方法需用静态field，如何破

            try
            {
                con = new SQLiteConnection(conString);
                command = con.CreateCommand();
                command.CommandText = sqlText;
                da = new SQLiteDataAdapter(command);
                da.Fill(dt);
            }
            catch { }
            finally
            {
                if(da!=null)
                    da.Dispose();
                if (command != null)
                    command.Dispose();
                if (con != null)
                    con.Close();
            }
            return dt;
        }

        public static bool DeleteRecord(string sqlText)
        {
            bool isOk = false;
            SQLiteConnection conn = new SQLiteConnection(conString);
            try
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand(sqlText, conn);
                command.ExecuteNonQuery();
                isOk = true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return isOk;
        }

        //修改数据表记录
        public static bool UpdateTable(DataTable srcTable, string tableName)
        {
            bool isok = false;
            SQLiteConnection con = null;
            SQLiteCommand command = null;
            SQLiteDataAdapter oda = null;
            SQLiteCommandBuilder ocb = null;
            //string conString = "Data Source=" + System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Trips";

            try
            {
                con = new SQLiteConnection(conString);
                command = con.CreateCommand();
                command.CommandText = "SELECT * FROM " + tableName;
                oda = new SQLiteDataAdapter(command);
                ocb = new SQLiteCommandBuilder(oda);
                oda.UpdateCommand = ocb.GetUpdateCommand();
                oda.InsertCommand = ocb.GetInsertCommand();
                oda.DeleteCommand = ocb.GetDeleteCommand();
                oda.Update(srcTable);
                isok = true;
            }
            catch
            { }
            finally
            {
                if(ocb!=null)
                    ocb.Dispose();
                if(oda!=null)
                    oda.Dispose();
                if(command!=null)
                    command.Dispose();
                if(con!=null)
                    con.Close();
            }
            return isok;
        }

    }
}
