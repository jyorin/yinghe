using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 全局缓存.数据源配置结构管理;
using 全局缓存.PLC数据源接口管理;

namespace 全局缓存
{
    public static class 电机试验缓存
    {
        public static List<电机试验结构读取接口> List_电机试验结构读取接口 = new List<电机试验结构读取接口>();
        public static List<电机试验结构写入接口> List_电机试验结构写入接口 = new List<电机试验结构写入接口>();
        public static List<电机试验节点下属线路集合> List_电机试验节点下属线路集合 = new List<电机试验节点下属线路集合>();
    }
}
