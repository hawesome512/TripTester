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
using System.ComponentModel;

namespace TripTester
{
    /// <summary>
    /// Interaction logic for ComPage.xaml
    /// </summary>
    public partial class ComPage : UserControl
    {
        public event EventHandler<EventArgs> Completed;
        Help ConnHelp = new Help();

        public ComPage()
        {
            InitializeComponent();
            this.DataContext = ConnHelp;
        }

        public void startCom(double dLine)
        {
            initValue();
            this.Visibility = Visibility.Visible;
            //double dLine = Math.Sqrt(Math.Pow(this.Width, 2) + Math.Pow(this.Height, 2));
            Hawesome.Tools.UseCircleAnimation(this, new Point(0, this.Height), 0, dLine, 0.5);
        }

        private void initValue()
        {
            pbar_Com.Value = 0;
            pbar_Import.Value = 0;
            grid_fail.Visibility = Visibility.Hidden;
            grid_success.Visibility = Visibility.Hidden;
            btn_back.IsEnabled = false;
            btn_again.IsEnabled = false;
        }

        public void endCom()
        {
            btn_back.IsEnabled = true;
            btn_again.IsEnabled = true;
        }

        private void btn_back_Click_1(object sender, RoutedEventArgs e)
        {
            double dLine = Math.Sqrt(Math.Pow(this.Width, 2) + Math.Pow(this.Height, 2));
            Hawesome.Tools.UseCircleAnimation(this, new Point(0, this.Height), dLine, 0, 0.5);
        }

        private void btn_again_Click_1(object sender, RoutedEventArgs e)
        {
            Coms coms = new Coms();
            coms.Update += coms_Update;
            initValue();
        }

        void coms_Update(object sender, ComsEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                pbar_Com.Value = e.ComValue;
                pbar_Import.Value = e.ImportValue;
                grid_fail.Visibility = e.State == ComState.FAILED ? Visibility.Visible : Visibility.Hidden;
                grid_success.Visibility = e.State == ComState.SUCCESSED ? Visibility.Visible : Visibility.Hidden;
                if (e.State != ComState.LOADING)
                {
                    endCom();
                }
                if (e.State == ComState.SUCCESSED)
                {
                    Completed(this, new EventArgs());
                }
            }));
        }

        private void btn_pre_Click_1(object sender, RoutedEventArgs e)
        {
            ConnHelp.Index--;
        }

        private void btn_next_Click_1(object sender, RoutedEventArgs e)
        {
            ConnHelp.Index++;
        }
    }

    public class Help : INotifyPropertyChanged
    {
        public static string[] Tips = new string[] {
            "Help",
            "Run BlueSoleil",
            "Search ACB-TESTER",
            "FOUND ACB-TESTER",
            "Pair Device",
            "Passkey:1234",
            "Paired",
            "Refresh Services",
            "Connect → Bluetooth Serial Port Service",
            "Connected",
            "Disconnected",
        };
        public static string[] ImgPaths = new string[]{
            "Images/helps/help.jpg",
            "Images/helps/0.jpg",
            "Images/helps/1.jpg",
            "Images/helps/2.jpg",
            "Images/helps/3.jpg",
            "Images/helps/4.jpg",
            "Images/helps/5.jpg",
            "Images/helps/6.jpg",
            "Images/helps/7.jpg",
            "Images/helps/8.jpg",
            "Images/helps/9.jpg",
        };
        public event PropertyChangedEventHandler PropertyChanged;
        private int index = 0;
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                value = value < 0 ? Tips.Length - 1 : (value > Tips.Length - 1) ? 0 : value;
                index = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Index"));
                }
            }
        }
    }
}
