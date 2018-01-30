using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Data;
using Microsoft.Win32;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TripTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double dLine;
        public MainWindow()
        {
            InitializeComponent();
            initControls();
        }

        void initControls()
        {
            System.Drawing.Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            dLine = Math.Sqrt(Math.Pow(screen.Width, 2) + Math.Pow(screen.Height, 2));
            invokeBlueSoleil();
            //SQLiteHelper.InitDB();
            rb_trip.IsChecked = true;
            comPage.Completed += (s, e) =>
            {
                freshDisplay();
            };
            string lan = Hawesome.Tools.GetConfig("LanUpdate");
            string wan = Hawesome.Tools.GetConfig("WanUpdate");
            string programName = lan.Split('/').Last();
            Hawesome.Tools.CloseWindow += (s, o) =>
            {
                this.Close();
            };

            Version now = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Hawesome.Tools.CheckUpdate(this, programName, now, lan, wan, "en");
        }

        //更新DisplayTable
        private void freshDisplay()
        {
            bool checkTrip = (bool)rb_trip.IsChecked;
            Task.Factory.StartNew(new Action(() =>
            {
                string queryDevices = String.Format("Select * From MAIN.[{0}]", checkTrip ? "TripDevices" : "TestDevices");
                DataTable devices = DataAccess.ReadTable(queryDevices);
                DataColumn col = new DataColumn("Results");
                col.DataType = Type.GetType("System.String");
                col.DefaultValue = "-";
                devices.Columns.Add(col);
                if (!checkTrip)
                {
                    string queryRecords = "Select result From MAIN.[TestRecords] where productnumber='{0}' and item='{1}'  order by time desc Limit 1";
                    for (int r = 0; r < devices.Rows.Count; r++)
                    {
                        string result = "OK";
                        for (int i = 0; i < Tools.TestTypes.Length; i++)
                        {
                            DataTable temp = DataAccess.ReadTable(queryRecords.Replace("{0}", devices.Rows[r]["ProductNumber"].ToString()).Replace("{1}", Tools.TestTypes[i]));
                            if (temp.Rows.Count == 0)
                            {
                                continue;
                            }
                            result = temp.Rows[0][0].ToString();
                            if (result == "NG")
                            {
                                break;
                            }
                        }
                        devices.Rows[r]["Results"] = result;
                    }
                }
                //按导入时间排序
                System.Data.DataView dv = devices.DefaultView;
                dv.Sort = "SaveTime desc";
                this.Dispatcher.Invoke(new Action(() =>
                {
                    this.dataGridDisplay.ItemsSource = dv;// devices.DefaultView;
                }));
            }));
        }

        private void dataGridDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView selectedRow = dataGridDisplay.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                bool checkTrip = (bool)rb_trip.IsChecked;
                if (checkTrip)
                {
                    tripDetail.DataContext = selectedRow;
                    String sql = "Select * from MAIN.[TripRecords] where productnumber='" + selectedRow["ProductNumber"] + "' order by time desc";
                    DataTable trips = DataAccess.ReadTable(sql);
                    System.Data.DataView dv = trips.DefaultView;
                    tripDetail.dataGridDisplay.ItemsSource = dv;
                    tripDetail.Visibility = Visibility.Visible;
                    testDetail.Visibility = Visibility.Hidden;
                    //double dLine = Math.Sqrt(Math.Pow(tripDetail.Width, 2) + Math.Pow(tripDetail.Height, 2));
                    Hawesome.Tools.UseCircleAnimation(tripDetail, new Point(0, 0), 0, dLine, 0.5);
                }
                else
                {
                    //设定数据源
                    testDetail.DataContext = selectedRow;
                    setDC();

                    testDetail.Visibility = Visibility.Visible;
                    tripDetail.Visibility = Visibility.Hidden;
                    //double dLine = Math.Sqrt(Math.Pow(testDetail.Width, 2) + Math.Pow(testDetail.Height, 2));
                    Hawesome.Tools.UseCircleAnimation(testDetail, new Point(0, 0), 0, dLine, 0.5);
                }
            }
        }

        //设定详细测试记录的DataContext
        private void setDC()
        {
            string queryString = "Select productnumber,item, result,max(time) as LastTime,type,iset,tset,i,t From MAIN.[TestRecords] where productnumber='" + testDetail.labelID.Content.ToString() + "' and item='{0}'  order by LastTime desc Limit 1";

            testDetail.labelAL.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[0]));
            testDetail.labelBL.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[1]));
            testDetail.labelCL.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[2]));
            testDetail.labelNL.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[3]));
            testDetail.labelAS.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[4]));
            testDetail.labelBS.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[5]));
            testDetail.labelCS.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[6]));
            testDetail.labelNS.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[7]));
            testDetail.labelAI.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[8]));
            testDetail.labelBI.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[9]));
            testDetail.labelCI.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[10]));
            testDetail.labelNI.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[11]));
            testDetail.labelAG.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[12]));
            testDetail.labelMIC.DataContext = DataAccess.ReadTable(queryString.Replace("{0}", Tools.TestTypes[13]));
        }

        private void Window_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btn_close_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_min_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_import_Click_1(object sender, RoutedEventArgs e)
        {
            Coms coms = new Coms();
            coms.Update += coms_Update;
            comPage.startCom(dLine);
        }

        void coms_Update(object sender, ComsEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                comPage.pbar_Com.Value = e.ComValue;
                comPage.pbar_Import.Value = e.ImportValue;
                comPage.grid_fail.Visibility = e.State == ComState.FAILED ? Visibility.Visible : Visibility.Hidden;
                comPage.grid_success.Visibility = e.State == ComState.SUCCESSED ? Visibility.Visible : Visibility.Hidden;
                if (e.State != ComState.LOADING)
                {
                    comPage.endCom();
                }
                if (e.State == ComState.SUCCESSED)
                {
                    freshDisplay();
                }
                if (e.State == ComState.FAILED)
                {
                    invokeBlueSoleil();
                }
            }));
        }

        private static void invokeBlueSoleil()
        {
            string registryKey = Hawesome.Tools.GetConfig("BlueSoleilKey");
            string location = Tools.GetLocation(registryKey);
            if (location == null)
            {
                DialogResult result = Hawesome.MsgBox.Show("Your computer needs to install [BlueSoleil].Install now?", "More...", Hawesome.MsgBox.Buttons.YesNo, Hawesome.MsgBox.Icons.Info, "en");
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string parentDir = Directory.GetParent(Environment.CurrentDirectory).FullName;
                    string installPath = parentDir + "\\BlueSoeil\\setup.exe";
                    if (File.Exists(installPath))
                    {
                        System.Diagnostics.Process.Start(installPath);
                    }
                    else
                    {
                        Hawesome.MsgBox.Show("Can't find [BlueSoleil] on your computer,you can try manual installation.", "Error", Hawesome.MsgBox.Buttons.OK, Hawesome.MsgBox.Icons.Error, "en");
                    }
                }
            }
            else
            {
                System.Diagnostics.Process progress = System.Diagnostics.Process.Start(location);
            }
        }

        private void deleteRecord(object sender, MouseButtonEventArgs e)
        {
            var key = (sender as Image).Tag.ToString();
            DialogResult result = Hawesome.MsgBox.Show("Confirm to delete this record?\r\nID:" + key, "Delete", Hawesome.MsgBox.Buttons.YesNo, Hawesome.MsgBox.Icons.Question, "en");
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                bool checkTrip = (bool)rb_trip.IsChecked;
                string deviceTable = checkTrip ? "TripDevices" : "TestDevices";
                string recordTable = checkTrip ? "TripRecords" : "TripRecords";
                string deviceSql = string.Format("delete from {0} where ProductNumber=='{1}'", deviceTable, key);
                string recordSql = string.Format("delete from {0} where ProductNumber=='{1}'", recordTable, key);
                DataAccess.DeleteRecord(deviceSql);
                DataAccess.DeleteRecord(recordSql);
                freshDisplay();
            }
        }

        private void checkChanged(object sender, RoutedEventArgs e)
        {
            freshDisplay();
        }

        private void btn_excel_Click_1(object sender, RoutedEventArgs e)
        {
            new Task(() =>
            {
                string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Save\\";
                string testFile = path + "Test_" + DateTime.Now.ToString().Replace(':', '-').Replace('/', '-') + ".xls";
                string tripFile = path + "Trip_" + DateTime.Now.ToString().Replace(':', '-').Replace('/', '-') + ".xls";
                string acbFile = path + "ACB_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                string testSql = "Select productnumber,item, result,time,type,iset,tset,i,t From MAIN.[TestRecords] order by productnumber";
                string tripSql = "select * from main.[TripRecords] order by productnumber";
                DataTable testTable = DataAccess.ReadTable(testSql);
                DataTable tripTable = DataAccess.ReadTable(tripSql);
                bool customized = CustomizedExcel.SaveExcel(acbFile, tripTable, testTable);
                if (!customized)
                {
                    Tools.ToExcel(testFile, testTable);
                    Tools.ToExcel(tripFile, tripTable);
                }
                this.Dispatcher.Invoke(new Action(() =>
                {
                    Hawesome.MsgBox.Show("Location:\r\n" + path, "Saved", Hawesome.MsgBox.Buttons.OK, "en");
                }));
            }).Start();
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            foreach (var p in Process.GetProcesses())
            {
                if (p.ProcessName.Contains("BlueSoleil"))
                {
                    p.CloseMainWindow();
                    p.Close();
                    break;
                }
            }
            Environment.Exit(0);
        }

        private void btn_size_Click_1(object sender, RoutedEventArgs e)
        {
            //Hawesome.MsgBox.Show("No suggest to resize window", "Info", Hawesome.MsgBox.Buttons.OK, Hawesome.MsgBox.Icons.Info, "en");
            this.WindowState = (this.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }

        private void Window_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            tripDetail.Width=testDetail.Width=comPage.Width = this.ActualWidth;
            tripDetail.Height=testDetail.Height=comPage.Height = this.ActualHeight - 35;
        }
    }
}
