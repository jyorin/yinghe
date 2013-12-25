using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.Net;

namespace PLC数据源管理.数据获取
{
    public static class 链接通道管理
    {
        public static DataSocket f_建立OPC连接(string URL, AccessMode _Mode)
        {
            DataSocket dataSocket = new DataSocket();
            dataSocket.Connect(URL, _Mode);
            return dataSocket;
        }
    }
}
