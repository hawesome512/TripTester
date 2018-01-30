using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using System.IO;
using System.IO.Ports;
using Hawesome;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TripTester
{
    public enum ComState
    {
        LOADING, FAILED, SUCCESSED
    }
    public class ComsEventArgs : EventArgs
    {
        public int ComValue;
        public int ImportValue;
        public ComState State;
        public ComsEventArgs(int comValue, int importValue, ComState state = ComState.LOADING)
        {
            ComValue = comValue;
            ImportValue = importValue;
            State = state;
        }
    }

    class Coms
    {
        public event EventHandler<ComsEventArgs> Update;
        public Coms()
        {
            string last = Hawesome.Tools.GetConfig("Com");
            List<string> ports = SerialPort.GetPortNames().ToList();
            if (ports.Contains(last))
            {
                ports.Remove(last);
                ports.Insert(0, last);
            }
            byte[] snd = new byte[] { 0x01, 0x43, 0x00, 0x00, 0x00, 0x01 };
            Task.Factory.StartNew(new Action(() =>
            {
                for (int i = 0; i < ports.Count; i++)
                {
                    Com com = new Com(ComType.SP, ports[i]);
                    try
                    {
                        byte[] rcv = com.Execute(snd);
                        if (rcv != null && rcv.Length > 0)
                        {
                            loadData(com);
                            Hawesome.Tools.SetConfig("Com", ports[i]);
                            break;
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        com.Dispose();
                    }
                    ComState state = (i == ports.Count - 1) ? ComState.FAILED : ComState.LOADING;
                    Update(this, new ComsEventArgs((i + 1) * 100 / ports.Count, 0, state));
                }
            }));
        }

        void loadData(Com com)
        {
            try
            {
                DataTable testDevices = TableCenter.getDeviceTable();
                DataTable testRecords = TableCenter.getTestTable();
                DataTable tripDevices = TableCenter.getDeviceTable();
                DataTable tripRecords = TableCenter.getTripTable();
                //获取记录条数
                byte[] snd = new byte[] { 1, 3, 0, 0, 0, 1 };
                byte[] rcv;
                rcv = com.Execute(snd);
                int testCount = rcv[1];
                snd[2] = 0x60;
                rcv = com.Execute(snd);
                int tripCount = rcv[1];
                //总通信次数:
                int total = 2 + testCount * (14 + 1) + tripCount * (10 + 1);
                //*1.05,保存数据至数据库需花费时间
                total = (int)(total*1.05);
                int index = 2;
                Update(this, new ComsEventArgs(100, index * 100 / total));

                //read test device info
                for (int i = 0; i < testCount; i++)
                {
                    int start = 0x10 + 0x10 * i;
                    snd[2] = (byte)(start / 256);
                    snd[3] = (byte)(start % 256);
                    snd[5] = 0x0d;
                    rcv = com.Execute(snd);
                    DataRow deviceRow = testDevices.NewRow();
                    TableCenter.genDeviceRow(ref deviceRow, rcv);
                    testDevices.Rows.Add(deviceRow);
                    index++;
                    Update(this, new ComsEventArgs(100, index * 100 / total));

                    //read test detail record
                    for (int j = 0; j < Tools.TestTypes.Length; j++)
                    {
                        start = 0x1000 + 0x0800 * i + 0x09 * j;
                        snd[2] = (byte)(start / 256);
                        snd[3] = (byte)(start % 256);
                        snd[5] = 0x09;
                        rcv = com.Execute(snd);
                        if (rcv[1] != 0 && rcv[0] != 0xff)
                        {
                            DataRow testRow = testRecords.NewRow();
                            TableCenter.genTestRow(ref testRow, deviceRow["ProductNumber"].ToString(), Tools.TestTypes[j], rcv);
                            testRecords.Rows.Add(testRow);
                        }
                        index++;
                        Update(this, new ComsEventArgs(100, index * 100 / total));
                    }
                }

                //read trip device info
                for (int i = 0; i < tripCount; i++)
                {
                    int start = 0x6010 + 0x10 * i;
                    snd[2] = (byte)(start / 256);
                    snd[3] = (byte)(start % 256);
                    snd[5] = 0x0d;
                    rcv = com.Execute(snd);
                    DataRow deviceRow = tripDevices.NewRow();
                    TableCenter.genDeviceRow(ref deviceRow, rcv);
                    tripDevices.Rows.Add(deviceRow);
                    index++;
                    Update(this, new ComsEventArgs(100, index * 100 / total));

                    //read trip detail record
                    for (int j = 0; j < 10; j++)
                    {
                        start = 0x7100 + 0x0100 * i + 0x0d * j;
                        snd[2] = (byte)(start / 256);
                        snd[3] = (byte)(start % 256);
                        snd[5] = 0x0d;
                        rcv = com.Execute(snd);
                        if (rcv[0] == 0xff)
                        {
                            index += 10 - j;
                            Update(this, new ComsEventArgs(100, index * 100 / total));
                            break;
                        }
                        else
                        {
                            DataRow tripRow = tripRecords.NewRow();
                            TableCenter.genTripRow(ref tripRow, deviceRow["ProductNumber"].ToString(), rcv);
                            tripRecords.Rows.Add(tripRow);
                            index++;
                            Update(this, new ComsEventArgs(100, index * 100 / total));
                        }
                    }
                }

                DataAccess.UpdateTable(testDevices, "TestDevices");
                DataAccess.UpdateTable(testRecords, "TestRecords");
                DataAccess.UpdateTable(tripDevices, "TripDevices");
                DataAccess.UpdateTable(tripRecords, "TripRecords");
                Update(this, new ComsEventArgs(100, 100, ComState.SUCCESSED));
            }
            catch (Exception exp)
            {
                Update(this,new ComsEventArgs(100,100,ComState.FAILED));
            }
        }
    }
}
