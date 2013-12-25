using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.Net;

using 全局缓存.数据源配置结构管理;
using 全局缓存.PLC数据源接口管理;
using 全局缓存.PLC数据源配置结构管理;
using System.Drawing;
using 全局缓存;

namespace PLC数据源管理.数据源接口实现管理
{
    public class 水泵试验_写入 : 水泵试验结构写入接口
    {
        private System.Threading.Thread thread = null;

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

        private UInt16 _命令字;

        public UInt16 命令字
        {
            get { return _命令字; }
            set { _命令字 = value; }
        }

        /// <summary>
        /// 点断写命令使用
        /// </summary>
        /// <param name="命令字"></param>
        public void f_发送控制命令(UInt16 命令字)
        {
            _命令字 = 命令字;
            ((DataSocket)_水泵试验节点.通道).Data.Value = 辅助库.进制转换.GetWData(命令字);
            Console.WriteLine(((DataSocket)_水泵试验节点.通道).Url + ":" + "命令字:" + 辅助库.进制转换.GetWData(命令字));
        }
        /// <summary>
        /// 脉冲命令使用
        /// </summary>
        /// <param name="状态字"></param>
        /// <param name="命令字"></param>
        public void f_发送控制命令(UInt16 状态字, UInt16 位值)
        {
            _命令字 = 位值;
            _状态字 = 状态字;
            f_脉冲命令();
            // thread = new System.Threading.Thread(f_脉冲命令);
            // thread.IsBackground = true;
            //thread.Start();
        }
        private void f_脉冲命令()
        {
            UInt16 _Send1 = Convert.ToUInt16(_状态字 | _命令字);
            UInt16 _Send2 = Convert.ToUInt16(_Send1 ^ _命令字);
            ((DataSocket)_水泵试验节点.通道).Data.Value = 辅助库.进制转换.GetWData(_Send1);
            Console.WriteLine(((DataSocket)_水泵试验节点.通道).Url + ":" + "发送命令:" + 辅助库.进制转换.GetWData(_Send1));
            System.Threading.Thread.Sleep(300);
            ((DataSocket)_水泵试验节点.通道).Data.Value = 辅助库.进制转换.GetWData(_Send2);
            Console.WriteLine(((DataSocket)_水泵试验节点.通道).Url + ":" + "发送命令:" + 辅助库.进制转换.GetWData(_Send2));
        }
    }
}
