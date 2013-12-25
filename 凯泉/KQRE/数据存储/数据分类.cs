using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 数据存储
{
    public enum 数据来源类型
    {
        AnyWay = 1,
        PLC = 2,
        SITE = 3,
        未知 = 4
    }

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
