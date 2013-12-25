using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 控件库.采集控件
{
    public partial class 采集表格 : UserControl
    {
        public delegate void 启动采集委托();
        public event 启动采集委托 启动采集事件;
        public delegate void 停止采集委托();
        public event 停止采集委托 停止采集事件;
        public 采集表格()
        {
            InitializeComponent();
        }

        public int 采集时长
        {
            get
            {
                if (this.txt_采集时长.Text == string.Empty) { return 0; }
                else
                {
                    return System.Convert.ToInt32(this.txt_采集时长);
                }
            }
        }

        public int 采集间隔
        {
            get
            {
                if (this.txt_采集间隔.Text == string.Empty) { return 0; }
                else
                {
                    return System.Convert.ToInt32(this.txt_采集间隔);
                }
            }
        }

        public void 加载表头配置(string 配置文件路径)
        {
            this.grid1.InitViewLayout(配置文件路径);
        }

        public void 加载数据(DataTable 采集源表)
        {
            this.grid1.SetDataSource(采集源表);
        }

        private void btn_启动采集_Click(object sender, EventArgs e)
        {
            启动采集事件();
        }

        private void btn_停止采集_Click(object sender, EventArgs e)
        {
            停止采集事件();
        }
    }
}
