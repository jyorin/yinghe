using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 辅助库
{
    public class 数据来源编码规则
    {
        public static string GetAnyWay(string ip, string address)
        {
            string[] ips = ip.Split('.');
            return ips[0] + "-" + ips[1] + "-" + ips[2] + "-" + ips[3] + "-" + address;
        }

        public static string GetPLC(string address)
        {
            return address;
        }

        public static string GetSITE(string id, string address)
        {
            return id + "-" + address;
        }
    }
}
