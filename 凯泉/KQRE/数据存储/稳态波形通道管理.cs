using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using 辅助库;

namespace 数据存储
{
    public delegate bool 稳态波形处理函数(DateTime StartTime,string 编号,double[] x,double[] y);
    public class 稳态波形通道
    {
        public double 波形间隔
        {
            get;
            set;
        }
        public string 数据编码
        {
            get;
            set;
        }
        public 稳态波形处理函数 稳态波形
        {
            get;
            set;
        }
    }
        
    public class 稳态通道管理
    {
        private double[] xdatas = null;
        private double[] ydatas = null;
        private 数据项 _数据项;
        private 波形时针 _波形时针;
        private 波形时针计数 _波形时针计数;
       
        稳态波形通道 channel = null;
        public 稳态通道管理(数据项 _数据项)
        {
            this._数据项 = _数据项;
            this._波形时针 = 类构造.获取波形时针();
            this._波形时针计数 = new 波形时针计数(this._数据项);
        }

        DateTime 零点时间 = DateTime.MinValue;
        int Any零点 = 0;
        int 时基 = -20;
        int index = 0;
        public void AddData(float d, int t)
        {
           // Console.WriteLine("时基:" + t + " 机器时间:" + System.DateTime.Now.Millisecond);
            if (isPaintWave && this.xdatas != null && this.ydatas != null)
            {
                if (t < 0) // PLC传入的值应该是-1
                {
                    if (时基 < 0)
                    {
                        this.零点时间 = System.DateTime.Now;
                    }
                    时基 = 时基 + 20;// 20毫秒
                }
                else // ANYWAY
                {
                    if (Any零点 == 0)
                    {
                        this.零点时间 = System.DateTime.Now;
                        this.Any零点 = t;
                        时基 = 0;
                    }
                    else
                    {
                        时基 = t - this.Any零点;
                    }
                }
                xdatas[index] = System.Convert.ToDouble(时基) / System.Convert.ToDouble(1000);
                ydatas[index] = d;
                index++;
            }
        }

        public void 注册通道(稳态波形通道 channel)
        {
            this.channel = channel;
            this.响应注册波形通道(); 
            this._波形时针计数.计数器 = (int)this.channel.波形间隔;
        }
       
        public void 注销通道(稳态波形通道 channel)
        {
            停止绘制波形();
            this.响应注销波形通道();
            this.channel = null;
        }

        bool isPaintWave = false;
        public void 开始绘制波形()
        {
            this.index = 0; // 初始化总长度
            this.时基 = -20;// 初始化时基
            this.Any零点 = 0;
            isPaintWave = true;
            this._波形时针.新增波形时针计数(this._波形时针计数);
            //System.Console.WriteLine("Time:" + this._数据项.数据编码);
        }

        public void 停止绘制波形()
        {
            this._波形时针.删除波形时针计数(this._波形时针计数);
            isPaintWave = false;
        }

        bool isSuspendWave = false;
        public void 暂停绘制波形()
        {
            this.isSuspendWave = true;
        }

        public void 恢复绘制波形()
        {
            this.isSuspendWave = false;
        }

        public void 响应注册波形通道()
        {
            this.xdatas = new double[250000];
            this.ydatas = new double[250000];
        }
        public void 响应注销波形通道()
        {
            this.xdatas = null;
            this.ydatas = null;
        }
   
        public void 响应波形时针处理()
        {
            if (!this.isSuspendWave)
            {
                int len = this.index;
                double[] _x = new double[len];
                double[] _y = new double[len];
                for (int i = 0; i < len; i++)
                {
                    _x[i] = this.xdatas[i];
                    _y[i] = this.ydatas[i];
                }

                this.DataUpdate(_x, _y, _数据项.数据编码);
            }
        }

        private void DataUpdate(double[] xdatas, double[] ydatas,string 编号)
        {
            if (this.channel != null)
            {
                this.channel.稳态波形(this.零点时间,编号, xdatas,ydatas);
            }
        }

        public void 按比例获取波形(DateTime StartTime,int 比例, out double[] x, out double[] y)
        {
            int 总长度 = this.index;
            int 比例位置 = (int)((System.Convert.ToSingle(比例) / 100f) * System.Convert.ToSingle(总长度));
            double[] _x = new double[比例位置];
            double[] _y = new double[比例位置];
            for (int i = 0; i < 比例位置; i++)
            {
                _x[i] = this.xdatas[i];
                _y[i] = this.ydatas[i];
            }
            x = _x;
            y = _y;
         }
    }   
}
