using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 全局缓存.数据源配置结构管理;

namespace 全局缓存.PLC数据源接口管理
{
    public interface 电机试验结构读取接口
    {
        电机试验节点 电机试验节点
        {
            get;
            set;
        }

        UInt16 状态字
        {
            get;
            set;
        }

        void f_接收反馈();
        bool 等待闭合命令返回(string 开关名, int 等待时间);
        bool 等待断开命令返回(string 开关名, int 等待时间);
    }
}
