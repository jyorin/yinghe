using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 全局缓存.PLC数据源配置结构管理;

namespace 全局缓存.PLC数据源接口管理
{
    public interface 水泵试验结构写入接口
    {
        水泵试验节点 水泵试验节点
        {
            get;
            set;
        }

        UInt16 状态字
        {
            get;
            set;
        }

        UInt16 命令字
        {
            get;
            set;
        }

        void f_发送控制命令(UInt16 状态字, UInt16 位值);

        void f_发送控制命令(UInt16 命令字);
    }
}
