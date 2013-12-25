using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 全局缓存.PLC数据源配置结构管理;
using 全局缓存.数据源配置结构管理;
using 全局缓存.PLC数据源接口管理;

namespace 全局缓存
{
    public static class 水泵试验缓存
    {
        //public static List<水泵试验节点> List_水泵试验节点;
        public static List<水泵试验结构读取接口> List_水泵试验结构读取接口 = new List<水泵试验结构读取接口>();
        public static List<水泵试验结构写入接口> List_水泵试验结构写入接口 = new List<水泵试验结构写入接口>();
        public static List<水泵试验节点下属线路集合> List_水泵试验节点下属线路集合 = new List<水泵试验节点下属线路集合>();
        public static uint 水泵试验时基 = 0;
        public static int 水泵流量最大量程 = 45000;
        public static bool 汽蚀试验进行中 = false;
        public static string 流量通道 = "num1";
        public static string 进口压力通道 = "InputPre1";
        public static string 出口压力通道 = "OutputPre1";
        public static float  进口压力量程 = 1;
        public static float  出口压力量程 = 1;
        public static float 变比 = 1;
        public static float 偏移量 = 0;
        public static float 常量 = 0;
    }
}
