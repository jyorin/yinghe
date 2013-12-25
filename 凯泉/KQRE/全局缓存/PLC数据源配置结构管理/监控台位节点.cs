using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 全局缓存.数据源配置结构管理
{
    public class 监控台位节点
    {
        public 监控台位节点()
        {

        }

        public string 标识
        {
            get;
            set;
        }

        public int 控件类型
        {
            get;
            set;
        }

        public List<string> 控件标识
        {
            get;
            set;
        }

        // 内存注册
        public List<object> 控件引用
        {
            get;
            set;
        }

        public List<int> 位
        {
            get;
            set;
        }

        public string 链接地址
        {
            get;
            set;
        }

        public int 读写状态
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
