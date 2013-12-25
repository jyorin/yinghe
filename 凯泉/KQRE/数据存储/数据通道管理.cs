using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace 数据存储
{
    public delegate void 数据处理函数(float d,int t);
    public class 数据通道
    {
        public string 数据编码
        {
            get;
            set;
        }
        public 数据处理函数 数据处理
        {
            get;
            set;
        }
    }
    public class 通道管理
    {
        数据通道 channel = null;
        bool 允许操作 = true;
        private Hashtable 通道存储 = new Hashtable();
        public void 注册通道(数据通道 channel)
        {
            this.channel = channel;
            允许操作 = false;
            System.Threading.Thread.Sleep(100);
            System.Threading.Thread thead = new System.Threading.Thread(this.注册通道操作);
            thead.IsBackground = true;
            thead.Start();
        }
        public void 注册通道操作()
        {
            if (!通道存储.ContainsKey(channel.数据编码))
            {

                通道存储.Add(channel.数据编码, channel);
            }
            else
            {
                通道存储[channel.数据编码] = channel;
            }
            this.允许操作 = true;
        }
        public void 注销通道(数据通道 channel)
        {
            this.channel = channel;
            允许操作 = false;
            System.Threading.Thread.Sleep(100);
            System.Threading.Thread thead = new System.Threading.Thread(this.注销通道操作);
            thead.IsBackground = true;
            thead.Start();
        }
        public void 注销通道操作()
        {
            通道存储.Remove(channel.数据编码);
            this.允许操作 = true;
        }
        public void DataUpdate(float d,int t)
        {
            if (允许操作)
            {

                foreach (DictionaryEntry item in 通道存储)
                {

                    ((数据通道)item.Value).数据处理(d, t);
                }
            }
              
        }
        public bool 是否采集()
        {
            return this.通道存储.Count > 0;
        }
    }
}
