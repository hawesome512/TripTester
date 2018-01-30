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
    public partial class TripDetail : UserControl
    {
        Trip trip = new Trip();
        Color colorOk = Color.FromArgb(0xFF, 0x2A, 0x71, 0x87);
        Color colorFail = Color.FromArgb(0xFF, 0xFF, 0x56, 0x56);

        public TripDetail()
        {
            InitializeComponent();
        }


        private void button_Close_Click(object sender, RoutedEventArgs e)
        {
            double dLine = Math.Sqrt(Math.Pow(this.Width, 2) + Math.Pow(this.Height, 2));
            Hawesome.Tools.UseCircleAnimation(this, new Point(0, 0), dLine, 0, 0.5);
            //this.Visibility = Visibility.Hidden;
        }

        private void btn_print_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog pdlg = new PrintDialog();
            if (pdlg.ShowDialog().GetValueOrDefault(false))
            {
                //System.Printing.PrintCapabilities cpb = pdlg.PrintQueue.GetPrintCapabilities(pdlg.PrintTicket);
                //Size size = new Size(cpb.PageImageableArea.ExtentWidth+75, cpb.PageImageableArea.ExtentHeight);
                //gridContent.Measure(size);
                //Point point = new Point(150,100);
                //gridContent.Arrange(new Rect(point, size));
                //pdlg.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;
                //pdlg.PrintVisual(gridContent, "Trip");
                Size origin = new Size(gridContent.ActualWidth, gridContent.ActualHeight);
                System.Printing.PrintCapabilities cpb = pdlg.PrintQueue.GetPrintCapabilities(pdlg.PrintTicket);
                Size size = new Size(cpb.PageImageableArea.ExtentWidth+100, cpb.PageImageableArea.ExtentHeight);
                gridContent.Measure(size);
                gridContent.Arrange(new Rect(new Point(100, 100), size));
                pdlg.PrintTicket.PageOrientation = System.Printing.PageOrientation.Landscape;
                pdlg.PrintVisual(gridContent, "Trip");
                gridContent.Arrange(new Rect(new Point(), origin));
            }
        }
    }
}
