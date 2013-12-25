using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using NationalInstruments.UI.WindowsForms;
using System.Windows.Forms;
using 辅助库;
using 数据存储;
using NationalInstruments.UI;
//using NationalInstruments.Analysis.SignalGeneration;
namespace 控件库.曲线控件
{
    public partial class XYGraph : UserControl
    {
        /// <summary>
        /// 设置图表样式
        /// </summary>
        /// <param name="styleName"></param>
        private void setGraphStyle(ScatterGraph graph)
        {
            #region X轴样式
            //网格线
            xAxis_Looking.MajorDivisions.GridVisible = _isLinesShowXY;
            xAxis_Looking.MajorDivisions.LabelForeColor = _coordinateStringColor;
            xAxis_Looking.MajorDivisions.GridColor = _MajorLineLineShowColor;
            //副网格线
            xAxis_Looking.MinorDivisions.GridVisible = _isLinesShowXY;
            xAxis_Looking.MinorDivisions.GridColor = _MinorLineLineShowColor;
            #endregion

            #region Y轴样式
            if (_当前显示模式 == "潜水泵性能试验")
            {
                Graph_View.YAxes[0].MajorDivisions.GridVisible = _isLinesShowXY;
                Graph_View.YAxes[0].MajorDivisions.GridColor = _MajorLineLineShowColor;
                return;
            }
            foreach (NationalInstruments.UI.YAxis y in this.Graph_View.YAxes)
            {
                //网格线
                y.MajorDivisions.GridVisible = false;
                //副网格线
                y.MinorDivisions.GridVisible = false;

                if (y.Visible)
                {
                    //网格线
                    y.MajorDivisions.GridVisible = _isLinesShowXY;
                  
                        foreach (ScatterPlot item in Graph_View.Plots)
                        {
                            if (item.YAxis == y)
                            {
                                y.MajorDivisions.LabelForeColor = item.LineColor;
                                break;
                            }
                        }
                    
                    y.MajorDivisions.GridColor = _MajorLineLineShowColor;
                    //副网格线
                    y.MinorDivisions.GridVisible = _isLinesShowXY;
                    y.MinorDivisions.GridColor = _MinorLineLineShowColor;
                }
            }
            #endregion

        }

        /// <summary>
        /// 波形显示中一个点的坐标转换为数据值
        /// </summary>
        /// <param name="x">要转换的点的X轴坐标</param>
        /// <param name="y">要转换的点的Y轴坐标</param>
        /// <param name="outX">转换后的X轴坐标</param>
        /// <param name="outY">转换后的Y轴坐标</param>
        private void _changeXYPointsToNum(ScatterGraph graph, float x, float y, ref double outX, ref double outY)
        {
            Point point = new Point((int)x, (int)y);
            PointF pointf = graph.PointToVirtual(point);

            outX = (graph.XAxes[0].Range.Maximum - graph.XAxes[0].Range.Minimum) * pointf.X + graph.XAxes[0].Range.Minimum;
            outY = (graph.YAxes[0].Range.Maximum - graph.YAxes[0].Range.Minimum) * pointf.Y + graph.YAxes[0].Range.Minimum;
        }

        /// <summary>
        /// 波形显示中矩形区域的坐标转换为数据值百分比
        /// </summary>
        /// <param name="xB">矩形区域左上角X轴坐标</param>
        /// <param name="xE">矩形区域右下角X轴坐标</param>
        /// <param name="yB">矩形区域左上角Y轴坐标</param>
        /// <param name="yE">矩形区域右下角Y轴坐标</param>
        /// <param name="outxB">转换后的左上角X轴坐标值</param>
        /// <param name="outxE">转换后的右下角X轴坐标值</param>
        /// <param name="outyB">转换后的左上角Y轴坐标值</param>
        /// <param name="outyE">转换后的右下角Y轴坐标值</param>
        private void _changeXYPointsToNum(ScatterGraph graph, float xB, float xE, float yB, float yE,
            ref double outxB, ref double outxE, ref double outyB, ref double outyE)
        {
            _changeXYPointsToNum(graph, xB, yB, ref outxB, ref outyB);
            _changeXYPointsToNum(graph, xE, yE, ref outxE, ref outyE);

            outxB = Math.Round(outxB, MidpointRounding.AwayFromZero);
            outxE = Math.Round(outxE, MidpointRounding.AwayFromZero);
            outyB = Math.Round(outyB, MidpointRounding.AwayFromZero);
            outyE = Math.Round(outyE, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 绑定功率分析仪通道
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="Adress"></param>
        private void f_绑定稳态数据通道(string IP, string Adress,string PlotName)
        {
            // 创建绘制波形的对象
            稳态波形通道 class_稳态波形通道 = new 稳态波形通道();
            class_稳态波形通道.波形间隔 = -1;
            class_稳态波形通道.数据编码 = 数据存储.数据来源编码规则.GetAnyWay(IP, Adress);
            class_稳态波形通道.稳态波形 = this.f_GetWaveData;

            // 创建保存绘制波形对象的引用类，保存相关信息
            曲线信息 _曲线信息 = new 曲线信息();
            _曲线信息.稳态波形通道 = class_稳态波形通道;
            _曲线信息.Plot = new NationalInstruments.UI.ScatterPlot();
            _曲线信息.Plot.YAxis = new NationalInstruments.UI.YAxis();
            _曲线信息.Plot.YAxis.Visible = false;
            LegendItem item = new LegendItem();
            item.Source = _曲线信息.Plot;
            item.Text = PlotName;
            legend1.Items.Add(item);
            this.Graph_View.YAxes.Add(_曲线信息.Plot.YAxis);
            this.Graph_View.Plots.Add(_曲线信息.Plot);

            // 找到数据源
            数据项 _数据项 = 数据项哈希存储.GetItem(class_稳态波形通道.数据编码);
            //System.Threading.Thread.Sleep(100);
            _数据项.TheWChannelManager.注册通道(class_稳态波形通道);
            _数据项.TheWChannelManager.开始绘制波形();

            // 保存数据源相关信息
            _曲线信息.数据项 = _数据项;

            // 保存进内存
            List_曲线信息.Add(_曲线信息);
        }

        /// <summary>
        /// 绑定PLC通道
        /// </summary>
        /// <param name="Adress"></param>
        private void f_绑定稳态数据通道(string Adress, string PlotName)
        {
            稳态波形通道 class_稳态波形通道 = new 稳态波形通道();
            class_稳态波形通道.波形间隔 = -1;
            class_稳态波形通道.数据编码 = 数据存储.数据来源编码规则.GetPLC(Adress);
            class_稳态波形通道.稳态波形 = this.f_GetWaveData;

            曲线信息 _曲线信息 = new 曲线信息();
            _曲线信息.稳态波形通道 = class_稳态波形通道;
            _曲线信息.Plot = new NationalInstruments.UI.ScatterPlot();
            _曲线信息.Plot.YAxis = new NationalInstruments.UI.YAxis();
            _曲线信息.Plot.YAxis.Visible = false;
            this.Graph_View.YAxes.Add(_曲线信息.Plot.YAxis);
            this.Graph_View.Plots.Add(_曲线信息.Plot);
            LegendItem item = new LegendItem();
            item.Source = _曲线信息.Plot;
            item.Text = PlotName;
            legend1.Items.Add(item);

            数据项 _数据项 = 数据项哈希存储.GetItem(class_稳态波形通道.数据编码);
            _数据项.TheWChannelManager.注册通道(class_稳态波形通道);
            _数据项.TheWChannelManager.开始绘制波形();

            _曲线信息.数据项 = _数据项;

            List_曲线信息.Add(_曲线信息);
        }

        private void f_绑定稳态数据通道(string PlotName,int YAxisPosition)
        {
            曲线信息 _曲线信息 = new 曲线信息();
            _曲线信息.Name = PlotName;
            _曲线信息.Plot = new ScatterPlot();
            _曲线信息.Plot.Tag = true;
            _曲线信息.Plot.YAxis = new NationalInstruments.UI.YAxis();
            _曲线信息.Plot.YAxis.Visible = false;
            _曲线信息.Plot.YAxis.Position = (NationalInstruments.UI.YAxisPosition)YAxisPosition;
            this.Graph_View.YAxes.Add(_曲线信息.Plot.YAxis);
            this.Graph_View.Plots.Add(_曲线信息.Plot);
            LegendItem item = new LegendItem();
            item.Source = _曲线信息.Plot;
            item.Text = PlotName;
            legend1.Items.Add(item);

            _曲线信息.ShadowPlot = new ScatterPlot();
            _曲线信息.ShadowPlot.LineColor = this.Graph_View.PlotAreaColor;
            _曲线信息.ShadowPlot.LineColorPrecedence = NationalInstruments.UI.ColorPrecedence.UserDefinedColor;
            _曲线信息.ShadowPlot.PointSize = new System.Drawing.Size(8, 8);
            _曲线信息.ShadowPlot.PointStyle = NationalInstruments.UI.PointStyle.Cross;
            _曲线信息.ShadowPlot.YAxis = _曲线信息.Plot.YAxis;
            _曲线信息.ShadowPlot.Tag = false;
            this.Graph_View.Plots.Add(_曲线信息.ShadowPlot);
        }

        /// <summary>
        /// 数据源的事件驱动绑定的方法
        /// </summary>
        /// <param name="开始时间"></param>
        /// <param name="编号"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool f_GetWaveData(DateTime 开始时间, string 编号, double[] x, double[] y)
        {
            if (!是否开始绘制曲线)
            {
                xAxis_Looking.Range = new NationalInstruments.UI.Range(开始时间, 开始时间.Add(new TimeSpan(100000000)));
                
                Graph_View.Plots[0].YAxis.Visible = true;
                Graph_View.Plots[0].YAxis.MajorDivisions.LabelForeColor = Graph_View.Plots[0].LineColor;
                是否开始绘制曲线 = true;
            }

            if (this.Graph_View.IsHandleCreated)
            {
                try
                {
                    this.BeginInvoke(d_绘制曲线, 编号, x, y);
                   // Console.WriteLine(编号);
                }
                catch (Exception ex)
                { }
            }
            return true;
        }

        /// <summary>
        /// 绘制曲线方法
        /// </summary>
        /// <param name="编码"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void f_绘制曲线(string 编码, double[] x, double[] y)
        {
            曲线信息 _曲线信息 = List_曲线信息.Find(item => item.稳态波形通道.数据编码.Equals(编码));
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = xAxis_Looking.Range.Minimum + x[i];
            }
            _曲线信息.Plot.PlotXY(x, y);

        }
    }
}
