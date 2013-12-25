using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using NationalInstruments.UI.WindowsForms;
using System.Windows.Forms;
using 数据存储;
using 辅助库;
//using NationalInstruments.Analysis.SignalGeneration;
namespace 控件库.曲线控件
{
    public partial class XYGraph : UserControl
    {
        public double[] AcquireData(double frequency, double amplitude, double phase, double numberSamples, double noiseAmplitude)
        {
            //SineSignal sineSignal = new SineSignal(frequency, amplitude, phase);
            //WhiteNoiseSignal noise = new WhiteNoiseSignal(noiseAmplitude);
            //SignalGenerator generator = new SignalGenerator(numberSamples, (long)numberSamples);
            //generator.Signals.Add(sineSignal);
            //generator.Signals.Add(noise);
            //return generator.Generate();
            return null;
        }

        public void f_绘制指定的曲线(string PlotName,double[] x,double[] y,int _拟合次数)
        {
            List<double> _拟合曲线X值;
            List<double> _拟合曲线Y值;
            曲线信息 _曲线信息 = List_曲线信息.Find(item => item.Name.Equals(PlotName));

            //_曲线信息.ShadowPlot.PlotXY(x, y);

            //CurveFitting.f_曲线拟合(x, y, _拟合次数, x[0], 5000, out _拟合曲线X值, out _拟合曲线Y值);

            //_曲线信息.Plot.PlotXY(_拟合曲线X值.ToArray(), _拟合曲线Y值.ToArray());
        }

        /// <summary>
        /// 调用绘制曲线入口
        /// </summary>
        /// <param name="Path"></param>
        public void f_加载配置文件(string Path)
        {
            辅助库.文件操作 file = new 辅助库.文件操作();
            file.PATH = AppDomain.CurrentDomain.BaseDirectory + Path;
            file.加载文件();
            string value = string.Empty;
            string[] List_value = null;
            while ((value = file.读数据()) != null)
            {
                List_value = value.Split(',');
                switch (List_value[0])
                {
                    case "ANYWAY":
                        f_绑定稳态数据通道(List_value[1], List_value[2],List_value[3]);
                        break;
                    case "PLC":
                        f_绑定稳态数据通道(List_value[1], List_value[2]);
                        break;
                    case "GRID":
                        f_绑定稳态数据通道(List_value[1], List_value[2]);
                        break;
                }
            }
        }

        public void f_注销绘制曲线()
        {
            foreach (曲线信息 item in List_曲线信息)
            {
                数据项 _数据项 = 数据项哈希存储.GetItem(item.稳态波形通道.数据编码);
                _数据项.TheWChannelManager.停止绘制波形();
            }
        }

        public void f_设置性能试验模式()
        {
            NationalInstruments.UI.YAxis yaxis_H = new NationalInstruments.UI.YAxis();
            yaxis_H.Position = NationalInstruments.UI.YAxisPosition.Left;
            yaxis_H.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F1");
            yaxis_H.MajorDivisions.LabelForeColor = Color.Black;
            yaxis_H.BaseLineVisible = true;
            yaxis_H.Tag = "扬程";
            Graph_View.YAxes.Add(yaxis_H);

            // 取消机组效率Y轴
            NationalInstruments.UI.YAxis yaxis_N = new NationalInstruments.UI.YAxis();
            yaxis_N.Position = NationalInstruments.UI.YAxisPosition.Right;
            yaxis_N.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
            yaxis_N.MajorDivisions.LabelForeColor = Color.Black;
            yaxis_N.BaseLineVisible = true;
            yaxis_N.Tag = "效率";
            Graph_View.YAxes.Add(yaxis_N);

            NationalInstruments.UI.YAxis yaxis_P = new NationalInstruments.UI.YAxis();
            yaxis_P.Position = NationalInstruments.UI.YAxisPosition.Right;
            yaxis_P.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
            yaxis_P.MajorDivisions.LabelForeColor = Color.Black;
            yaxis_P.BaseLineVisible = true;
            yaxis_P.Tag = "功率";
            Graph_View.YAxes.Add(yaxis_P);

            //add begin
            NationalInstruments.UI.YAxis yaxis_NPSH = new NationalInstruments.UI.YAxis();
            yaxis_NPSH.Position = NationalInstruments.UI.YAxisPosition.Right;
            yaxis_NPSH.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
            yaxis_NPSH.MajorDivisions.LabelForeColor = Color.Black;
            yaxis_NPSH.BaseLineVisible = true;
            yaxis_NPSH.Tag = "NPSH";
            Graph_View.YAxes.Add(yaxis_NPSH);
            //add end

            xAxis_Looking.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F0");
            xAxis_Looking.Caption = "流量[m3/h]";

            NationalInstruments.UI.ScatterPlot plot_HQ_保证点 = new NationalInstruments.UI.ScatterPlot();
            NationalInstruments.UI.ScatterPlot plot_HQ_Shandow = new NationalInstruments.UI.ScatterPlot();
            NationalInstruments.UI.ScatterPlot plot_HQ = new NationalInstruments.UI.ScatterPlot();
            NationalInstruments.UI.LegendItem item_HQ = new NationalInstruments.UI.LegendItem();

            item_HQ.Text = "H-Q";
            item_HQ.Source = plot_HQ;
            this.legend1.Items.Add(item_HQ);

            plot_HQ.LineColor = Color.Red;
            plot_HQ.YAxis = yaxis_H;
            plot_HQ.Tag = "H-Q";
           
            plot_HQ_Shandow.YAxis = yaxis_H;
            plot_HQ_Shandow.LineColor = Color.Transparent;
            plot_HQ_Shandow.PointStyle = NationalInstruments.UI.PointStyle.EmptyDiamond;
            plot_HQ_Shandow.PointColor = plot_HQ.LineColor;
            plot_HQ_Shandow.PointSize = new System.Drawing.Size(10, 10);
            plot_HQ_Shandow.Tag = "H-Q-S";

            plot_HQ_保证点.YAxis = yaxis_H;
            plot_HQ_保证点.LineColor = Color.Transparent;
            plot_HQ_保证点.PointStyle = NationalInstruments.UI.PointStyle.None;
            plot_HQ_保证点.PointColor = Color.Gray;
            plot_HQ_保证点.PointSize = new System.Drawing.Size(10, 10);
            plot_HQ_保证点.Tag = "H-Q-BS";
            plot_HQ_保证点.XErrorDataMode = NationalInstruments.UI.XYErrorDataMode.CreatePercentErrorMode(8D, 8D);
            plot_HQ_保证点.YErrorDataMode = NationalInstruments.UI.XYErrorDataMode.CreatePercentErrorMode(5D, 5D);
            plot_HQ_保证点.XErrorHighLineColor = Color.Gold;
            plot_HQ_保证点.XErrorLowLineColor = Color.Gold;
            plot_HQ_保证点.XErrorHighPointColor = Color.Gold;
            plot_HQ_保证点.XErrorLowPointColor = Color.Gold;
            plot_HQ_保证点.YErrorHighLineColor = Color.Gold;
            plot_HQ_保证点.YErrorLowLineColor = Color.Gold;
            plot_HQ_保证点.YErrorHighPointColor = Color.Gold;
            plot_HQ_保证点.YErrorLowPointColor = Color.Gold;

            Graph_View.Plots.Add(plot_HQ);
            Graph_View.Plots.Add(plot_HQ_Shandow);
            Graph_View.Plots.Add(plot_HQ_保证点);

            NationalInstruments.UI.ScatterPlot plot_PQ_Shandow = new NationalInstruments.UI.ScatterPlot();
            NationalInstruments.UI.ScatterPlot plot_PQ = new NationalInstruments.UI.ScatterPlot();
            NationalInstruments.UI.LegendItem item_PQ = new NationalInstruments.UI.LegendItem();

            item_PQ.Text = "P-Q";
            item_PQ.Source = plot_PQ;
            this.legend1.Items.Add(item_PQ);

            plot_PQ.LineColor = Color.Green;
            plot_PQ.YAxis = yaxis_P;
            plot_PQ.Tag = "P-Q";
            plot_PQ_Shandow.Tag = "P-Q-S";

            plot_PQ_Shandow.YAxis = yaxis_P;
            plot_PQ_Shandow.LineColor = Color.Transparent;
            plot_PQ_Shandow.PointStyle = NationalInstruments.UI.PointStyle.EmptyCircle;
            plot_PQ_Shandow.PointColor = plot_PQ.LineColor;
            plot_PQ_Shandow.PointSize = new System.Drawing.Size(10, 10);

            Graph_View.Plots.Add(plot_PQ);
            Graph_View.Plots.Add(plot_PQ_Shandow);


            NationalInstruments.UI.ScatterPlot plot_EFFpQ_Shandow = new NationalInstruments.UI.ScatterPlot();
            NationalInstruments.UI.ScatterPlot plot_EFFpQ = new NationalInstruments.UI.ScatterPlot();
            NationalInstruments.UI.LegendItem item_EFFpQ = new NationalInstruments.UI.LegendItem();

            item_EFFpQ.Text = "EFFp-Q";
            item_EFFpQ.Source = plot_EFFpQ;
            this.legend1.Items.Add(item_EFFpQ);

            plot_EFFpQ.LineColor = Color.Blue;
            plot_EFFpQ.YAxis = yaxis_N;
            plot_EFFpQ.Tag = "EFFp-Q";
            plot_EFFpQ_Shandow.Tag = "EFFp-Q-S";

            plot_EFFpQ_Shandow.YAxis = yaxis_N;
            plot_EFFpQ_Shandow.LineColor = Color.Transparent;
            plot_EFFpQ_Shandow.PointStyle = NationalInstruments.UI.PointStyle.EmptySquare;
            plot_EFFpQ_Shandow.PointColor = plot_EFFpQ.LineColor;
            plot_EFFpQ_Shandow.PointSize = new System.Drawing.Size(10, 10);

            Graph_View.Plots.Add(plot_EFFpQ);
            Graph_View.Plots.Add(plot_EFFpQ_Shandow);

            // 取消机组效率曲线
            NationalInstruments.UI.ScatterPlot plot_汽蚀曲线 = new NationalInstruments.UI.ScatterPlot();
            NationalInstruments.UI.ScatterPlot plot_汽蚀曲线_Shandow = new NationalInstruments.UI.ScatterPlot();
            NationalInstruments.UI.LegendItem item_汽蚀曲线 = new NationalInstruments.UI.LegendItem();
            plot_汽蚀曲线_Shandow.PointStyle = NationalInstruments.UI.PointStyle.Plus;
            plot_汽蚀曲线_Shandow.LineColor = Color.Transparent;
            plot_汽蚀曲线_Shandow.PointColor = Color.Red;
            plot_汽蚀曲线_Shandow.PointSize = new System.Drawing.Size(12, 12);

            item_汽蚀曲线.Text = "NPSH-Q";
            item_汽蚀曲线.Source = plot_汽蚀曲线;
            this.legend1.Items.Add(item_汽蚀曲线);

            plot_汽蚀曲线.LineColor = Color.DarkOrange;
            plot_汽蚀曲线.YAxis = yaxis_NPSH;
            plot_汽蚀曲线.Tag = "NPSH-Q";
            plot_汽蚀曲线_Shandow.YAxis = yaxis_NPSH;
            plot_汽蚀曲线_Shandow.Tag = "NPSH-Q-S";
            Graph_View.Plots.Add(plot_汽蚀曲线);
            Graph_View.Plots.Add(plot_汽蚀曲线_Shandow);
            _当前显示模式 = "潜水泵性能试验";
            panel_text.Refresh();
        }

        public void f_设置汽蚀试验模式()
        {
            yaxis_汽蚀试验 = new NationalInstruments.UI.YAxis();
            yaxis_汽蚀试验.Position = NationalInstruments.UI.YAxisPosition.Left;
            yaxis_汽蚀试验.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F1");
            yaxis_汽蚀试验.MajorDivisions.LabelForeColor = Color.Black;
            yaxis_汽蚀试验.BaseLineVisible = true;
            yaxis_汽蚀试验.Tag = "扬程";
            Graph_View.YAxes.Add(yaxis_汽蚀试验);

            xAxis_Looking.MajorDivisions.LabelFormat = new NationalInstruments.UI.FormatString(NationalInstruments.UI.FormatStringMode.Numeric, "F1");
            xAxis_Looking.Caption = "NPSH[m]";

            _当前显示模式 = "汽蚀试验";
            panel_text.Refresh();
        }

        public bool f_更新曲线标签(string 曲线编号, double 流量)
        {
            for (int i = 0; i < this.legend1.Items.Count; i++)
            {
                if (this.legend1.Items[i].Tag.Equals(曲线编号) == true)
                {
                    this.legend1.Items[i].Text = 流量.ToString();
                    return true;
                }
            }
            return false;
        }

        public bool f_增加曲线(string 曲线编号)
        {
            NationalInstruments.UI.ScatterPlot plot = new NationalInstruments.UI.ScatterPlot();
            NationalInstruments.UI.ScatterPlot plottag = new NationalInstruments.UI.ScatterPlot();
            NationalInstruments.UI.ScatterPlot plot_汽蚀余量 = new NationalInstruments.UI.ScatterPlot();
            if (曲线存储.ContainsKey(曲线编号))
            {
                return false;
            }

            NationalInstruments.UI.LegendItem item = new NationalInstruments.UI.LegendItem();


            plot.YAxis = yaxis_汽蚀试验;
            plot.PointStyle = NationalInstruments.UI.PointStyle.EmptyCircle;
            plot.PointColor = Color.DarkOrange;
            plot.PointSize = new System.Drawing.Size(9, 9);
            plot.Tag = 曲线编号;
            this.Graph_View.Plots.Add(plot);

            plottag.YAxis = yaxis_汽蚀试验;
            plottag.PointStyle = NationalInstruments.UI.PointStyle.None;
            plottag.LineColor = plot.LineColor;
            plottag.PointColor = plot.PointColor;
            plottag.Tag = 曲线编号+"_tag";

            plot_汽蚀余量.YAxis = yaxis_汽蚀试验;
            plot_汽蚀余量.PointStyle = NationalInstruments.UI.PointStyle.Plus;
            plot_汽蚀余量.PointColor = Color.Red;
            plot_汽蚀余量.PointSize = new System.Drawing.Size(12, 12);
            plot_汽蚀余量.Tag = 曲线编号 + "_临界点";


            //item.Text = 曲线编号;
            item.Tag = 曲线编号;
            item.Source = plottag;
            this.legend1.Items.Add(item);
 
            this.Graph_View.Plots.Add(plot_汽蚀余量);
            
            曲线存储.Add(曲线编号, plot);
            汽蚀余量存储.Add(曲线编号 + "_临界点", plot_汽蚀余量);
            汽蚀余量影子曲线存储.Add(曲线编号 + "_Tag", plot_汽蚀余量);
            return true;
        }

        public bool f_设置汽蚀余量(string 曲线编号,double 汽蚀余量, List<double> X坐标对集合, List<double> Y坐标对集合)
        {
            NationalInstruments.UI.ScatterPlot 曲线变量 = null;
            string 汽蚀余量编号 = 曲线编号 + "_汽蚀余量";
            List<double> 曲线X坐标对集合 = new List<double>();
            List<double> 曲线Y坐标对集合 = new List<double>();
            double maxX = -1;
            double maxY = -1;

            List<double> 汽蚀余量X = new List<double>();
            List<double> 汽蚀余量Y = new List<double>();

            曲线X坐标对集合 = X坐标对集合;
            曲线Y坐标对集合 = Y坐标对集合;
  
            while (曲线Y坐标对集合.Count>0)
            {
                int index = 公共函数.List_最大值序号(曲线X坐标对集合);
                if (曲线X坐标对集合[index] < (汽蚀余量))
                {
                    if (maxX != -1)
                    {
                        double 汽蚀余量y = ((maxY - 曲线Y坐标对集合[index]) / (maxX - 曲线X坐标对集合[index]) * (汽蚀余量 - 曲线X坐标对集合[index])) + 曲线Y坐标对集合[index];
                        汽蚀余量X.Add(汽蚀余量);
                        汽蚀余量Y.Add(汽蚀余量y);
                        汽蚀余量X轴 = 汽蚀余量;
                        汽蚀余量Y轴 = 汽蚀余量y;
                    }

                    break;
                }
                else
                {
                    maxX = 曲线X坐标对集合[index];
                    maxY = 曲线Y坐标对集合[index];
                    曲线X坐标对集合.Remove(曲线X坐标对集合[index]);
                    曲线Y坐标对集合.Remove(曲线Y坐标对集合[index]);
                }
            }

            if (((曲线编号 != null) && 汽蚀余量存储.ContainsKey(汽蚀余量编号)) && 
                 ((汽蚀余量X.Count>0) && (汽蚀余量Y.Count>0)))
            {

                曲线变量 = (NationalInstruments.UI.ScatterPlot)汽蚀余量存储[汽蚀余量编号];
                曲线变量.Visible = true;
                曲线变量.PlotXY(汽蚀余量X.ToArray(), 汽蚀余量Y.ToArray());
                return true;
            }

            return false;
        }

        public bool f_设置临界值(string 曲线编号, List<double> X坐标对集合, List<double> Y坐标对集合)
        {
            NationalInstruments.UI.ScatterPlot 曲线变量 = null;
            string 汽蚀余量编号 = 曲线编号 + "_临界点";

            曲线变量 = (NationalInstruments.UI.ScatterPlot)汽蚀余量存储[汽蚀余量编号];
            if ((X坐标对集合[0] == 0) || (Y坐标对集合[0]==0))
            {
                 曲线变量.Visible = false;
                 return false;
            }
            曲线变量.Visible = true;
            曲线变量.PlotXY(X坐标对集合.ToArray(), Y坐标对集合.ToArray());
            return true;
        }
      
        public bool f_删除曲线(string 曲线编号)
        {
            if (曲线存储.ContainsKey(曲线编号))
            {
                曲线存储.Remove(曲线编号);
                汽蚀余量存储.Remove(曲线编号 + "_临界点");
                汽蚀余量影子曲线存储.Remove(曲线编号 + "_Tag");

                for (int i = 0; i < this.Graph_View.Plots.Count; i++)
                {
                    if (this.Graph_View.Plots[i].Tag.Equals(曲线编号)==true)
                    {
                        this.Graph_View.Plots.Remove(this.Graph_View.Plots[i]);
                        break;
                    }
                }

                for (int i = 0; i < this.Graph_View.Plots.Count; i++)
                {
                    if (this.Graph_View.Plots[i].Tag.Equals(曲线编号 + "_临界点") == true)
                    {
                        this.Graph_View.Plots.Remove(this.Graph_View.Plots[i]);
                        break;
                    }
                }


                for (int i = 0; i < this.Graph_View.Plots.Count; i++)
                {
                    if (this.Graph_View.Plots[i].Tag.Equals(曲线编号 + "_Tag") == true)
                    {
                        this.Graph_View.Plots.Remove(this.Graph_View.Plots[i]);
                        break;
                    }
                }
                for (int i = 0; i < this.legend1.Items.Count; i++)
                {
                    if (this.legend1.Items[i].Tag.Equals(曲线编号)==true)
                    {
                        this.legend1.Items.Remove(this.legend1.Items[i]);
                        break;
                    }            	
                }
                
                return true;
            }

            return false;
        }
        public NationalInstruments.UI.ScatterPlot 查询曲线(string 曲线编号)
        {

            NationalInstruments.UI.ScatterPlot 曲线变量 = null;

            if ((曲线编号 != null) && 曲线存储.ContainsKey(曲线编号))
            {
                曲线变量 = (NationalInstruments.UI.ScatterPlot)曲线存储[曲线编号];
            }
            return 曲线变量;
        }


    }


    
}
