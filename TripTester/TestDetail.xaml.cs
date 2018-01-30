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
using System.Data;

namespace TripTester
{
    /// <summary>
    /// Interaction logic for DetailWidget.xaml
    /// </summary>
    public partial class TestDetail : UserControl
    {
        Trip trip = new Trip();
        Color colorOk = Color.FromArgb(0xFF, 0x2A, 0x71, 0x87);
        Color colorFail = Color.FromArgb(0xFF, 0xFF, 0x56, 0x56);

        public TestDetail()
        {
            InitializeComponent();
                        
            //初始化控件
            setBorder(2, Brushes.Gray);
            //trip.Topmost = true;
            trip.ShowInTaskbar = false;
            regMouse();
        }

        private void regMouse()
        {
            labelAL.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelBL.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelCL.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelNL.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelAS.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelBS.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelCS.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelNS.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelAI.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelBI.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelCI.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelNI.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelAG.MouseEnter += new MouseEventHandler(label_MouseEnter);
            labelMIC.MouseEnter += new MouseEventHandler(label_MouseEnter);

            labelAL.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelBL.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelCL.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelNL.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelAS.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelBS.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelCS.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelNS.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelAI.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelBI.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelCI.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelNI.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelAG.MouseLeave += new MouseEventHandler(label_MouseLeave);
            labelMIC.MouseLeave += new MouseEventHandler(label_MouseLeave);
        }

        private void setBorder(double thickness, Brush color)
        {
            foreach (UIElement child in wrapPanel_details.Children)
            {
                Label l = child as Label;
                if (l != null)
                {
                    l.BorderThickness = new Thickness(thickness);
                    l.BorderBrush = color;
                }
            }
        }

        private void button_Close_Click(object sender, RoutedEventArgs e)
        {
            double dLine = Math.Sqrt(Math.Pow(this.Width, 2) + Math.Pow(this.Height, 2));
            Hawesome.Tools.UseCircleAnimation(this, new Point(0, 0), dLine, 0, 0.5);
            //this.Visibility = Visibility.Hidden;
        }

        private void label_MouseEnter(object sender, MouseEventArgs e)
        {
            Label l = sender as Label;
            
            trip.DataContext = l.DataContext;
            DataTable view = l.DataContext as DataTable;

            if (view.Rows.Count>0 && view.Rows[0][0].GetType().FullName == "System.DBNull")//不知为何有一行数据
                return;

            string result = view.Rows[0]["Result"].ToString();
            if (result == "OK")
            {
                trip.grid_bg.Background = new SolidColorBrush(colorOk);
                trip.border.BorderBrush = new SolidColorBrush(colorFail);
                trip.side.Source = Hawesome.Tools.GetImgSource("Images/sideOK.png", "TripTester");
            }
            else
            {
                trip.grid_bg.Background = new SolidColorBrush(colorFail);
                trip.border.BorderBrush = new SolidColorBrush(colorOk);
                trip.side.Source = Hawesome.Tools.GetImgSource("Images/sideNG.png", "TripTester");
            }
            Point loc = l.PointToScreen(new Point(50,-88));
            trip.Left = loc.X;
            trip.Top = loc.Y;
            
            trip.Show();
        }

        private void label_MouseLeave(object sender, MouseEventArgs e)
        {
            trip.Hide();
        }

        private void btn_print_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog pdlg = new PrintDialog();
            if (pdlg.ShowDialog().GetValueOrDefault(false))
            {
                Size origin = new Size(gridContent.ActualWidth, gridContent.ActualHeight);
                System.Printing.PrintCapabilities cpb = pdlg.PrintQueue.GetPrintCapabilities(pdlg.PrintTicket);
                Size size = new Size(cpb.PageImageableArea.ExtentWidth, cpb.PageImageableArea.ExtentHeight);
                gridContent.Measure(size);
                gridContent.Arrange(new Rect(new Point(0,100), size));
                pdlg.PrintVisual(gridContent, "Test");
                gridContent.Arrange(new Rect(new Point(0,0), origin));
            }
        }
    }
}
