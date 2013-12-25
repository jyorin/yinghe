using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 数据存储;


namespace 控件库.曲线控件
{
    public partial class XYGraph : UserControl
    {
        #region ** 私有成员 波形显示控件基本成员 **

        private string _当前显示模式;

        private double _汽蚀余量X轴=0;

        public double 汽蚀余量X轴
        {
            get { return _汽蚀余量X轴; }
            set { _汽蚀余量X轴 = value; }
        }

        private double _汽蚀余量Y轴=0;

        public double 汽蚀余量Y轴
        {
            get { return _汽蚀余量Y轴; }
            set { _汽蚀余量Y轴 = value; }
        }
        /// <summary>
        /// 是否开始绘制曲线,用于开始绘制曲线时初始化时间原点
        /// </summary>
        private bool _是否开始绘制曲线;

        public bool 是否开始绘制曲线
        {
            get { return _是否开始绘制曲线; }
            set { _是否开始绘制曲线 = value; }
        }
        /// <summary>
        /// 当前是否显示网格
        /// </summary>
        private bool _isLinesShowXY = false;
        public bool isLinesShowXY
        {
            get { return _isLinesShowXY; }
            set { _isLinesShowXY = value; }
        }
        /// <summary>
        /// 当前是否允许放大缩小选取框显示
        /// </summary>
        private bool _isShowBigSmallModeXY = false;
        public bool isShowBigSmallModeXY
        {
            get { return _isShowBigSmallModeXY; }
            set { _isShowBigSmallModeXY = value; }

        }
        /// <summary>
        /// 当前是否处于放大查看模式
        /// </summary>
        private bool _isBigModeXY = false;
        public bool isBigModeXY
        {
            get { return _isBigModeXY; }
            set { _isBigModeXY = value; }

        }
        /// <summary>
        /// 当前坐标是否自动调整以适合窗口大小
        /// </summary>
        private bool _isAutoModeXY = true;
        public bool isAutoModeXY
        {
            get { return _isAutoModeXY; }
            set { _isAutoModeXY = value; }

        }

        /// <summary>
        /// 是否显示游标并计算
        /// </summary>
        private bool _isShowModeXY = false;
        public bool isShowModeXY
        {
            get { return _isShowModeXY; }
            set { _isShowModeXY = value; }

        }
        /// <summary>
        /// 坐标显示最多小数位数
        /// </summary>
        private int _iAccuracy = 2;
        public int iAccuracy
        {
            get { return _iAccuracy; }
            set { _iAccuracy = value; }

        }
        /// <summary>
        /// 默认X轴范围
        /// </summary>
        private NationalInstruments.UI.Range _defaultXRang = new NationalInstruments.UI.Range(0,100);

        /// <summary>
        /// 默认Y轴范围
        /// </summary>
        private NationalInstruments.UI.Range _defaultYRang = new NationalInstruments.UI.Range(-500, 500);



        #endregion

        #region ** 私有成员 波形显示控件外观样式方案 **
      
        //网格线的颜色
        private Color _MajorLineLineShowColor = Color.FromArgb(185, 185, 185);
        //副网格线的颜色
        private Color _MinorLineLineShowColor = Color.FromArgb(243, 243, 243);

        //坐标值颜色
        private Color _coordinateStringColor = Color.FromArgb(0, 0, 0);
        public Color coordinateStringColor
        {
            get { return _coordinateStringColor; }
            set { _coordinateStringColor = value; }
        }

        //工具栏按钮前景未选中颜色
        private Color ControlButtonForeColorH = Color.FromArgb(100, 100, 100);
        //工具栏按钮前景选中颜色
        private Color ControlButtonForeColorL = Color.FromArgb(250, 250, 250);
        #endregion

        #region ** 私有成员 绑定数据使用的变量
        private List<曲线信息> List_曲线信息 = new List<曲线信息>();
        private delegate void D_绘制曲线(string 编码, double[] x, double[] y);
        private D_绘制曲线 d_绘制曲线 = null;
        #endregion
    }

    /// <summary>
    /// 绑定数据源时用于存储曲线信息的对象类
    /// </summary>
    class 曲线信息
    {
        public 曲线信息()
        { }
        public string Name
        {
            get;
            set;
        }
        public NationalInstruments.UI.ScatterPlot Plot
        {
            get;
            set;
        }
        public NationalInstruments.UI.ScatterPlot ShadowPlot
        {
            get;
            set;
        }
        public 数据项 数据项
        {
            get;
            set;
        }

        public 稳态波形通道 稳态波形通道
        {
            get;
            set;
        }
    }

}
