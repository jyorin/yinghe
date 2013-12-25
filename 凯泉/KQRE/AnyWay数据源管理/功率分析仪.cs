using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 数据存储;

namespace AnyWay数据源管理
{
    public class 功率分析仪
    {
        public delegate void 解析完毕通知();
        public event 解析完毕通知 解析完毕;
        public string ip = string.Empty;
        System.Threading.Thread thead = null;
        public 功率分析仪(string ip)
        {
            this.ip = ip;
        }

        public void 开启功率分析仪()
        {
            thead = new System.Threading.Thread(this.接收分析仪数据);
            thead.IsBackground = true;
            thead.Start();
        }

        public void 接收分析仪数据()
        {
            int len = 0;
            int vlen = 0;
            int id = 0;
            float d = 0;
            int t = 0;
            byte[] bytes = new byte[2000];
            while (true)
            {
                len = DLL解析源.readDataWFrom(ref bytes[0], 2000, ip);
                if (len > 0)
                {
                    vlen = (len - 4) / 16;
                   
                    for (int i = 0; i < vlen; i++)
                    {
                        id = (int)System.BitConverter.ToSingle(bytes, i * 16 + 4);
                        d = Math.Abs(System.BitConverter.ToSingle(bytes, i * 16 + 8));
                        t = (int)System.BitConverter.ToSingle(bytes, i * 16 + 12);
                       // System.Console.WriteLine("ID" + id);
                        数据项哈希存储.AddData(ip, id, d, t);
                    }
                    if (this.解析完毕 != null)
                    {
                        this.解析完毕();
                    }
                }
            }
        }
    }
}
