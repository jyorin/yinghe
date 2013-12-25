using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 全局缓存.数据源配置结构管理;

namespace 全局缓存.PLC数据源配置结构管理
{
    public class 水泵试验节点
    {
        public 水泵试验节点()
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
}
