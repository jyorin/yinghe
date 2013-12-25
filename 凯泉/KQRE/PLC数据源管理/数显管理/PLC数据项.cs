using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 数据存储;
using NationalInstruments.Net;
using PLC数据源管理.数据获取;

namespace PLC数据源管理
{
    public class PLC数据项 : 数据项
    {
        public PLC数据项()
        {
        }
        private DataSocket data;
        public DataSocket Data
        {
            set { 
                this.data = value;
                this.data.DataUpdated += new DataUpdatedEventHandler(data_DataUpdated);
                this.data.Update();
            }
            get { return data; }
        }
        void data_DataUpdated(object sender, DataUpdatedEventArgs e)
        {
            short d = 0;
            try
            {
                d = Convert.ToInt16(e.Data.Value);
                if (d < 0 || d > 27648) { d = 0; }
            }
            catch { d = 0; }
           
            this.AddData(d, -1);
        }
        public void 销毁()
        {
            this.data.Dispose();
        }
        public void SetData(string URL)
        {
            this.Data = 链接通道管理.f_建立OPC连接(URL, AccessMode.ReadAutoUpdate);
        }
    }
}
