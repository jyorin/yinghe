using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 数据存储
{
    public class 采集时针
    {
        private 采集管理 _采集管理;
        public delegate void 采集事件委托();
        public event 采集事件委托 采集事件;
        public int 间隔时间
        {
            get;
            set;
        }
        public int 延时时间
        {
            get;
            set;
        }
        private bool 延时采集开关 = false;
        private bool 间隔采集开关 = false;

        public void 实时采集(int 数据序号,float 数据值,int 时基)
        {
            if (this.延时采集开关)
            {
                // 采集
              _采集管理.实时采集(数据序号, 数据值, 时基);

            }
        }

        public void 间隔采集(int 数据序号, float 数据值, int 时基)
        {
               // 采集
              _采集管理.间隔采集(数据序号, 数据值, 时基);
        }

        private System.Threading.Thread 实时采集线程 = null;
        private System.Threading.Thread 间隔采集线程 = null;
        public 采集时针(采集管理 _采集管理)
        {
            this._采集管理 = _采集管理;
            this.间隔时间 = 1000;
            this.延时时间 = 1000;
        }

        public void 实时采集Run()
        {
            int 计数器 = 0;
            while (this.延时采集开关)
            {
                System.Threading.Thread.Sleep(1000);
                计数器 = 计数器 + 1000;
                if (计数器 > 延时时间)
                {
                    this.延时采集开关 = false;
                }
            }
            this._采集管理.关闭实时采集();
        }

        public void 间隔采集Run()
        {
            while (this.间隔采集开关)
            {
                采集事件();
                System.Threading.Thread.Sleep(this.间隔时间);
            }
            this._采集管理.关闭间隔采集();
        }

        public void 开启实时采集()
        {
            this._采集管理.生成实时采集();
            this.延时采集开关 = true;
            this.实时采集线程 = new System.Threading.Thread(this.实时采集Run);
            this.实时采集线程.IsBackground = true;
            this.实时采集线程.Start();
        }

        public void 关闭实时采集()
        {
            this.延时采集开关 = false;
        }

        public void 开启间隔采集()
        {
            this._采集管理.生成间隔采集();
            this.间隔采集开关 = true;
            this.间隔采集线程 = new System.Threading.Thread(this.间隔采集Run);
            this.间隔采集线程.IsBackground = true;
            this.间隔采集线程.Start();
        }

        public void 关闭间隔采集()
        {
            this.间隔采集开关 = false;
        }
    }
}
