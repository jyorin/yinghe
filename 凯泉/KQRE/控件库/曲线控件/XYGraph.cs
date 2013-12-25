using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace 控件库.曲线控件
{

    public partial class XYGraph : UserControl
    {

        public delegate void UpdateHandler(NationalInstruments.UI.AfterDrawXYPlotEventArgs e);
        public event UpdateHandler UpdateEvent;

        public XYGraph()
        {
            InitializeComponent();

            曲线存储 = new Hashtable();
            汽蚀余量存储 = new Hashtable();
            汽蚀余量影子曲线存储 = new Hashtable();
            xyCursorB.AfterMove += new NationalInstruments.UI.AfterMoveXYCursorEventHandler(xyCursorB_AfterMove);
            xyCursorE.AfterMove += new NationalInstruments.UI.AfterMoveXYCursorEventHandler(xyCursorE_AfterMove);
            slide.AfterChangeValue += new NationalInstruments.UI.AfterChangeNumericValueEventHandler(this.slide_AfterChangeValue);
            Graph_View.YAxes.Clear();
            Graph_View.Plots.Clear();
            曲线存储.Clear();
            汽蚀余量存储.Clear();
            //d_绘制曲线 = f_绘制曲线;


        }

        public NationalInstruments.UI.WindowsForms.Legend 波形下标
        {
            get { return this.legend1; }
        }

        private void panel_text_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (_当前显示模式 == "潜水泵性能试验")
            {
                g.DrawString("扬程[m]", new Font("宋体", 9), Brushes.Black, new PointF(panel_text.Location.X + 3, 5));
                g.DrawString("η[%]", new Font("宋体", 9), Brushes.Black, new PointF(panel_text.Width - 130, 5));
                g.DrawString("P[kW]", new Font("宋体", 9), Brushes.Black, new PointF(panel_text.Width - 100, 5));
                g.DrawString("NPSH[m]", new Font("宋体", 9), Brushes.Black, new PointF(panel_text.Width - 70, 5));
            }
            else if (_当前显示模式 == "汽蚀试验")
            {
                g.DrawString("扬程[m]", new Font("宋体", 9), Brushes.Black, new PointF(panel_text.Location.X + 3, 5));
            }
        }

        private void Graph_View_AfterDrawPlot(object sender, NationalInstruments.UI.AfterDrawXYPlotEventArgs e)
        {
            if (UpdateEvent != null)
                UpdateEvent(e);
        }


       

    }
}
