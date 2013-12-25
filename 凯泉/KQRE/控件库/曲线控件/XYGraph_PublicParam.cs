using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.UI.WindowsForms;
using NationalInstruments.UI;
using System.Collections;
namespace 控件库.曲线控件
{
    public partial class XYGraph : UserControl
    {
        #region 是否显示按钮
        private bool _是否显示切换Y轴按钮 = true;

        public bool 是否显示切换Y轴按钮
        {
            get { return _是否显示切换Y轴按钮; }
            set { _是否显示切换Y轴按钮 = value; BTN_切换Y轴.Visible = value; }
        }

        private bool _是否显示显示网格按钮 = true;

        public bool 是否显示显示网格按钮
        {
            get { return _是否显示显示网格按钮; }
            set { _是否显示显示网格按钮 = value; buttonLinesShowXY.Visible = value; }
        }
        private bool _是否显示放大查看按钮 = true;

        public bool 是否显示放大查看按钮
        {
            get { return _是否显示放大查看按钮; }
            set { _是否显示放大查看按钮 = value; buttonBigModeXY.Visible = value; }
        }
        private bool _是否显示恢复默认网格按钮 = true;

        public bool 是否显示恢复默认网格按钮
        {
            get { return _是否显示恢复默认网格按钮; }
            set { _是否显示恢复默认网格按钮 = value; buttonReXY.Visible = value; }
        }
        private bool _是否显示计算差值按钮 = true;

        public bool 是否显示计算差值按钮
        {
            get { return _是否显示计算差值按钮; }
            set { _是否显示计算差值按钮 = value; buttonModeXY.Visible = value; }
        }
        private bool _是否显示停止曲线显示按钮 = true;

        public bool 是否显示停止曲线显示按钮
        {
            get { return _是否显示停止曲线显示按钮; }
            set { _是否显示停止曲线显示按钮 = value; BTN_停止显示.Visible = value; }
        }
        #endregion

        #region 是否启用按钮
        private bool _是否启用显示网格按钮 = true;

        public bool 是否启用显示网格按钮
        {
            get { return _是否启用显示网格按钮; }
            set { _是否启用显示网格按钮 = value; buttonLinesShowXY.Enabled = value; }
        }
        private bool _是否启用放大查看按钮 = true;

        public bool 是否启用放大查看按钮
        {
            get { return _是否启用放大查看按钮; }
            set { _是否启用放大查看按钮 = value; buttonBigModeXY.Enabled = value; }
        }
        private bool _是否启用恢复默认网格按钮 = true;

        public bool 是否启用恢复默认网格按钮
        {
            get { return _是否启用恢复默认网格按钮; }
            set { _是否启用恢复默认网格按钮 = value; buttonReXY.Enabled = value; }
        }
        private bool _是否启用计算差值按钮 = true;

        public bool 是否启用计算差值按钮
        {
            get { return _是否启用计算差值按钮; }
            set { _是否启用计算差值按钮 = value; buttonModeXY.Enabled = value; }
        }
        private bool _是否启用停止曲线显示按钮 = true;

        public bool 是否启用停止曲线显示按钮
        {
            get { return _是否启用停止曲线显示按钮; }
            set { _是否启用停止曲线显示按钮 = value; BTN_停止显示.Enabled = value; }
        }
        #endregion

        private Hashtable 曲线存储 = null;
        private Hashtable 汽蚀余量影子曲线存储 = null; 
        private Hashtable 汽蚀余量存储 = null; 
        private NationalInstruments.UI.YAxis yaxis_汽蚀试验 = null;
        public XAxis x轴对象
        {
            get { return this.xAxis_Looking; }
            set { this.xAxis_Looking = value; }
        }

        /// <summary>
        /// 横向X轴滚动条
        /// </summary>
        public Slide XSlide
        {
            get { return this.slide; }
            set { this.slide = value; }
        }

        private bool _是否显示横向滚动条 = true;

        public bool 是否显示横向滚动条
        {
            get { return _是否显示横向滚动条; }
            set { _是否显示横向滚动条 = value; this.slide.Visible = value; }
        }
        
        private NationalInstruments.UI.FormatString _X轴计数格式;

        public NationalInstruments.UI.FormatString X轴计数格式
        {
            get { return _X轴计数格式; }
            set
            {
                _X轴计数格式 = value;
                xAxis_Looking.MajorDivisions.LabelFormat = value;
            }
        }

        private Legend _曲线标签组;

        public Legend 曲线标签组
        {
            get { return this.legend1; }
            set { _曲线标签组 = value; }
        }
        /// <summary>
        ///  波形工作区对象
        /// </summary>
        public ScatterGraph Graph
        {
            get { return this.Graph_View; }
            set { this.Graph_View = value;  }
        }

        /// <summary>
        /// 游标B
        /// </summary>
        public XYCursor XYCursorB
        {
            get { return this.xyCursorB; }
            set { this.xyCursorB = value; }
        }

        /// <summary>
        /// 游标E
        /// </summary>
        public XYCursor XYCursorE
        {
            get { return this.xyCursorE; }
            set { this.xyCursorE = value; }
        }

        public event NationalInstruments.UI.AfterMoveXYCursorEventHandler 游标B移动后触发委托;

        public event NationalInstruments.UI.AfterMoveXYCursorEventHandler 游标E移动后触发委托;

        public event NationalInstruments.UI.AfterChangeNumericValueEventHandler 拖动曲线触发委托;

       // public event 暂停画线 暂停事件;

        #region **公有属性 控件外观样式**
        /// <summary>
        /// 网格线的颜色
        /// </summary>
        public Color MajorLineLineShowColor
        {
            get { return _MajorLineLineShowColor; }
            set { _MajorLineLineShowColor = value; }
        }

        /// <summary>
        /// 副网格线的颜色
        /// </summary>
        public Color MinorLineLineShowColor
        {
            get { return _MinorLineLineShowColor; }
            set { _MinorLineLineShowColor = value; }
        }

        /// <summary>
        /// 坐标值颜色
        /// </summary>
        public Color CoordinateStringColor
        {
            get { return _coordinateStringColor; }
            set { _coordinateStringColor = value; }
        }

        /// <summary>
        /// 工具栏按钮前景未选中颜色
        /// </summary>
        public Color m_ControlButtonForeColorH
        {
            set { ControlButtonForeColorH = value; }
            get { return ControlButtonForeColorH; }
        }

        /// <summary>
        /// 工具栏按钮前景选中颜色
        /// </summary>
        public Color m_ControlButtonForeColorL
        {
            set { ControlButtonForeColorL = value; }
            get { return ControlButtonForeColorL; }
        }
        #endregion
    }
}
