using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 控件库.曲线控件;
using NationalInstruments.UI;

namespace LogicApp
{
    public class 启停惰转曲线
    {
        public static void 构造曲线(DataTable tb,out double[] 电压,out double[] 电流,out double[] 流量,out double[] 进口压力,out double[] 出口压力,out double[] 转速,out double[] 时间轴)
        {
            // 曲线集包含电压,电流和轴功率,时间轴
            int len = tb.Rows.Count;
            double[] _电压 = new double[len];
            double[] _电流 = new double[len];
            double[] _流量 = new double[len];
            double[] _进口压力 = new double[len];
            double[] _出口压力 = new double[len];
            double[] _转速 = new double[len];
            double[] _时间轴 = new double[len];
       
            for (int i = 0; i < len; i++)
            {
                _电压[i] = System.Convert.ToDouble(tb.Rows[i]["电压"]);
                _电流[i] = System.Convert.ToDouble(tb.Rows[i]["电流"]);
                _流量[i] = System.Convert.ToDouble(tb.Rows[i]["流量"]);
                _进口压力[i] = System.Convert.ToDouble(tb.Rows[i]["进口压力"]);
                _出口压力[i] = System.Convert.ToDouble(tb.Rows[i]["出口压力"]);
                _转速[i] = System.Convert.ToDouble(tb.Rows[i]["转速"]);
                _时间轴[i] = System.Convert.ToDouble(tb.Rows[i]["时基值"]);
            }
            电压 = _电压;
            电流 = _电流;
            流量 = _流量;
            进口压力 = _进口压力;
            出口压力 = _出口压力;
            转速 = _转速;
            时间轴 = _时间轴;
        }

        public static void 绘制曲线(控件库.曲线控件.XYGraph graph, double[] 电压, double[] 电流, double[] 流量, double[] 进口压力, double[] 出口压力, double[] 转速, double[] 时间轴)
        {
            graph.Graph.Plots[0].PlotXY(时间轴, 电压);
            graph.Graph.Plots[1].PlotXY(时间轴, 电流);
            graph.Graph.Plots[2].PlotXY(时间轴, 流量);
            graph.Graph.Plots[3].PlotXY(时间轴, 进口压力);
            graph.Graph.Plots[4].PlotXY(时间轴, 出口压力);
            graph.Graph.Plots[5].PlotXY(时间轴, 转速);
        }
    }
}
