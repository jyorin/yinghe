using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyWay数据源管理
{
    public class AnyWay类构造
    {
        public static List<功率分析仪> list = new List<功率分析仪>();
        public static AnyWay数据集 获取AnyWay数据集()
        {
            AnyWay数据集 _AnyWay = new AnyWay数据集();
            _AnyWay.加载ANYWAY数据项();
            _AnyWay.发送数据请求();
            return _AnyWay;
        }

        public static 功率分析仪 获取功率分析仪(string ip)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                if (list[i].ip == ip)
                {
                    return list[i];
                }
            }
            功率分析仪 _分析仪 = new 功率分析仪(ip);
            list.Add(_分析仪);
            _分析仪.开启功率分析仪();
            return _分析仪;
        }
    }
}
