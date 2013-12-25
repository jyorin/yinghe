using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 数据存储;
using PLC数据源管理.数据获取;
using NationalInstruments.Net;

namespace PLC数据源管理
{
    public class PLC数据集
    {
        public  DataSocket U;
        public  DataSocket I;
        public  DataSocket P;
        System.Threading.Thread thead = null;
        List<PLC数据项> list = null;
        public 配置信息 _配置信息;

        public PLC数据集()
        {
            _配置信息 = 类构造.获取配置信息();
            list = new List<PLC数据项>();
        }

        public void 销毁PLC()
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                this.list[i].销毁();
            }
            this.U.Dispose();
            this.I.Dispose();
            this.P.Dispose();
        }

        public void 加载PLC数据项()
        {
            PLC数据项 item = null;
            int count = _配置信息._PLC.list.Count;
            for (int i = 0; i < count; i++)
            {
                item = new PLC数据项();
                item.来源类型 = 数据来源类型.PLC;
                item.Data = 链接通道管理.f_建立OPC连接(_配置信息._PLC.list[i].URL, AccessMode.ReadAutoUpdate);
                item.时针 = 类构造.获取采集时针();
                item.数据序号 = 10000 + i;
                item.数据编码 = _配置信息._PLC.list[i].获取规则编码();
                数据项哈希存储.AddItem(item.数据编码, item);
                list.Add(item);
            }
        }

        public void 加载触屏数据()
        {
            U = new DataSocket();
            U.Connect("opc://localhost/National Instruments.NIOPCServers/kaiquan.kaiquan.Anyway.U", AccessMode.WriteAutoUpdate);
            I = new DataSocket();
            I.Connect("opc://localhost/National Instruments.NIOPCServers/kaiquan.kaiquan.Anyway.I", AccessMode.WriteAutoUpdate);
            P = new DataSocket();
            P.Connect("opc://localhost/National Instruments.NIOPCServers/kaiquan.kaiquan.Anyway.P", AccessMode.WriteAutoUpdate);
        }

        public void 写载触屏数据(float U,float I,float P)
        {
            try
            {
                this.U.Data.Value = U;
                this.I.Data.Value = I;
                this.P.Data.Value = P;
            }
            catch { }
        }
    }
}
