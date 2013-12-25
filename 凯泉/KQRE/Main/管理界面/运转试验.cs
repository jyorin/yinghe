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
    public partial class 运转试验 : DevExpress.XtraEditors.XtraForm,IThreadAction,IGatherComplete,IGatherRow,显示采集频率
    {
        GatherLogic logic = null;
        delegate void 重置标签();
        重置标签 _重置标签 = null;
        public 运转试验()
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
            this.grid1.InitViewLayout("试验表格配置\\运转试验.xml");

            // 需要人工注销的控件
            this.数显仪表集合1.f_初始化所有仪表("试验数显配置\\运转试验数显区配置.xml");
            //this.凯泉报表控制板1.f_初始化所有通道("试验数显配置\\凯泉项目控制板配置.xml");
            logic = new GatherLogic();
            logic.Load("运转试验", this, 当前试验组信息.试验ID,60000, 2880000);//60000
            logic.LoadGrid(this.grid1, "运转试验", string.Empty, "流量 desc", false);// false不加入序号
            logic.GatherComplete(this, "运转试验");
            logic.GatherStorePattern("运转试验", DataStoreType.SynDB); // 采集模式为同步进行
            logic.AddRowEvent("运转试验", this);
            构造波形();
            绘制波形();
        }

        public void 构造波形()
        {        
                YAxis 电压Y轴 = new YAxis();
                YAxis 电流Y轴 = new YAxis();
                YAxis 流量Y轴 = new YAxis();   
                YAxis 进口压力Y轴 = new YAxis();   
                YAxis 出口压力Y轴 = new YAxis();
                YAxis 转速Y轴 = new YAxis();
                xyGraph1.Graph.YAxes.Clear();  
                xyGraph1.Graph.YAxes.Add(转速Y轴);
                xyGraph1.Graph.YAxes.Add(出口压力Y轴);
                xyGraph1.Graph.YAxes.Add(进口压力Y轴);
                xyGraph1.Graph.YAxes.Add(流量Y轴);
                xyGraph1.Graph.YAxes.Add(电流Y轴);
                xyGraph1.Graph.YAxes.Add(电压Y轴);
                
                ScatterPlot 电压线 = new ScatterPlot();
                电压线.YAxis = 电压Y轴;
                NationalInstruments.UI.LegendItem 电压标签 = new LegendItem();
                电压标签.Text = "电压";
                电压标签.Source = 电压线;       
                ScatterPlot 电流线 = new ScatterPlot();
                电流线.YAxis = 电流Y轴;
                NationalInstruments.UI.LegendItem 电流标签 = new LegendItem();
                电流标签.Text = "电流";
                电流标签.Source = 电流线;
                ScatterPlot 流量线 = new ScatterPlot();
                流量线.YAxis = 流量Y轴;
                NationalInstruments.UI.LegendItem 流量标签 = new LegendItem();
                流量标签.Text = "流量";
                流量标签.Source = 流量线;
                ScatterPlot 转速线 = new ScatterPlot();
                转速线.YAxis = 转速Y轴;
                NationalInstruments.UI.LegendItem 转速标签 = new LegendItem();
                转速标签.Text = "转速";
                转速标签.Source = 转速线;
                ScatterPlot 进口压力线 = new ScatterPlot();
                进口压力线.YAxis = 进口压力Y轴;
                NationalInstruments.UI.LegendItem 进口压力标签 = new LegendItem();
                进口压力标签.Text = "进口压力";
                进口压力标签.Source = 进口压力线;
                ScatterPlot 出口压力线 = new ScatterPlot();
                出口压力线.YAxis = 出口压力Y轴;
                NationalInstruments.UI.LegendItem 出口压力标签 = new LegendItem();
                出口压力标签.Text = "出口压力";
                出口压力标签.Source = 出口压力线;     
                xyGraph1.Graph.Plots.Clear();
                xyGraph1.Graph.Plots.Add(电压线);
                xyGraph1.Graph.Plots.Add(电流线);
                xyGraph1.Graph.Plots.Add(流量线);
                xyGraph1.Graph.Plots.Add(进口压力线);
                xyGraph1.Graph.Plots.Add(出口压力线);
                xyGraph1.Graph.Plots.Add(转速线);
    
                this.xyGraph1.波形下标.Items.Add(电压标签);
                this.xyGraph1.波形下标.Items.Add(电流标签);
                this.xyGraph1.波形下标.Items.Add(流量标签);          
                this.xyGraph1.波形下标.Items.Add(进口压力标签);
                this.xyGraph1.波形下标.Items.Add(出口压力标签);
                this.xyGraph1.波形下标.Items.Add(转速标签);

                电压Y轴.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
                电压Y轴.MajorDivisions.LabelForeColor = 电压线.LineColor;
                电流Y轴.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
                电流Y轴.MajorDivisions.LabelForeColor = 电流线.LineColor;
                流量Y轴.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
                流量Y轴.MajorDivisions.LabelForeColor = 流量线.LineColor;
                进口压力Y轴.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
                进口压力Y轴.MajorDivisions.LabelForeColor = 进口压力线.LineColor;
                出口压力Y轴.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
                出口压力Y轴.MajorDivisions.LabelForeColor = 出口压力线.LineColor;
                转速Y轴.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
                转速Y轴.MajorDivisions.LabelForeColor = 转速线.LineColor;
        }

        private void 运转试验_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.数显仪表集合1.f_注销所有仪表();
            //this.凯泉报表控制板1.f_注销控制通道();
        }

        public void 绘制波形()
        {
            DataTable tb1 = logic.GetReportTable("运转试验");
            double[] 电压 = null;
            double[] 电流 = null;
            double[] 流量 = null;
            double[] 进口压力 = null;
            double[] 出口压力 = null;
            double[] 转速 = null;
            double[] 时间轴 = null;
            启停惰转曲线.构造曲线(tb1, out 电压, out 电流, out 流量, out 进口压力, out 出口压力, out 转速, out 时间轴);
            启停惰转曲线.绘制曲线(this.xyGraph1, 电压, 电流, 流量, 进口压力, 出口压力, 转速, 时间轴);
        }
        
        private void grid1_Btn执行命令1Click(object sender, EventArgs e)
        {
            if (this.grid1.执行命令按钮CAPTION == "自动采集")
            {
                this.grid1.执行命令按钮CAPTION = "停止采集";
                logic.StartGather("运转试验");
            }
            else
            {
                logic.EndGather("运转试验");
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

        public void RowEvent(DataRow row)
        {
            double 电压 = System.Convert.ToDouble(row["电压"]);
            double 电流 = System.Convert.ToDouble(row["电流"]);
            double 流量 = System.Convert.ToDouble(row["流量"]);
            double 转速 = System.Convert.ToDouble(row["转速"]);
            double 进口压力 = System.Convert.ToDouble(row["进口压力"]);
            double 出口压力 = System.Convert.ToDouble(row["出口压力"]);
            double 时基值 = System.Convert.ToDouble(row["时基值"]);
            xyGraph1.Graph.Plots[0].PlotXYAppend(时基值 / 1000, 电压);
            xyGraph1.Graph.Plots[1].PlotXYAppend(时基值 / 1000, 电流);
            xyGraph1.Graph.Plots[2].PlotXYAppend(时基值 / 1000, 流量);
            xyGraph1.Graph.Plots[3].PlotXYAppend(时基值 / 1000, 进口压力);
            xyGraph1.Graph.Plots[4].PlotXYAppend(时基值 / 1000, 出口压力);
            xyGraph1.Graph.Plots[5].PlotXYAppend(时基值 / 1000, 转速);
        }

        private void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
            if (this.grid1.执行命令按钮CAPTION == "自动采集")
            logic.HandGather("运转试验");
        }

        private void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)grid1.ExportView.GetRow(grid1.ExportView.FocusedRowHandle);
            if (row == null) return;
            decimal id = System.Convert.ToDecimal(row["id"].ToString());
            logic.RemoveRecord(id, "运转试验");
        }

        public void 频率改变(int ndata)
        {
            //int 时间 = 0;
            //if(index == 0){时间 = 1 * 60 * 1000;}
            //else if(index == 1){时间 = 5 * 60 * 1000;}
            //else if(index == 2){时间 = 10 * 60 * 1000;}
            //else if(index == 3){时间 = 15 * 60 * 1000;}
            //else{时间 = 20 * 60 * 1000;}
            int 时间 = ndata * 1000; ;
            logic.EditTime("运转试验", 时间);
        }
    }
}