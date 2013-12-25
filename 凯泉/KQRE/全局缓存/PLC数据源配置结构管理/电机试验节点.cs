using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 全局缓存.数据源配置结构管理
{
    public class 电机试验节点
    {
        public 电机试验节点()
        { 
        
        }

        public string 标识
        {
            get;
            set;
        }

        public List<键值对单元> ID关联位值
        {
            get;
            set;
        }

        public string 链接地址
        {
            get;
            set;
        }

        public int 读写类型
        {
            get;
            set;
        }

        public int 通道类型
        {
            get;
            set;
        }

        // 内存注册
        public object 通道
        {
            get;
            set;
        }
    }

    public class 键值对单元
    {
        public string Key
        {
            get;
            set;
        }

        public UInt16 Value
        {
            get;
            set;
        }

        public string ControlID
        {
            get;
            set;
        }

        public object 控件引用
        {
            get;
            set;
        }
    }
}
