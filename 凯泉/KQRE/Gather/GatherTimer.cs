using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 全局缓存;

namespace Gather
{
    public class GatherTimer
    {
        private bool 外部采集标志 = false;
        private bool 外部允许采集 = false;
        public delegate void 开始采集();
        public event 开始采集 采集开始;
        public delegate void 采集数据();
        public event 采集数据 采集事件;
        public delegate void 采集完毕();
        public event 采集完毕 采集完成;
        MMTimer mmT = null;
        private uint 最大时间 = 0;
        private uint 当前时间 = 0;
        public int 间隔时间
        {
            get
            {
                return this.mmT.ms;
            }
            set
            {
                mmT.ms = value;
            }
        }
        public uint 延时时间
        {
            get;
            set;
        }
        public GatherTimer()
        {
            mmT = new MMTimer();
            mmT.Timer += new EventHandler(mmT_Timer);
            this.间隔时间 = 60000;
            this.延时时间 = 10000;
        }

        /// <summary>
        /// 定时采集指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mmT_Timer(object sender, EventArgs e)
        {
            当前时间 = (uint)MMTimer.timeGetTime();

            if (this.最大时间 == 0)
            {
                this.最大时间 = 当前时间 + 延时时间;
            }
            else
            {
                if (当前时间 >= this.最大时间)
                {
                    关闭采集();
                    return;
                }
                水泵试验缓存.水泵试验时基 = 当前时间;
                采集事件();
            }

            
        }

        /// <summary>
        /// 来自外部的采集指令
        /// </summary>
        public void 注册外部采集事件()
        {
            if (this.外部允许采集)
            {
                当前时间 = (uint)MMTimer.timeGetTime();

                if (this.最大时间 == 0)
                {
                    this.最大时间 = 当前时间 + 延时时间;
                }
                else
                {
                    if (当前时间 >= this.最大时间)
                    {
                        关闭采集();
                        return;
                    }
                    水泵试验缓存.水泵试验时基 = 当前时间;
                    采集事件();
                }
            }
        }

        GatherEvent _e;
        public void 注册外部采集器(GatherEvent e)
        {
            _e = e;
            this.外部采集标志 = true;
            _e.外部采集事件 += 注册外部采集事件;
        }

        public GatherEvent 注销外部采集器()
        {
            this.外部允许采集 = false;
            _e.外部采集事件 -= 注册外部采集事件;
            return _e;
        }

        public void 开启采集()
        {   
            this.采集开始();
            if (this.外部采集标志)
            {
                this.外部允许采集 = true;
            }
            else
            {
                this.mmT.Start();
            }
        }

        public void 关闭采集()
        {
            if (this.外部采集标志)
            {
                 this.外部允许采集 = false;
            }
            else
            {
                 this.mmT.Stop();
                this.最大时间 = 0;
                this.当前时间 = 0;
            }
            this.采集完成();
            
        }
    }
}
