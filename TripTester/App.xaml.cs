using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace TripTester
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    //public partial class App : Application
    //{
    //    [System.STAThreadAttribute()]
    //    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    //    public static void Main(string[] a)
    //    {
    //        bool bCreatedNew;
    //        //Create a new mutex using specific mutex name
    //        System.Threading.Mutex m = new System.Threading.Mutex(true, "393A4934-7687-4467-9BE6-801E168B3F6A", out bCreatedNew);

    //        if (bCreatedNew)
    //        {
    //            TripTester.App app = new TripTester.App();
    //            app.InitializeComponent();
    //            app.Run();
    //            m.ReleaseMutex();
    //        }
    //        else
    //        {
    //            System.Environment.Exit(1);
    //            return;
    //        }
    //    }

    //    protected override void OnStartup(StartupEventArgs e)
    //    {
    //        base.OnStartup(e);
    //    }
    //}
}
