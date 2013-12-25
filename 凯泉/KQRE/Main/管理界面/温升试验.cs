using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using 控件库.数字仪表;
using LogicApp;
using LogicApp.采集模块;
using Gather;
using 全局缓存;
using 控件库.曲线控件;
using NationalInstruments.UI;
using 数据存储;
using 控件库.表格控件;

namespace Main.管理界面
{
    public partial class 温升试验 : DevExpress.XtraEditors.XtraForm,IThreadAction,IGatherComplete,显示采集频率
    {
        GatherLogic logic = null;
        delegate void 重置标签();
        重置标签 _重置标签 = null;
        public 温升试验()
        {
            InitializeComponent();
            //this.凯泉报表控制板1.设置标题();
        }

        private void 运转试验_Load(object sender, EventArgs e)
        {
            DataPvg.LoadDataPvg(500);
            this.grid1.显示采集(this);
            _重置标签 = new 重置标签(this.F_重置标签);
            // 毋需注销的控件
            this.grid1.InitViewLayout("试验表格配置\\温升试验.xml");

            // 需要人工注销的控件
            this.数显仪表集合1.f_初始化所有仪表("试验数显配置\\温升试验数显区配置.xml");
            //this.凯泉报表控制板1.f_初始化所有通道("试验数显配置\\凯泉项目控制板配置.xml");
            logic = new GatherLogic();
            logic.Load("温升试验", this, 当前试验组信息.试验ID, 60000, 2880000);//60000
            logic.LoadGrid(this.grid1, "温升试验", string.Empty, "流量 desc", false);// false不加入序号
            logic.GatherComplete(this, "温升试验");
            logic.GatherStorePattern("温升试验", DataStoreType.SynDB); // 采集模式为同步进行
        }

  
        private void 温升试验_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.数显仪表集合1.f_注销所有仪表();
            //this.凯泉报表控制板1.f_注销控制通道();
        }

        
        private void grid1_Btn执行命令1Click(object sender, EventArgs e)
        {
            if (this.grid1.执行命令按钮CAPTION == "自动采集")
            {
                this.grid1.执行命令按钮CAPTION = "停止采集";
                logic.StartGather("温升试验");
            }
            else
            {
                logic.EndGather("温升试验");
            }
        }

        public bool isAction()
        {
            return this.IsHandleCreated;
        }

        public void Action(ActionData _action)
        {
            this.BeginInvoke(_action);
        }

        void IGatherComplete.采集完毕处理()
        {
            this.BeginInvoke(this._重置标签);
        }

        private void F_重置标签()
        {
            this.grid1.执行命令按钮CAPTION = "自动采集";
        }

        
        private void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
            if (this.grid1.执行命令按钮CAPTION == "自动采集")
            logic.HandGather("温升试验");
        }

        private void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)grid1.ExportView.GetRow(grid1.ExportView.FocusedRowHandle);
            if (row == null) return;
            decimal id = System.Convert.ToDecimal(row["id"].ToString());
            logic.RemoveRecord(id, "温升试验");
        }

        public void 频率改变(int ndata)
        {
            //int 时间 = 0;
            //if(index == 0){时间 = 1 * 60 * 1000;}
            //else if(index == 1){时间 = 5 * 60 * 1000;}
            //else if(index == 2){时间 = 10 * 60 * 1000;}
            //else if(index == 3){时间 = 15 * 60 * 1000;}
            //else{时间 = 20 * 60 * 1000;}
            int 时间 = ndata * 1000;
            logic.EditTime("温升试验", 时间);
        }
    }
}