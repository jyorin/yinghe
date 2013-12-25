using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using NationalInstruments.Net;
using 全局缓存.数据源配置结构管理;
using 全局缓存.PLC数据源接口管理;
using 全局缓存.PLC数据源配置结构管理;
using 全局缓存;
using PLC数据源管理.枚举管理;


namespace PLC数据源管理.数据源接口实现管理
{
    public class 水泵试验_读取 : 水泵试验结构读取接口
    {
        private 水泵试验节点 _水泵试验节点;

        public 水泵试验节点 水泵试验节点
        {
            get { return _水泵试验节点; }
            set { _水泵试验节点 = value; }
        }

        private UInt16 _状态字;

        public UInt16 状态字
        {
            get { return _状态字; }
            set { _状态字 = value; }
        }


        /// <summary>
        /// 状态字使用
        /// </summary>
        public void f_接收反馈()
        {

            char[] _状态位数组 = Convert.ToString(_状态字, 2).PadLeft(16, '0').ToArray();

            // 对控件状态进行判定
            int i = 0;
            foreach (键值对单元 item in _水泵试验节点.ID关联位值)
            {
                string Name = item.Key;

                // 改变开关状态
                item.控件引用.GetType().GetProperty("State").SetValue
                    (item, _状态位数组[item.Value] == 0 ? 电路状态枚举.左断开 : 电路状态枚举.左闭合, null);

                // 改变线路状态
                水泵试验节点下属线路集合 指定的线路节点 =
                    全局缓存.水泵试验缓存.List_水泵试验节点下属线路集合.Find(节点 => 节点.节点标识.Equals(Name));

                foreach (object _线路引用 in 指定的线路节点.节点下属线路引用集合)
                {
                   _线路引用.GetType().GetProperty("BackColor").SetValue(_线路引用, _状态位数组[item.Value] == 0 ? Color.Red : Color.Blue,null);
                }
            }
        }

        private bool 等待命令返回(string 开关名, int 等待时间, bool 闭合命令)
        {
            int 循环次数 = 10;
            int 每次等待时间 = 0;

            每次等待时间 = 等待时间 / 循环次数;
            // 对控件状态进行判定
            foreach (键值对单元 item in _水泵试验节点.ID关联位值)
            {
                if (开关名.Equals(item.Key))
                {
                    for (int i = 0; i < 循环次数; i++)
                    {
                        char[] _状态位数组 = Convert.ToString(_状态字, 2).PadLeft(16, '0').ToArray();
                        if (((_状态位数组[item.Value] == 1) && 闭合命令) ||
                            ((_状态位数组[item.Value] == 0) && (闭合命令 == false)))
                        {
                            return true;
                        }
                        System.Threading.Thread.Sleep(每次等待时间);
                    }
                }
            }

            return false;
        }
        public bool 等待闭合命令返回(string 开关名, int 等待时间)
        {
            return 等待命令返回(开关名, 等待时间, true);
        }
        public bool 等待断开命令返回(string 开关名, int 等待时间)
        {
            return 等待命令返回(开关名, 等待时间, false); ;
        }
    }
}
