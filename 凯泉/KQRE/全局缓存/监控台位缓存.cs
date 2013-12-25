using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 全局缓存.数据源配置结构管理;


namespace 全局缓存
{
    public static class 监控台位缓存
    {
        public delegate void SetValue(float num);

        public static List<监控台位节点> List_监控台位节点;

        public static List<SetValue> SetValueHandlers;
    }
}
