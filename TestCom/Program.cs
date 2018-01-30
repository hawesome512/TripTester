using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace TestCom
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] snd = new byte[] { 0x01, 0x03, 0x00, 0x00, 0x00, 0x01, 0x84, 0x0A };
            byte[] rcv = new byte[256];
            int readCount;
            System.IO.Ports.SerialPort sp = new System.IO.Ports.SerialPort("Com7");
            try
            {
                sp.StopBits = System.IO.Ports.StopBits.Two;
                sp.BaudRate = 9600;
                sp.DataBits = 8;
                sp.Parity = System.IO.Ports.Parity.None;
                sp.DtrEnable = true;
                sp.RtsEnable = true;
                sp.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine("收发测试");

            int r = 100;
            while (r-- > 0)
            {
                sp.Write(snd, 0, 8);
                Console.WriteLine("write  " + ByteTArrayToString(snd, 8));
                Debug.WriteLine("write  " + ByteTArrayToString(snd, 8));

                System.Threading.Thread.Sleep(100);

                readCount = sp.Read(rcv, 0, rcv.Length);
                Console.WriteLine("read  " + ByteTArrayToString(rcv, readCount));
                Debug.WriteLine("read  " + ByteTArrayToString(rcv, readCount));

                Console.WriteLine();
            }
            Console.Read();

        }

        public static string ByteTArrayToString(byte[] array, int count)
        {
            string r = string.Empty;
            count = array.Length >= count ? count : array.Length;
            for (int i = 0; i < count; i++)
            {
                r += array[i].ToString("X2") + " ";
            }
            return r;
        }
    }
}
