using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 辅助库;
namespace 数据存储
{
    public class PLC
    {
      
        public PLC()
        {
           
        }
        public string PLC编码;
        public string URL;
        public string 获取规则编码()
        {
            return 数据来源编码规则.GetPLC(PLC编码);
        }
    }

    public class ANYWAY
    {
        private 数据来源编码规则 _编码规则;
        public string IP;
        public int ADDRESS;
        public ANYWAY()
        {
            this._编码规则 = new 数据来源编码规则();
        }
        public string 获取规则编码()
        {
            return 数据来源编码规则.GetAnyWay(this.IP, this.ADDRESS.ToString());
        }
    }

    public class IP地址
    {
        public string IP;
    }

    public class PLC集合
    {
        文件操作 file = new 文件操作();
        public string Path = string.Empty;
        public List<PLC> list = new List<PLC>();
        public void 填充List()
        {
            file.PATH = AppDomain.CurrentDomain.BaseDirectory + "\\数据配置文件\\PLC数显源.csv";
            file.加载文件();
            string value = string.Empty;
            string[] _value = null;
           
            while ((value = file.读数据()) != null)
            {
                PLC plc = new PLC();
                _value = value.Split(',');  
                plc.PLC编码 = _value[0];
                plc.URL     = _value[1];
                list.Add(plc);
            }
        }
    }

    public class IP集合
    {
        文件操作 file = new 文件操作();
        public string Path = string.Empty;
        public List<IP地址> list = new List<IP地址>();
        public void 填充List()
        {
            //file.PATH = AppDomain.CurrentDomain.BaseDirectory + "\\数据配置文件\\AnyWayIP源.csv";
            //file.加载文件();
            //string value = string.Empty;
            //string[] _value = null;
            //while ((value = file.读数据()) != null)
            //{
            //    IP地址 ip = new IP地址();
            //    _value = value.Split(',');
            //    ip.IP = _value[0];
            //    list.Add(ip);
            //}
            string ip = System.Configuration.ConfigurationSettings.AppSettings["AnyWayIp"].ToString();
            IP地址 ips = new IP地址();
            ips.IP = ip;
            list.Add(ips);
        }

        public string[] 获取IP地址集合()
        {
            string[] ips = new string[this.list.Count];
            int count = ips.Length;
            for (int i = 0; i < count; i++)
            {
                ips[i] = this.list[i].IP;
            }
            return ips;
        }
    }

    public class ANYWAY集合
    {
        文件操作 file = new 文件操作();
        public string Path = string.Empty;
        public List<ANYWAY> list = new List<ANYWAY>();
        IP集合 _IPS = null;
        public IP集合 IPS
        {
            get { return this._IPS; }
        }
        public ANYWAY集合()
        {
            _IPS = 类构造.获取IP集合();
        }
        public void 填充List()
        {
            file.PATH = AppDomain.CurrentDomain.BaseDirectory + "\\数据配置文件\\AnyWay数显源.csv";
            file.加载文件();
            string value = string.Empty;
            string[] _value = null;
         
            while ((value = file.读数据()) != null)
            {
                int count = IPS.list.Count;
                for (int i = 0; i < count; i++)
                {
                    ANYWAY _anyway = new ANYWAY();
                    _value = value.Split(',');
                    _anyway.IP = IPS.list[i].IP;
                    _anyway.ADDRESS = System.Convert.ToInt32(_value[1]);
                    list.Add(_anyway);
                }
               
            }
        }
    }

    public class 配置信息
    {
        public PLC集合 _PLC;
        public ANYWAY集合 _ANYWAY;
        public IP集合 _IPS;

        public 配置信息()
        {
            _PLC = 类构造.获取PLC集合();
            _ANYWAY = 类构造.获取ANYWAY集合();
            _IPS = 类构造.获取IP集合();
        }
    }
}
