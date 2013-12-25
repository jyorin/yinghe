using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Computer;

namespace 数据存储
{
    public  class 数据项 : IComputerItem
    {
        private Random _r;
        private 采集时针 _时针;
        public 采集时针 时针
        {
            get { return this._时针; }
            set { 
                this._时针 = value;
                this.时针.采集事件 += new 采集时针.采集事件委托(时针_采集事件);
            }
        }

        public 波形时针 _波形时针
        {
            get;
            set;
        }

        public I数据平均处理 _数据取平均值
        {
            get;
            set;
        }
     
        public 通道管理 TheChannelManager;
        public 稳态通道管理 TheWChannelManager;
    
        public 数据项()
        {
            TheChannelManager = new 通道管理();
            TheWChannelManager = new 稳态通道管理(this);
            _r = new Random();
           
        }

        void 时针_采集事件()
        {
            if (this.TheChannelManager.是否采集())
            this.时针.间隔采集(this.数据序号, this.数据值, this.时基);
        }
    
        public 数据来源类型 来源类型
        {
            get;
            set;
        }

        public string 数据编码
        {
            get;
            set;
        }

        public int 数据序号
        {
            get;
            set;
        }

        private int _时基;
        public int 时基
        {
            get { return this._时基; }
            set { this._时基 = value; }
        }

        private float _数据值;
        public float 数据值
        {
            get
            {
                return this._数据值;
            }
            set
            {
                this._数据值 = value;
            }
        }

        public void AddData(float d, int t)
        {
            // d = _r.Next(50, 100);
            this._数据值 = d;
            this._时基 = t;
            if (this._数据取平均值 != null)
            {
               d = this._数据取平均值.取平均值(d, t);
               if (d == -1) { return; }
            }
            this.TheChannelManager.DataUpdate(d, t);
           
            if (_Notify != null)
            {
                _Notify();
            }
            if (DataShow != null)
            {
                DataShow(d,t);
            }

            if (this.TheChannelManager.是否采集())
                this.时针.实时采集(this.数据序号, d, t);
            this.TheWChannelManager.AddData(d, t);
        }

        public List<IComputerItem> Items { get; set; }
        public event Notify _Notify;
        public event TODataShow DataShow;     
        public void load(Hashtable tb) { }
        public void computerAction(){}
    }
}
