using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading; 

namespace SITE数据源管理
{
    internal class 串口读数
    {

        子站路由 _子站路由 = null;
        public System.Timers.Timer time = null;
        public 串口读数()
        {
            time = new System.Timers.Timer();
            _子站路由 = new 子站路由();
        }

        public Thread thead = null;
        ComDataSplitcs _ComDataSplitcs = null;
        public SerialPort Comm { get; set; }

        public void Start()
        {
            try
            {
                time = new System.Timers.Timer();
                time.Interval = 200;
                time.Elapsed += new System.Timers.ElapsedEventHandler(time_Elapsed);
                time.Start();
            }
            catch (Exception ex)
            {
            }

        }

        int count = 0;
        byte[] bt = null;
        void time_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            if (Comm != null)
            {
                if (Comm.IsOpen)
                {
                    if (Comm.BytesToRead > 0)
                    {
                        bt = new byte[Comm.BytesToRead];
                        Comm.Read(bt, 0, bt.Length);
                        _ComDataSplitcs.AddBytes(bt);

                    }
                }
            }
        }
        public bool Open(string com)
        {
            try
            {
                _ComDataSplitcs = new ComDataSplitcs();
                _ComDataSplitcs._SplitData += new ComDataSplitcs.SplitData(_ComDataSplitcs__SplitData);
                Comm = new SerialPort();
                Comm.PortName = com;
                Comm.BaudRate = 115200;
                Comm.DataBits = 8;
                Comm.StopBits = (System.IO.Ports.StopBits)1;
                Comm.Parity = (System.IO.Ports.Parity)0;
                Comm.Open();
                Start();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void Close()
        {
            try
            {

                if (Comm.IsOpen)
                    Comm.Close();

            }
            catch (Exception ex)
            {
            }
        }
        void _ComDataSplitcs__SplitData(byte[] bytes)
        {
            _子站路由.子站转发(bytes);
        }

        public void Run()
        {
            byte[] bt = null;
            while (true)
            {
                if (Comm != null)
                {
                    if (Comm.IsOpen)
                    {
                        if (Comm.BytesToRead > 0)
                        {

                            bt = new byte[Comm.BytesToRead];
                            Comm.Read(bt, 0, bt.Length);
                            _ComDataSplitcs.AddBytes(bt);

                        }
                    }
                }
                System.Threading.Thread.Sleep(200);
            }
        }

    }
}
