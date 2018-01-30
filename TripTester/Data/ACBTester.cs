using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TripTester
{
    class ACBTester
    {
        private static Random random = new Random();
        public static int genDeviceCount(int max)
        {
            return random.Next(max) + 1;
        }

        public static byte[] genDeviceInfo()
        {
            byte[] data = new byte[13*2+5];
            int id = random.Next(1000);
            data[8] = (byte)random.Next(256);
            data[9] = (byte)(id / 256);
            data[10] = (byte)(id % 256);
            data[11] = (byte)(2018 / 256);
            data[12] = (byte)(2018 % 256);
            data[13] = data[14] = 1;
            data[17] = (byte)(2000 / 256);
            data[18] = (byte)(2000 % 256);
            data[19] = (byte)(1000 / 256);
            data[20] = (byte)(1000 % 256);
            byte hasN = random.Next(2) == 0 ? (byte)3 : (byte)4;
            data[16] = hasN;
            return data;
        }

        public static byte[] genTest(byte type)
        {
            byte[] data = new byte[9*2+5];
            int status = random.Next(3);
            if (status == 0)
                return data;
            else if (status == 1)
                data[4] = 78;
            else
                data[4] = 79;
            data[5] = 18;
            data[6] = 1;
            data[7] = 1;
            data[12] = 76;
            return data;
        }

        public static byte[] genTrip()
        {
            byte[] data = new byte[13 * 2 + 5];
            data[3] = 18;
            data[4]=data[5] = 1;
            data[10] = (byte)(65 + random.Next(3));
            data[12] = 76;
            return data;
        }
    }
}
