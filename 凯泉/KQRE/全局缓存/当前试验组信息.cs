using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 全局缓存
{
    public static class 当前试验组信息
    {
        public static decimal 试验ID
        {
            get;
            set;
        }

        public static string 水泵类型
        {
            get;
            set;
        }
        public static string 试验编号
        {
            get;
            set;
        }
        public static double 水泵额定转速
        {
            get;
            set;
        }
        public static double 水泵额定流量
        {
            get;
            set;
        }
        public static double 水泵额定扬程
        {
            get;
            set;
        }
        public static double 水泵进口直径
        {
            get;
            set;
        }
        public static double 温度
        {
            get;
            set;
        }

        public static int 被试水泵ID
        {
            get;
            set;
        }
        public static int 拖动电机ID
        {
            get;
            set;
        }
        public static int 液力耦合器ID
        {
            get;
            set;
        }
        public static int 流量仪表ID
        {
            get;
            set;
        }
        public static int 转速测量仪表ID
        {
            get;
            set;
        }
        public static int 进口压力仪表ID
        {
            get;
            set;
        }
        public static int 出口压力仪表ID
        {
            get;
            set;
        }
        public static int 功率测量仪表ID
        {
            get;
            set;
        }
        public static int 温度测量仪表ID
        {
            get;
            set;
        }
        public static double 水泵出口直径
        {
            get;
            set;
        }
        public static double 进口压力表距
        {
            get;
            set;
        }
        public static double 出口压力表距
        {
            get;
            set;
        }
        public static double 电机额定效率
        {
            get;
            set;
        }
        public static List<工况点> 工况组
        {
            get;
            set;
        }
    }

    public class 工况点
    {
        public string Name
        {
            get;
            set;
        }

        public double 流量
        {
            get;
            set;
        }

        public double 扬程
        {
            get;
            set;
        }

        public double 轴功率
        {
            get;
            set;
        }

        public double 汽蚀余量
        {
            get;
            set;
        }

    }
}
