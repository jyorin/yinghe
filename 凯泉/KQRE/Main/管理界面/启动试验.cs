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
using LogicApp.启停模块;
using Gather;
using 全局缓存;
using 数据存储;
using NationalInstruments.UI;
namespace Main.管理界面
{
    public partial class 启动试验 : DevExpress.XtraEditors.XtraForm,IThreadAction,IGatherComplete
    {
        GatherLogic logic = null;
        delegate void 重置标签();
        重置标签 _重置标签 = null;
        public 启动试验()
        {
            InitializeComponent();
            ven = this.Fun_设置进度条;
            //this.凯泉报表控制板1.设置标题();
        }

        private void 启动试验_Load(object sender, EventArgs e)
        {
            DataPvg.LoadDataPvg(-1);
            _重置标签 = new 重置标签(this.F_重置标签);
            // 毋需注销的控件
            this.grid1.InitViewLayout("试验表格配置\\启动试验.xml");
            string ip = System.Configuration.ConfigurationSettings.AppSettings["AnyWayIp"].ToString();
            // 需要人工注销的控件
            this.数显仪表集合1.f_初始化所有仪表("试验数显配置\\启动试验数显区配置.xml");
            //this.凯泉报表控制板1.f_初始化所有通道("试验数显配置\\凯泉项目控制板配置.xml");
            logic = new GatherLogic();
            logic.Load("启动试验", this, 当前试验组信息.试验ID, 20, 30000);
            logic.LoadGrid(this.grid1, "启动试验", string.Empty, "流量 desc", true);
            logic.GatherComplete(this, "启动试验");
            logic.LoginSurfaceGather("启动试验", ip);
            logic.GatherStorePattern("启动试验", DataStoreType.LastDB);
            构造波形();
            绘制波形();     
        }

        private void 启动试验_FormClosed(object sender, FormClosedEventArgs e)
        {
            logic.EndGather("启动试验");
            logic.OffSurfaceGather("启动试验", "192.168.1.98");
            this.数显仪表集合1.f_注销所有仪表();
            //this.凯泉报表控制板1.f_注销控制通道();
            //this.xyGraph1.f_注销绘制曲线();
        }

        public bool isAction()
        {
            return this.IsHandleCreated;
        }

        public void Action(ActionData _action)
        {
            this.BeginInvoke(_action);
        }

        private void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
        
        }

        void IGatherComplete.采集完毕处理()
        {
            this.BeginInvoke(this._重置标签);
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

        public void 绘制波形()
        {
            DataTable tb1 = logic.GetReportTable("启动试验");
            double[] 电压 = null;
            double[] 电流 = null;
            double[] 流量 = null;
            double[] 进口压力 = null;
            double[] 出口压力 = null;
            double[] 转速 = null;
            double[] 时间轴 = null;
            启停惰转曲线.构造曲线(tb1, out 电压, out 电流, out 流量,out 进口压力,out 出口压力,out 转速, out 时间轴);
            启停惰转曲线.绘制曲线(this.xyGraph1, 电压, 电流, 流量, 进口压力,出口压力, 转速,时间轴);
        }

        private void F_重置标签()
        {
            this.grid1.新增记录按钮CAPTION = "自动采集";
            this.progressBarControl1.EditValue = 100;
        }

        private void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {
            DataTable tb = logic.GetReportTable("启动试验");
            tb.Clear();
            启停Logic.删除所有启动记录(当前试验组信息.试验ID);
        }

        System.Threading.Thread thead = null;
        private void grid1_Btn执行命令1Click(object sender, EventArgs e)
        {
            this.progressBarControl1.EditValue = 0;
            this.grid1.新增记录按钮CAPTION = "停止采集";
            logic.StartGather("启动试验");
            thead = new System.Threading.Thread(this.Run);
            thead.IsBackground = true;
            thead.Start();
        }

        public delegate void 设置进度条(int len);
        public void Fun_设置进度条(int len)
        {
            this.progressBarControl1.EditValue = len;
        }

        public void 设置进度条操作(int len)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke(ven,len);
            }
        }
        设置进度条 ven = null;
        public void Run()
        {
          
            int len = 0;
            while (true)
            {    
                 len = len + 3;
                 设置进度条操作(len);        
                 if (len == 90) { return; }
                 System.Threading.Thread.Sleep(1000);
            }
        }
    }
}