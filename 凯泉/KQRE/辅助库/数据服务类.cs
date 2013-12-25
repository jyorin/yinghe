using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;
namespace 辅助库
{

    public class 数据服务类
    {
        public struct 数据服务data
        {
            public double 温度1;
            public double 温度2;
            public double 温度3;
            public double 温度4;
            public double 温度5;
            public double 温度6;
            public double 温度7;
            public double 温度8;
            public double 转速1;
            public double 转速2;
        }

        private struct cmdData
        {
            public byte cmdHead;
            public int cmdLength;
            public 数据服务data data;
        }
       //把字符串转换为IPAddress格式;
        private IPAddress myIP =IPAddress.Parse("127.0.0.1");  
        private IPEndPoint MyServer;
        private Socket sock;
        private List<Socket> ClientSocketList = new List<Socket>();
        public 数据服务data DataValue;
        private static 数据服务类 数据服务对象;
        public static 数据服务类 获取数据服务对象()
        {
            if (数据服务对象 == null)
            {
                数据服务对象 = new 数据服务类();
                数据服务对象.Socket_服务启动();
            }

            return 数据服务对象;
        }
        private 数据服务类()
        {
            DataValue.温度1 = 0;
            DataValue.温度2 = 0;
            DataValue.温度3 = 0;
            DataValue.温度4 = 0;
            DataValue.温度5 = 0;
            DataValue.温度6 = 0;
            DataValue.温度7 = 0;
            DataValue.温度8 = 0;
            DataValue.转速1 = 0;
            DataValue.转速2 = 0;
            ClientSocketList.Clear();
        }
        private static byte[] StructToBytes(object structObj)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(structObj);
            //创建byte数组
            byte[] bytes = new byte[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回byte数组
            return bytes;
        }
        public void Socket_服务启动()
        {
            //return;
            Thread thread = new Thread(new ThreadStart(Socket_监听)); //生成监听线程；
            thread.IsBackground = true;
            thread.Start();
        }

        private void Socket_监听()
        {
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            myIP = ipe.AddressList[1];
            MyServer = new IPEndPoint(myIP, 11503);//组合将访问主机的IP地址和端口号。
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//实例化Socket对象。
            sock.Bind(MyServer);//绑定将访问的主机。
            sock.Listen(50);//开始监听，最大包长50。

            while (true)
            {
                Socket accsock = null;
                try
                {
                    accsock = sock.Accept();//接收客户端的服务请求。
                    if (accsock.Connected)
                    {
                        ClientSocketList.Add(accsock);
                        Thread thread = new Thread(new ThreadStart(Socket_发送数据));
                        thread.IsBackground = true;
                        thread.Start();
                    }
                }
                catch (System.Exception ex)
                {
                    if (accsock != null)
                    {
                        ClientSocketList.Remove(accsock);
                    }
                    continue;
                }
            }
        }
        private void Socket_发送数据()
        {
            while (true)
            {
                byte[] SendBuf;
                cmdData Senddata;
                Senddata.cmdHead = 0x88;
                Senddata.cmdLength = 45;
                Senddata.data.温度1 = DataValue.温度1;
                Senddata.data.温度2 = DataValue.温度2;
                Senddata.data.温度3 = DataValue.温度3;
                Senddata.data.温度4 = DataValue.温度4;
                Senddata.data.温度5 = DataValue.温度5;
                Senddata.data.温度6 = DataValue.温度6;
                Senddata.data.温度7 = DataValue.温度7;
                Senddata.data.温度8 = DataValue.温度8;
                Senddata.data.转速1 = DataValue.转速1;
                Senddata.data.转速2 = DataValue.转速2; 
                foreach (Socket item in ClientSocketList)
                {
                    SendBuf = StructToBytes(Senddata);
                    try
                    {
                        item.Send(SendBuf);
                    }
                    catch
                    {
                        if (item != null)
                        {
                            ClientSocketList.Remove(item);
                            break;
                        }
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
            
        }

    }
}
