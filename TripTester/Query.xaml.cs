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
using System.Windows.Shapes;
using System.Data;
using Microsoft.Win32;
using System.IO;

namespace TripTester
{
    /// <summary>
    /// Interaction logic for Query.xaml
    /// </summary>
    public partial class Query : Window
    {
        public Query()
        {
            InitializeComponent();

            //控件初始化
            listBoxId.Items.Clear();
            listBoxId.ItemsSource = DataAccess.ReadTable("Select distinct productnumber From MAIN.[Devices]").DefaultView;
            listBoxId.DisplayMemberPath = "ProductNumber";

            datePickerStart.SelectedDate = DateTime.Now.Date;
            datePickerStart.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(datePickerStart_SelectedDateChanged);
            datePickerEnd.SelectedDate = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            datePickerEnd.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(datePickerEnd_SelectedDateChanged);

            string[] list = new string[] { "AL", "BL", "CL", "NL", "AS", "BS", "CS", "NS", "AI", "BI", "CI", "NI", "AG" };
            listBoxItems.Items.Clear();//先清掉数据源
            listBoxItems.ItemsSource = list;//再绑定新数据源
            //listBoxItems.ItemsSource = DataAccess.ReadTable("Select distinct item From MAIN.[Trips]").DefaultView;
            //listBoxItems.DisplayMemberPath = "Item";

        }

        void datePickerEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePickerEnd.SelectedDate == null)
            {
                datePickerEnd.SelectedDate = DateTime.Now.Date;
            }
            if (datePickerEnd.SelectedDate < datePickerStart.SelectedDate)
            {
                datePickerEnd.SelectedDate = datePickerStart.SelectedDate.Value.Date.AddDays(1).AddSeconds(-1);
            }
        }

        void datePickerStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePickerStart.SelectedDate == null)
            {
                datePickerStart.SelectedDate = DateTime.Now.Date;
            }
            if (datePickerEnd.SelectedDate < datePickerStart.SelectedDate)
            {
                datePickerStart.SelectedDate = datePickerEnd.SelectedDate.Value.Date;
            }
        }

        private void buttonQuery_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Select productnumber, item,result,time,type,ir, tr, i,t From MAIN.[Trips]");
            sb.AppendLine(" where ");
            sb.Append(" ( ");
            sb.Append("datetime(time)>=datetime(\"" + ((DateTime)datePickerStart.SelectedDate).ToString("yyyy-MM-dd hh:mm:ss") + "\")");
            sb.Append(" and ");
            sb.Append("datetime(time)<=datetime(\"" + ((DateTime)datePickerEnd.SelectedDate).ToString("yyyy-MM-dd hh:mm:ss") + "\")");
            sb.Append(" ) ");
            if (listBoxId.SelectedItems.Count > 0)
            {
                sb.AppendLine(" and ");
                sb.Append(" ( ");
                for (int i = 0; i < listBoxId.SelectedItems.Count; i++)
                {
                    sb.Append("productnumber == \"" + ((DataRowView)(listBoxId.SelectedItems[i]))["ProductNumber"] + "\"");
                    if (i < listBoxId.SelectedItems.Count - 1)
                        sb.Append(" or ");
                }
                sb.Append(" ) ");
            }

            if (listBoxItems.SelectedItems.Count > 0)
            {
                sb.AppendLine(" and ");
                sb.Append(" ( ");
                for (int i = 0; i < listBoxItems.SelectedItems.Count; i++)
                {
                    sb.Append("item == \"" + listBoxItems.SelectedItems[i] + "\"");
                    if (i < listBoxItems.SelectedItems.Count - 1)
                        sb.Append(" or ");
                }
                sb.Append(" ) ");
            }

            dataGridQuery.ItemsSource = DataAccess.ReadTable(sb.ToString()).DefaultView;
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridQuery.ItemsSource == null)
                return;

            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Save\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = path + "Trips_" + DateTime.Now.ToString().Replace(':', '-') + ".xls";
            save.Filter = "Excel files | *.xls";
            bool? isSave = save.ShowDialog();
            if (isSave == true)
            {
                //Tools.Table2Excel(save.FileName, ((DataView)dataGridQuery.ItemsSource).Table);
                Tools.ToExcel(save.FileName, ((DataView)dataGridQuery.ItemsSource).Table);
            }
        }
    }
}
