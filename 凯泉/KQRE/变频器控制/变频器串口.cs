using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;


namespace 变频器控制
{
    public class 变频器串口
    {
        public SerialPort Comm;
        public 变频器串口()
        {
           
        }

        public void 打开串口()
        {
            try
            {

                string com = System.Configuration.ConfigurationSettings.AppSettings["阀门串口"].ToString();
                Comm = new SerialPort();
                Comm.PortName = com;
                Comm.BaudRate = 9600;
                Comm.DataBits = 8;
                Comm.StopBits = System.IO.Ports.StopBits.One;
                Comm.Parity = System.IO.Ports.Parity.None;
                Comm.ReadBufferSize = 2000;
                Comm.ReceivedBytesThreshold = 7;
                Comm.DataReceived += new SerialDataReceivedEventHandler(Comm_DataReceived);
                Comm.Open();
            }
            catch { }
        }

        void Comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] bytes = new byte[7];
            Comm.Read(bytes, 0, 7);
        }

        public void 写报文(byte[] bytes)
        {
            try
            {
                Comm.Write(bytes, 0, bytes.Length);
            }
            catch { }
        }
    }
}
