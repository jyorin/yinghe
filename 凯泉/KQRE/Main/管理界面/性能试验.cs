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
using 控件库.表格控件;
using NationalInstruments.UI;
using System.IO;
using System.Drawing.Imaging;
using 辅助库;
using 数据库操作库;
using System.Linq;
using 数据存储;
namespace Main.管理界面
{
    public partial class 性能试验 : DevExpress.XtraEditors.XtraForm, IThreadAction
    {
        曲线拟合 _曲线拟合 = null;
        GatherLogic logic = null;
        string 按钮权限 = null;

        public 性能试验()
        {
            //_曲线拟合 = new 曲线拟合();
            InitializeComponent();
            按钮权限 = System.Configuration.ConfigurationSettings.AppSettings["刷新保存"].ToString();
            if (按钮权限 == "禁止")
            {
                this.grid1.执行命令 = false;
            }
            this.xyGraph1.f_设置性能试验模式();
            this.凯泉报表控制板1.设置标题();
            grid1.SetGridtoBandGrid();
            grid1.InitViewLayout("试验表格配置\\潜水泵性能试验.xml");
            //if (当前试验组信息.水泵类型 == "潜水泵")
            //{
            //    grid1.InitViewLayout("试验表格配置\\潜水泵性能试验.xml");
            //}
            //else
            //    grid1.InitViewLayout("试验表格配置\\标准泵性能试验.xml");

            // 需要人工注销的控件
            //this.数显仪表集合1.f_初始化所有仪表("试验数显配置\\潜水泵性能试验数显区配置.xml");
        }

        private void 性能试验_Load(object sender, EventArgs e)
        {
            
            if(当前试验组信息.试验ID == 0){return;}
            DataPvg.LoadDataPvg(500);
            this.数显仪表集合1.f_初始化所有仪表("试验数显配置\\潜水泵性能试验数显区配置.xml");
            logic = new GatherLogic();
            logic.Load("潜水泵性能试验", this, 当前试验组信息.试验ID,1000, 10000);
            logic.LoadGrid(this.grid1, "潜水泵性能试验",string.Empty,"流量 desc",true);
            logic.TableComputer("潜水泵性能试验", "转速", new 额定转速计算());
            logic.TableComputer("潜水泵性能试验", "出口压力", new 出口压力计算());
            #region 注销代码
            //logic = new GatherLogic();
            //logic.Load("Test", this, 1, "序列1", "192.168.1.98", 5, 20);
            //DataTable tb2 = logic.GetReportTable("Test");
            //String[] columnNames = new string[] { "电压1", "电流1", "日期值", "时间值", "序列号" };
            //String[] columnIDs = new string[] { "电压1", "电流1", "日期值", "时间值", "序列1" };
            //String[] invisibleColumns = new string[] { "id,groupid" };
            //this.grid1.SetGridColumns(columnNames, columnIDs, invisibleColumns);
            //// this.grid1.ButtonPanelVisible = false;
            //grid1.SetReadOnly(false);
            //for (int i = 0; i < grid1.ExportView.Columns.Count; i++)
            //{
            //    grid1.ExportView.Columns[i].ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            //    grid1.ExportView.Columns[i].OptionsColumn.AllowEdit = true;
            //}
            //this.grid1.SetDataSource(tb2);
            //this.grid1.BtnAddRowClick += new EventHandler(grid1_BtnAddRowClick);
            //this.grid1.BtnReduceRowClick += new EventHandler(grid1_BtnReduceRowClick);
            //this.grid1.Btn执行命令1Click += new EventHandler(grid1_Btn执行命令1Click);
            #endregion
            for (int j = 0; j < xyGraph1.Graph.Plots.Count; j++)
            {
                if (xyGraph1.Graph.Plots[j].Tag.ToString().Equals("H-Q-BS"))
                {
                    xyGraph1.Graph.Plots[j].PlotXY(全局缓存.当前试验组信息.水泵额定流量, 全局缓存.当前试验组信息.水泵额定扬程);
                }
            }

            xyGraph1.Invalidate();
        }

        private void 性能试验_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.logic.LogoffGatherPVG("潜水泵性能试验");
            this.数显仪表集合1.f_注销所有仪表();
        }

        void grid1_Btn执行命令1Click(object sender, EventArgs e)
        {
            logic.UpdateToDB("潜水泵性能试验");

            f_绘制影子性能曲线(xyGraph1, "H-Q-S", grid1, "额定转速下_流量", "额定转速下_扬程");
            f_绘制影子性能曲线(xyGraph1, "P-Q-S", grid1, "额定转速下_流量", "额定转速下_轴功率");
            f_绘制影子性能曲线(xyGraph1, "EFFp-Q-S", grid1, "额定转速下_流量", "额定转速下_泵效率");
            //f_绘制影子性能曲线(xyGraph1, "EFFgr-Q-S", grid1, "额定转速下_流量", "额定转速下_机组效率");

            f_绘制性能曲线(xyGraph1, "H-Q", grid1, "额定转速下_流量", "额定转速下_扬程", 4, 10000);
            double[] const_P_Q = f_绘制性能曲线(xyGraph1, "P-Q", grid1, "额定转速下_流量", "额定转速下_轴功率", 4, 1000);
            double[] const_EFFp_Q = f_绘制性能曲线(xyGraph1, "EFFp-Q", grid1, "额定转速下_流量", "额定转速下_泵效率", 4, 1000);
            //f_绘制性能曲线(xyGraph1, "EFFgr-Q", grid1, "额定转速下_流量", "额定转速下_机组效率", 4);

            交点坐标 交点坐标_流量扬程点 = f_计算保证点性能参数流量扬程点测试结果(全局缓存.当前试验组信息.水泵额定流量, 全局缓存.当前试验组信息.水泵额定扬程, "H-Q");
            交点坐标 交点坐标_轴功率流量点 = f_计算保证点性能参数测试结果(交点坐标_流量扬程点, const_P_Q);
            交点坐标 交点坐标_泵效率流量点 = f_计算保证点性能参数测试结果(交点坐标_流量扬程点, const_EFFp_Q);
            f_显示保证点性能参数测试结果(交点坐标_流量扬程点.X, 交点坐标_流量扬程点.Y, 交点坐标_轴功率流量点.Y, 交点坐标_泵效率流量点.Y);

            同步汽蚀试验();

            SaveImage(this.xyGraph1.Graph, this.xyGraph1.曲线标签组, 700, 700);
        }

        public void 同步汽蚀试验()
        {
           // string sql = string.Format("select b.流量,b.汽蚀余量 from 汽蚀试验批次 b where b.试验组ID in(select a.试验组ID from 汽蚀试验 a where a.groupid = {0})", 当前试验组信息.试验ID);
            string sql = "select b.流量,b.汽蚀余量 from 汽蚀试验批次 b where b.试验组ID=";
            sql+=当前试验组信息.试验ID;
            DataTable tb = 数据库操作类.GetTableBySql(sql);
            int len = tb.Rows.Count;
            if (len > 0)
            {
                double[] x = new double[len];
                double[] y = new double[len];
                for (int i = 0; i < len; i++)
                {
                    x[i] = System.Convert.ToDouble(tb.Rows[i]["流量"].ToString());
                    y[i] = System.Convert.ToDouble(tb.Rows[i]["汽蚀余量"].ToString());
                }
                for (int j = 0; j < xyGraph1.Graph.Plots.Count; j++)
                {
                    if (xyGraph1.Graph.Plots[j].Tag.ToString().Equals("NPSH-Q") || 
                       xyGraph1.Graph.Plots[j].Tag.ToString().Equals("NPSH-Q-S"))
                    {
                        xyGraph1.Graph.Plots[j].PlotXY(x,y);
                        int maxvalue = (int)Math.Log10(y.Max());
                        int[] temp = new int[maxvalue + 1];
                        int tempMax = (int)y.Max();
                        for (int i = maxvalue; i >= 0; i--)
                        {
                            temp[i] = tempMax % 10;
                            tempMax /= 10;
                        }
                        int count = maxvalue;
                        int max = 0;
                        if (maxvalue == 0) max = 10;
                        else if (maxvalue == 1)
                        {
                            int max1 = temp[0] + 1;
                            max += max1 * 10;
                        }
                        else
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                int max1;
                                if (i == 1)
                                {
                                    max1 = temp[i] + 1;
                                }
                                else
                                {
                                    max1 = temp[i];
                                }
                                for (int k = 0; k < count; k++)
                                {
                                    max1 *= 10;
                                }
                                count -= 1;
                                max += max1;

                            }
                        }
                        xyGraph1.Graph.Plots[j].YAxis.Range = new Range(0, max);
                    }
                }
            }
        }

        void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {

            DataRowView row = (DataRowView)grid1.ExportBandView.GetRow(grid1.ExportBandView.FocusedRowHandle);
            if (row == null) return;
            decimal id = System.Convert.ToDecimal(row["id"].ToString());
            logic.RemoveRecord(id, "潜水泵性能试验");
            if (logic.GetReportTable("潜水泵性能试验").Rows.Count == 0) { return; }
            f_绘制影子性能曲线(xyGraph1, "H-Q-S", grid1, "额定转速下_流量", "额定转速下_扬程");
            f_绘制影子性能曲线(xyGraph1, "P-Q-S", grid1, "额定转速下_流量", "额定转速下_轴功率");
            f_绘制影子性能曲线(xyGraph1, "EFFp-Q-S", grid1, "额定转速下_流量", "额定转速下_泵效率");
            //f_绘制影子性能曲线(xyGraph1, "EFFgr-Q-S", grid1, "额定转速下_流量", "额定转速下_机组效率");

            f_绘制性能曲线(xyGraph1, "H-Q", grid1, "额定转速下_流量", "额定转速下_扬程", 4, 10000);
            double[] const_P_Q = f_绘制性能曲线(xyGraph1, "P-Q", grid1, "额定转速下_流量", "额定转速下_轴功率", 4, 1000);
            double[] const_EFFp_Q = f_绘制性能曲线(xyGraph1, "EFFp-Q", grid1, "额定转速下_流量", "额定转速下_泵效率", 4, 1000);
            //f_绘制性能曲线(xyGraph1, "EFFgr-Q", grid1, "额定转速下_流量", "额定转速下_机组效率", 4);

            交点坐标 交点坐标_流量扬程点 = f_计算保证点性能参数流量扬程点测试结果(全局缓存.当前试验组信息.水泵额定流量, 全局缓存.当前试验组信息.水泵额定扬程, "H-Q");
            交点坐标 交点坐标_轴功率流量点 = f_计算保证点性能参数测试结果(交点坐标_流量扬程点, const_P_Q);
            交点坐标 交点坐标_泵效率流量点 = f_计算保证点性能参数测试结果(交点坐标_流量扬程点, const_EFFp_Q);
            f_显示保证点性能参数测试结果(交点坐标_流量扬程点.X, 交点坐标_流量扬程点.Y, 交点坐标_轴功率流量点.Y, 交点坐标_泵效率流量点.Y);
            

            SaveImage(this.xyGraph1.Graph,this.xyGraph1.曲线标签组, 700, 700);
        }

        void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
            logic.HandGather("潜水泵性能试验");
            f_绘制影子性能曲线(xyGraph1, "H-Q-S", grid1, "额定转速下_流量", "额定转速下_扬程");
            f_绘制影子性能曲线(xyGraph1, "P-Q-S", grid1, "额定转速下_流量", "额定转速下_轴功率");
            f_绘制影子性能曲线(xyGraph1, "EFFp-Q-S", grid1, "额定转速下_流量", "额定转速下_泵效率");
            //f_绘制影子性能曲线(xyGraph1, "EFFgr-Q-S", grid1, "额定转速下_流量", "额定转速下_机组效率");

            f_绘制性能曲线(xyGraph1, "H-Q", grid1, "额定转速下_流量", "额定转速下_扬程", 4, 10000);
            double[] const_P_Q = f_绘制性能曲线(xyGraph1, "P-Q", grid1, "额定转速下_流量", "额定转速下_轴功率", 4, 1000);
            double[] const_EFFp_Q = f_绘制性能曲线(xyGraph1, "EFFp-Q", grid1, "额定转速下_流量", "额定转速下_泵效率", 4, 1000);
            //f_绘制性能曲线(xyGraph1, "EFFgr-Q", grid1, "额定转速下_流量", "额定转速下_机组效率", 4);

            交点坐标 交点坐标_流量扬程点 = f_计算保证点性能参数流量扬程点测试结果(全局缓存.当前试验组信息.水泵额定流量, 全局缓存.当前试验组信息.水泵额定扬程, "H-Q");
            交点坐标 交点坐标_轴功率流量点 = f_计算保证点性能参数测试结果(交点坐标_流量扬程点, const_P_Q);
            交点坐标 交点坐标_泵效率流量点 = f_计算保证点性能参数测试结果(交点坐标_流量扬程点, const_EFFp_Q);
            f_显示保证点性能参数测试结果(交点坐标_流量扬程点.X, 交点坐标_流量扬程点.Y, 交点坐标_轴功率流量点.Y, 交点坐标_泵效率流量点.Y);

            SaveImage(this.xyGraph1.Graph, this.xyGraph1.曲线标签组, 700, 700);
        }

        public bool isAction()
        {
            return this.IsHandleCreated;
        }

        public void Action(ActionData _action)
        {
            this.BeginInvoke(_action);
        }

        private void f_显示保证点性能参数测试结果(double 保证点流量, double 保证点扬程, double 保证点轴功率, double 保证点泵效率)
        {
            labelControl_流量.Text = string.Format("流量:{0}", Math.Round(保证点流量,2));
            labelControl_扬程.Text = string.Format("扬程:{0}", Math.Round(保证点扬程,2));
            labelControl_泵输入功率.Text = string.Format("泵输入功率:{0}", Math.Round(保证点轴功率,3));
            labelControl_泵效率.Text = string.Format("泵效率:{0}", Math.Round(保证点泵效率,2));

            //ScatterPlot pt = new ScatterPlot();
            //xyGraph1.Graph.Plots.Add(pt);
            //pt.PlotXY(new double[] { 0, 保证点流量 }, new double[] { 0, 保证点扬程 });

            //ScatterPlot pt2 = new ScatterPlot();
            //xyGraph1.Graph.Plots.Add(pt2);
            //pt2.PlotXY(new double[] { 0, 全局缓存.当前试验组信息.水泵额定流量 }, new double[] { 0, 全局缓存.当前试验组信息.水泵额定扬程 });
        }
        private 交点坐标 f_计算保证点性能参数测试结果(交点坐标 垂线坐标, double[] 方程常量组)
        {
            交点坐标 交点坐标 = new 性能试验.交点坐标();
            double[] d = 辅助库.CurveFitting.f_根据X计算Y(new double[] { 垂线坐标.X }, 方程常量组, 4);
            交点坐标.X = 垂线坐标.X;
            交点坐标.Y = d[0];
            return 交点坐标;
        }
        /// <summary>
        /// 处理保证点性能参数测试结果的逻辑代码
        /// </summary>
        /// <param name="_额定流量">保证点的X坐标</param>
        /// <param name="_额定扬程">保证点的Y坐标</param>
        private 交点坐标 f_计算保证点性能参数流量扬程点测试结果(double _额定流量, double _额定扬程, string 需要进行绘制的曲线ID)
        {
            交点坐标 point = new 交点坐标();
            for (int j = 0; j < this.xyGraph1.Graph.Plots.Count; j++)
            {
                if (this.xyGraph1.Graph.Plots[j].Tag.ToString().Equals(需要进行绘制的曲线ID))
                {
                    List<差值单元项> 统计差值集合 = new List<差值单元项>();
                    
                    double[] xData = this.xyGraph1.Graph.Plots[j].GetXData();
                    double[] yData = this.xyGraph1.Graph.Plots[j].GetYData();
                    double 斜率 = _额定扬程 / _额定流量;
                    
                    // 根据HQ曲线的分割点数计算所有的Y值与直线Y值的差
                    for (int i = 0; i < this.xyGraph1.Graph.Plots[j].HistoryCount; i++)
                    {
                        差值单元项 _差值集合 = new 差值单元项();
                        _差值集合.差值 = Math.Abs(xData[i] * 斜率 - yData[i]);
                        _差值集合.序号 = i;
                        统计差值集合.Add(_差值集合);
                    }

                    // 找出差值最小的点，即两线交汇的误差最小点
                    double 最小差值 = 统计差值集合.Min(item=>item.差值);
                    差值单元项 差值单元项 = 统计差值集合.Find(item => item.差值 == 最小差值);
                    point.X = xData[差值单元项.序号];
                    point.Y = yData[差值单元项.序号];
                    return point;
                }
            }
            return point;
        }
        private void f_绘制影子性能曲线(XYGraph 曲线控件, string 需要进行绘制的曲线ID, Grid 表格控件, string 采集样本_流量数据列名, string 采集样本_Y轴数据列名)
        {
            List<double> 曲线X坐标对集合 = new List<double>();
            List<double> 曲线Y坐标对集合 = new List<double>();
            for (int i = 0; i < 表格控件.ExportBandView.RowCount; i++)
            {
                double X =  Convert.ToSingle( ((DataRowView)表格控件.ExportBandView.GetRow(i))[采集样本_流量数据列名]);
                double Y = Convert.ToSingle(((DataRowView)表格控件.ExportBandView.GetRow(i))[采集样本_Y轴数据列名]);
                曲线X坐标对集合.Add(X);
                曲线Y坐标对集合.Add(Y);
            }

            for(int j=0;j<曲线控件.Graph.Plots.Count;j++)
            {
                if (曲线控件.Graph.Plots[j].Tag.ToString().Equals(需要进行绘制的曲线ID))
                {
                    曲线控件.Graph.Plots[j].PlotXY(曲线X坐标对集合.ToArray(), 曲线Y坐标对集合.ToArray());
                }
            }
        }

        private double[] f_绘制性能曲线(XYGraph 曲线控件, string 需要进行绘制的曲线ID, Grid 表格控件, string 采集样本_流量数据列名, string 采集样本_Y轴数据列名, int 拟合次数,int 分割点数)
        {
            List<double> 曲线X坐标集合 = new List<double>();
            List<double> 曲线Y坐标集合 = new List<double>();

            double[] 方程常量组;
            List<double> 拟合曲线X坐标集合;
            List<double> 拟合曲线Y坐标集合;
            for (int i = 0; i < 表格控件.ExportBandView.RowCount; i++)
            {
                double X = Convert.ToSingle(((DataRowView)表格控件.ExportBandView.GetRow(i))[采集样本_流量数据列名]);
                double Y = Convert.ToSingle(((DataRowView)表格控件.ExportBandView.GetRow(i))[采集样本_Y轴数据列名]);
                曲线X坐标集合.Add(X);
                曲线Y坐标集合.Add(Y);
            }
            if (曲线X坐标集合.Count == 0) return null;
            辅助库.CurveFitting.f_曲线拟合(曲线X坐标集合.ToArray(), 曲线Y坐标集合.ToArray(), 拟合次数, 分割点数, out 拟合曲线X坐标集合, out 拟合曲线Y坐标集合, out 方程常量组);
            //_曲线拟合.f_曲线拟合(曲线X坐标集合, 曲线Y坐标集合, 4,1000 ,out 拟合曲线X坐标集合, out 拟合曲线Y坐标集合);
            for (int j = 0; j < 曲线控件.Graph.Plots.Count; j++)
            {
                if (曲线控件.Graph.Plots[j].Tag.ToString().Equals(需要进行绘制的曲线ID))
                {
                    曲线控件.Graph.Plots[j].PlotXY(拟合曲线X坐标集合.ToArray(), 拟合曲线Y坐标集合.ToArray());
                }
            }
            return 方程常量组;
        }
        /// <summary>
        /// 将曲线图保存入数据库中
        /// </summary>
        /// <param name="scatterGraph">曲线控件</param>
        /// <param name="标签组">曲线控件描绘曲线的标签组</param>
        /// <param name="width">图片的宽度</param>
        /// <param name="height">图片的高度</param>
        public  void SaveImage(NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph, NationalInstruments.UI.WindowsForms.Legend 标签组, int width, int height)
        {
            Color 原色 = scatterGraph.PlotAreaColor;
            scatterGraph.BackColor = Color.White;

            scatterGraph.PlotAreaColor = Color.Transparent;
            ChangeImageSize(scatterGraph, 标签组);

            Image image1 = scatterGraph.ToImage(new Size(width, height));
            Image image_标签组 = 标签组.ToImage(new Size(width, 标签组.Height));
            Bitmap offBm = new Bitmap(width, height + 11 + 标签组.Height);

            Graphics g = Graphics.FromImage(offBm);
            g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), new Size(width, height + 11 + 标签组.Height)));

            g.DrawImage(image1, new Point(3, 15));
            //nsp=全局缓存.当前试验组信息.水泵额定转速rpm
            g.DrawString("nsp=" + 全局缓存.当前试验组信息.水泵额定转速.ToString() + "rpm", new Font("宋体", 14), Brushes.Black, new PointF(width - 250, 30));
            g.DrawString("扬程[m]", new Font("宋体", 14), Brushes.Black, new PointF(3, 1));
            g.DrawString("η[%]", new Font("宋体", 14), Brushes.Black, new PointF(width - 150, 1));
            g.DrawString("P[kW]", new Font("宋体", 14), Brushes.Black, new PointF(width - 100, 1));
            g.DrawString("NPSH[m]", new Font("宋体", 14), Brushes.Black, new PointF(width - 50, 1));
            g.DrawImage(image_标签组, new Point(3, 11 + height));

            MemoryStream ms = new MemoryStream();
            //保存为Jpg类型  
            offBm.Save(ms, ImageFormat.Png);
            byte[] imgData = ms.ToArray();

            数据库操作类.图片存储("性能试验", imgData);
            scatterGraph.PlotAreaColor = 原色;
            ReturnImageSize(scatterGraph, 标签组);
        }

        public void ChangeImageSize(NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph, NationalInstruments.UI.WindowsForms.Legend 标签组)
        {
            scatterGraph.XAxes[0].MajorDivisions.LabelFont = new System.Drawing.Font("宋体", 14);
            标签组.Font = new System.Drawing.Font("宋体", 14);
            for (int i = 0; i < scatterGraph.YAxes.Count; i++)
            {
                scatterGraph.YAxes[i].MajorDivisions.LabelFont = new System.Drawing.Font("宋体", 14);
            }

        }

        public void ReturnImageSize(NationalInstruments.UI.WindowsForms.ScatterGraph scatterGraph, NationalInstruments.UI.WindowsForms.Legend 标签组)
        {
            scatterGraph.XAxes[0].MajorDivisions.LabelFont = new System.Drawing.Font("宋体", 9);
            标签组.Font = new System.Drawing.Font("宋体", 9);
            for (int i = 0; i < scatterGraph.YAxes.Count; i++)
            {
                scatterGraph.YAxes[i].MajorDivisions.LabelFont = new System.Drawing.Font("宋体", 9);
            }
        }
        struct 差值单元项
        {
            double _差值;

            public double 差值
            {
                get { return _差值; }
                set { _差值 = value; }
            }

            int _序号;

            public int 序号
            {
                get { return _序号; }
                set { _序号 = value; }
            }
        }

        struct 交点坐标
        {
            double _x;

            public double X
            {
                get { return _x; }
                set { _x = value; }
            }
            double _y;

            public double Y
            {
                get { return _y; }
                set { _y = value; }
            }
        }
    }
}